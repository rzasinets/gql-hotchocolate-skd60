namespace gql_hotchocolate_skd60.GraphQL.Payload;

public class CommonError : IBaseError
{
  public string? Details { get; set; }

  public string Type { get; init; }
}

public abstract class HandleNotUniqueError : CommonError
{
  protected HandleNotUniqueError(string? details = null)
  {
    Type = "handle-not-unique";
    Details = details;
  }
}

public abstract class ResourceNotFoundError : CommonError
{
  protected ResourceNotFoundError(string? details = null)
  {
    Type = "resource-not-found";
    Details = details;
  }
}
