namespace gql_hotchocolate_skd60.MediatR
{
  using gql_hotchocolate_skd60.GraphQL.Payload;

  public static class Common
  {
    public static TResponse HandleBaseCommandException<TResponse>(Exception ex)
    {
      var payload = (IBasePayload)Activator.CreateInstance<TResponse>()!;

      payload.SetError(new InternalServerError(ex.Message));

      return (TResponse)payload;
    }

    // Check if object is derived from specific type
    public static bool IsSubclassOfRawGeneric(Type generic, Type? toCheck)
    {
      while (toCheck != null && toCheck != typeof(object))
      {
        var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
        if (generic == cur)
        {
          return true;
        }

        toCheck = toCheck.BaseType;
      }

      return false;
    }
  }
}