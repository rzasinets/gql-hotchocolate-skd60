namespace gql_hotchocolate_skd60.Controllers
{
  using gql_hotchocolate_skd60.GraphQL.Payload;
  using gql_hotchocolate_skd60.Models;

  public class Mutation
  {
    public CreateBookPayload? CreateBook(CreateBookInput input)
    {
      if (input.ThrowEr)
      {
        return CreateBookPayload.Error(new InternalServerError());
      }

      if (input.Title == "555")
      {
        return CreateBookPayload.Error(new CreateBookHandleNotUniqueError());
      }

      return new CreateBookPayload { Book = new Book { Title = input.Title, Author = new Author { Name = "Jon Skeet" } } };
    }
      
  }
}