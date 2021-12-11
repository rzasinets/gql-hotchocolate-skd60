namespace gql_hotchocolate_skd60.GraphQL.Payload
{
  public abstract class BasePayload<TPayload, TError>
    where TPayload : BasePayload<TPayload, TError>, new()
  {
    // ReSharper disable once CollectionNeverQueried.Global
    public List<TError> Errors { get; } = new();
    // ReSharper disable once CollectionNeverQueried.Global
    public List<ISystemError> SystemErrors { get; } = new();

    /// <summary>
    ///   Return new instance of failure payload (mutation specific errors)
    /// </summary>
    [GraphQLIgnore]
    public static TPayload Error(params TError[] errors)
    {
      var u = new TPayload();
      u.Errors.AddRange(errors);
      return u;
    }

    /// <summary>
    ///   Return new instance of failure payload (system errors)
    /// </summary>
    [GraphQLIgnore]
    public static TPayload Error(params ISystemError[] errors)
    {
      var u = new TPayload();
      u.SystemErrors.AddRange(errors);
      return u;
    }

    /// <summary>
    ///   Add errors collection and return itself
    /// </summary>
    [GraphQLIgnore]
    public TPayload PushError(params TError[] errors)
    {
      Errors.AddRange(errors);
      return (TPayload)this;
    }

    [GraphQLIgnore]
    public TPayload PushError(params ISystemError[] errors)
    {
      SystemErrors.AddRange(errors);

      return (TPayload)this;
    }
  }
}
