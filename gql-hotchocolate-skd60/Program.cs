using FluentValidation;

using gql_hotchocolate_skd60.Controllers;
using gql_hotchocolate_skd60.GraphQL.Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
services.AddValidatorsFromAssemblyContaining<Program>();

services.AddGraphQLServer()
  .AddQueryType<Query>()
  .AddMutationType<Mutation>()
  .RegisterGQLTypes()
  .AddAuthorization()
  .AddFairyBread();


var app = builder.Build();

app.MapGraphQL();

app.Run();