using FluentValidation;

using gql_hotchocolate_skd60.Controllers;
using gql_hotchocolate_skd60.GraphQL;
using gql_hotchocolate_skd60.GraphQL.Setup;

using HotChocolate.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
services.AddValidatorsFromAssemblyContaining<Program>();

services.AddGraphQLServer()
  .AddQueryType<Query>()
  .AddMutationType<Mutation>()
  .RegisterGQLTypes()
  .AddAuthorization()
  .AddErrorFilter<MyErrorFilter>()
  .AddMutationConventions(true)
  .AddErrorInterfaceType<IMyError>()
  // TODO Validation is broken
  /*.AddFairyBread()*/;


var app = builder.Build();

app.MapGraphQL();
app.UsePlayground("/graphql", "/playground");

app.Run();