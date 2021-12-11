namespace gql_hotchocolate_skd60.GraphQL.Payload;

public class HandleNotUniqueError : BaseError
{
  public HandleNotUniqueError(string? details = null)
  {
    Type = "handle-not-unique";
    Details = details;
  }
}

public class HandleNotUniqueErrorType : ObjectType<HandleNotUniqueError> { }

public class ResourceNotFoundError : BaseError
{
  public ResourceNotFoundError(string? details = null)
  {
    Type = "resource-not-found";
    Details = details;
  }
}

public class ResourceNotFoundErrorType : ObjectType<ResourceNotFoundError> { }
