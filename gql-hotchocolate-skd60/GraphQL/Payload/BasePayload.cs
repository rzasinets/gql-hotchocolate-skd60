namespace gql_hotchocolate_skd60.GraphQL.Payload
{
  public interface IBasePayload
  {
    void SetError(IBaseError err);
  }
  
  public abstract class BasePayload<TPayload>: IBasePayload
    where TPayload : BasePayload<TPayload>, new()
  {
    public IBaseError? Error { get; private set; }

    /// <summary>
    ///   Return new instance of failure payload (mutation specific errors)
    /// </summary>
    [GraphQLIgnore]
    public static TPayload ThrowError(IBaseError error)
    {
      return new TPayload { Error = error };
    }

    [GraphQLIgnore]
    public void SetError(IBaseError err)
    {
      Error = err;
    }
  }
}
