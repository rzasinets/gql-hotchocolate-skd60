namespace gql_hotchocolate_skd60.MediatR.Commands;

using FluentValidation;

using global::MediatR;

using gql_hotchocolate_skd60.GraphQL.Payload;
using gql_hotchocolate_skd60.MediatR.Behaviours;
using gql_hotchocolate_skd60.Models;

// [Authorize]
public class CreateBook : CreateBookInput, IRequest<CreateBookPayload> {
}

public class CreateUserAuthorizationValidator : AuthorizationValidator<CreateBook> {
}

public class CreateBookValidator:AbstractValidator<CreateBook>
{
  public CreateBookValidator()
  {
    RuleFor(x => x.Title).MinimumLength(3);
  }
}

public class CreateBookHandler : IRequestHandler<CreateBook, CreateBookPayload> {
  
  public Task<CreateBookPayload> Handle(CreateBook request, CancellationToken cancellationToken)
  {
    if (request.ThrowEr)
    {
      return Task.FromResult(CreateBookPayload.ThrowError(new InternalServerError()));
    }

    if (request.Title == "555")
    {
      return Task.FromResult(CreateBookPayload.ThrowError(new HandleNotUniqueError()));
    }

    return Task.FromResult(new CreateBookPayload { Book = new Book { Title = request.Title, Author = new Author { Name = "Jon Skeet" } } });
  }
}