namespace gql_hotchocolate_skd60.GraphQL.Payload;

public class SystemError : IBaseError
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

public class UnAuthorisedError : SystemError
{
  public UnAuthorisedError(string? details = null)
  {
    Type = "un-authorized";
    Details = details;
  }
}

public class UnAuthorisedErrorType : ObjectType<UnAuthorisedError> { }

public class ValidationError : SystemError
{
  public ValidationError(string? details = null)
  {
    Type = "validation-error";
    Details = details;
  }

  public ValidationError(string propName, string details)
    : this(details)
  {
    PropName = propName;
  }

  public string? PropName { get; set; }
}

public class ValidationErrorType : ObjectType<ValidationError> { }