using gql_hotchocolate_skd60.GraphQL;

namespace gql_hotchocolate_skd60.Controllers
{
  using gql_hotchocolate_skd60.Models;

  public class Mutation
  {
    [Error(typeof(InternalServerError))]
    [Error(typeof(HandleNotUniqueError))]
    public Book CreateBook(CreateBookInput input)
    {
      if (input.ThrowEr)
      {
        throw new Exception("My message");
      }

      if (input.Title == "555")
      {
        throw new HandleNotUniqueError();
      }

      return new Book { Title = input.Title, Author = new Author { Name = "Jon Skeet" } };
    }
      
  }
}

public class InternalServerError : IMyError
{
  public static InternalServerError CreateErrorFrom(Exception ex)
  {
    return new InternalServerError
      {
        Details = ex.Message
      };
  }

  public string Type { get; set; } = "internal-server-error";

  public string? Details { get; set; }
}

public class HandleNotUniqueError: Exception, IMyError
{
  public HandleNotUniqueError(string? details = null)
  {
    Details = details;
  }
  
  public string Type { get; set; } = "internal-server-error";

  public string? Details { get; set; }
}