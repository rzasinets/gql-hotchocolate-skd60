namespace gql_hotchocolate_skd60.GraphQL;

public interface IMyError
{
  string Type { get; set; }
  string? Details { get; set; }
}