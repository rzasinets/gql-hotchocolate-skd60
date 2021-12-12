namespace gql_hotchocolate_skd60.MediatR.Behaviours
{
  using global::MediatR;

  using gql_hotchocolate_skd60.GraphQL.Payload;
  using gql_hotchocolate_skd60.MediatR;

  /// <summary>
  ///   UnhandledExBehaviour for MediatR pipeline
  /// </summary>
  /// <typeparam name="TRequest"></typeparam>
  /// <typeparam name="TResponse"></typeparam>
  public class UnhandledExBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
  {
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
      try
      {
        // Continue in pipe
        return await next();
      }
      catch (Exception ex)
      {
        ex.Data.Add("command_failed", true);

        // In case it is Mutation Response Payload = handled as payload error union
        if (Common.IsSubclassOfRawGeneric(typeof(BasePayload<>), typeof(TResponse)))
        {
          return Common.HandleBaseCommandException<TResponse>(ex);
        }

        throw;
      }
    }
  }
}