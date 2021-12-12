namespace gql_hotchocolate_skd60.MediatR.Behaviours
{
  using FluentValidation;
  using FluentValidation.Results;

  using global::MediatR;

  using gql_hotchocolate_skd60.GraphQL.Payload;
  using gql_hotchocolate_skd60.MediatR;

  /// <summary>
  ///   Authorization behaviour for MediatR pipeline
  /// </summary>
  /// <typeparam name="TRequest"></typeparam>
  /// <typeparam name="TResponse"></typeparam>
  public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
  {
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
      _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
      if (_validators.Any())
      {
        try
        {
          var context = new ValidationContext<TRequest>(request);

          var validationResults = await Task.WhenAll(
                                    _validators.Where(v => v is not IAuthorizationValidator).Select(v => v.ValidateAsync(context, cancellationToken))
                                  );

          var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

          if (failures.Count != 0)
          {
            return HandleValidationErrors(failures);
          }
        }
        catch (Exception ex)
        {
          // In case it is Mutation Response Payload = handled as payload error union
          if (Common.IsSubclassOfRawGeneric(typeof(BasePayload<>), typeof(TResponse)))
          {
            return Common.HandleBaseCommandException<TResponse>(ex);
          }
          else
          {
            throw;
          }
        }
      }

      // Continue in pipe
      return await next();
    }

    private static TResponse HandleValidationErrors(List<ValidationFailure> errorObj)
    {
      // In case it is Mutation Response Payload = handled as payload error union
      if (Common.IsSubclassOfRawGeneric(typeof(BasePayload<>), typeof(TResponse)))
      {
        IBasePayload payload = (IBasePayload)Activator.CreateInstance<TResponse>()!;

        foreach (var item in errorObj)
        {
          payload.SetError(new ValidationError(item.PropertyName, item.ErrorMessage));
        }

        return (TResponse)payload;
      }

      var firstItem = errorObj.FirstOrDefault();
      if (firstItem != null)
      {
        throw new ValidationException($"Field: {firstItem.PropertyName} - {firstItem.ErrorMessage}");
      }

      throw new ValidationException("Validation error appear");
    }
  }
}