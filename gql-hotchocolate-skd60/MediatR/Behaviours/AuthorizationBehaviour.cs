namespace gql_hotchocolate_skd60.MediatR.Behaviours
{
  using System.Reflection;

  using FluentValidation;

  using global::MediatR;

  using gql_hotchocolate_skd60.GraphQL.Payload;
  using gql_hotchocolate_skd60.MediatR.Exceptions;

  /// <summary>
  ///   Authorization marker interface for Fluent validation
  /// </summary>
  public interface IAuthorizationValidator { }

  /// <summary>
  ///   Authorization validator wrapper
  /// </summary>
  /// <typeparam name="TRequest"></typeparam>
  public class AuthorizationValidator<TRequest> : AbstractValidator<TRequest>, IAuthorizationValidator { }

  /// <summary>
  ///   Authorization behaviour for MediatR pipeline
  /// </summary>
  /// <typeparam name="TRequest"></typeparam>
  /// <typeparam name="TResponse"></typeparam>
  public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
  {
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
      var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

      if (authorizeAttributes.Any())
      {
        return HandleUnAuthorised();
      }

      // Continue in pipe
      return await next();
    }

    private static TResponse HandleUnAuthorised()
    {
      // In case it is Mutation Response Payload = handled as payload error union
      if (Common.IsSubclassOfRawGeneric(typeof(BasePayload<>), typeof(TResponse)))
      {
        IBasePayload payload = (IBasePayload)Activator.CreateInstance<TResponse>()!;

        payload.SetError(new UnAuthorisedError());

        return (TResponse)payload;
      }

      throw new AuthorizationException();
    }
  }
}