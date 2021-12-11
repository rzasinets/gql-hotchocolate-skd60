namespace gql_hotchocolate_skd60.GraphQL.Payload
{
  public abstract class BasePayload<TPayload>
    where TPayload : BasePayload<TPayload>, new()
  {
    public IBaseError? Error { get; private init; }

    /// <summary>
    ///   Return new instance of failure payload (mutation specific errors)
    /// </summary>
    [GraphQLIgnore]
    public static TPayload ThrowError(IBaseError error)
    {
      return new TPayload { Error = error };
    }
  }
}
