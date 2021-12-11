namespace gql_hotchocolate_skd60.GraphQL.Payload;

public interface ISystemError
{
  string Type { get; init; }
  string? Details { get; set; }
}

public class SystemError : ISystemError
{
  public string? Details { get; set; }

  public string Type { get; init; }
}

public class InternalServerError : SystemError
{
  public InternalServerError(string? details = null)
  {
    Type = "internal-server-error";
    Details = details;
  }
}

public class InternalServerErrorType : ObjectType<InternalServerError> { }
