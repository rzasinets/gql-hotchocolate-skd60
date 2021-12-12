namespace gql_hotchocolate_skd60.Controllers
{
  using global::MediatR;

  using gql_hotchocolate_skd60.MediatR.Commands;
  using gql_hotchocolate_skd60.Models;

  public class Mutation
  {
    public async Task<CreateBookPayload> CreateBook([Service] IMediator mediator, CreateBookInput input)
    {
      return await mediator.Send(new CreateBook{
          Title = input.Title,
          ThrowEr = input.ThrowEr
        });
    }
      
  }
}