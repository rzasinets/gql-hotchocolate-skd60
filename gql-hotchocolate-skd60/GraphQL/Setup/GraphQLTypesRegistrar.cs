namespace gql_hotchocolate_skd60.GraphQL.Setup;

using System.Reflection;

using HotChocolate.Execution.Configuration;

public static class GraphQLTypesRegistrar
{
  public static IRequestExecutorBuilder RegisterGQLTypes(this IRequestExecutorBuilder requestExecutorBuilder)
  {
    var assembly = typeof(Program).Assembly;

    var gqlTypes = assembly.DefinedTypes
      .Where(t => typeof(IObjectType).IsAssignableFrom(t) || typeof(IInputObjectType).IsAssignableFrom(t) || typeof(IInterfaceType).IsAssignableFrom(t) || typeof(IUnionType).IsAssignableFrom(t))
      .Where(t => !t.GetTypeInfo().IsAbstract);
    foreach (var gqlType in gqlTypes)
    {
      requestExecutorBuilder.AddType(gqlType);
    }

    return requestExecutorBuilder;
  }
}
