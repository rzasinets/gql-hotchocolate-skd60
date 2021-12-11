namespace gql_hotchocolate_skd60.GraphQL.Payload
{
  public interface IBaseError
  {
    string Type { get; init; }
    string? Details { get; set; }
  }

  public class BaseError : IBaseError
  {
    public string Type { get; init; }

    public string? Details { get; set; }
  }
}
