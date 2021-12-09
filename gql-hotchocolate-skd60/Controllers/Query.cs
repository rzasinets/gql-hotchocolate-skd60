namespace gql_hotchocolate_skd60.Controllers
{
  using gql_hotchocolate_skd60.Models;

  public class Query
  {
    public Book GetBook() =>
      new Book
        {
          Title = "C# in depth.",
          Author = new Author
            {
              Name = "Jon Skeet"
            }
        };
  }
}