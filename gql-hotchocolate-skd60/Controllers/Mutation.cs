namespace gql_hotchocolate_skd60.Controllers
{
  using System;

  using gql_hotchocolate_skd60.Models;

  public class Mutation
  {
    public CreateBookPayload? CreateBook(CreateBookInput input)
    {
      if (input.ThrowEr)
      {
        throw new Exception("Ex");
      }

      return new CreateBookPayload { Book = new Book { Title = input.Title, Author = new Author { Name = "Jon Skeet" } } };
    }
      
  }
}