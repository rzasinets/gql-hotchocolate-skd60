using FluentValidation;

using gql_hotchocolate_skd60.Controllers;
using gql_hotchocolate_skd60.GraphQL.Payload;
using gql_hotchocolate_skd60.GraphQL.Setup;
using gql_hotchocolate_skd60.MediatR.Behaviours;

using HotChocolate.AspNetCore;

using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
services.AddValidatorsFromAssemblyContaining<Program>();

services.AddGraphQLServer()
  .AddQueryType<Query>()
  .AddMutationType<Mutation>()
  .RegisterGQLTypes()
  .AddType<IBaseError>()
  .AddAuthorization()
  .AddErrorFilter<MyErrorFilter>()
  .AddFairyBread();

services.AddMediatR(typeof(Program));
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExBehaviour<,>));


var app = builder.Build();

app.MapGraphQL();
app.UsePlayground("/graphql", "/playground");

app.Run();