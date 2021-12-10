using FluentValidation;

using gql_hotchocolate_skd60.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
services.AddValidatorsFromAssemblyContaining<Program>();

services.AddGraphQLServer()
  .AddQueryType<Query>()
  .AddMutationType<Mutation>()
  .AddAuthorization()
  .AddFairyBread();


var app = builder.Build();

app.MapGraphQL();

app.Run();