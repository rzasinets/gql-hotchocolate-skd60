namespace gql_hotchocolate_skd60.Controllers
{
  using System;

  using gql_hotchocolate_skd60.Models;

  using HotChocolate.AspNetCore.Authorization;

  public class Mutation
  {
    public Book CreateBook(CreateBookInput input)
    {
      if (input.ThrowEr)
      {
        throw new Exception("Ex");
      }
      return new Book
        {
          Title = input.Title,
          Author = new Author
            {
              Name = "Jon Skeet"
            }
        };
    }
      
  }
}