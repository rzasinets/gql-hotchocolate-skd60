namespace gql_hotchocolate_skd60.GraphQL.Setup;

public class MyErrorFilter:IErrorFilter
{
  public IError OnError(IError err)
  {
    if (err.Exception != null)
    {
      Console.WriteLine("MyErrorFilter exception handled: {0}: {1}", err.Exception.GetType(), err.Exception.Message);
    }

    return err;
  }
}