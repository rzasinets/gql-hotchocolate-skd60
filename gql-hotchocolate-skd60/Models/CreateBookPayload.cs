namespace gql_hotchocolate_skd60.Models
{
  using gql_hotchocolate_skd60.GraphQL.Payload;

  public class CreateBookPayload : BasePayload<CreateBookPayload, ICreateBookError>
  {
    public Book? Book { get; set; }
  }

  public interface ICreateBookError { }

  public class CreateBookErrorUnion : UnionType<ICreateBookError>
  {
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
      descriptor.Type<CreateBookHandleNotUniqueErrorType>();
    }
  }

  public class CreateBookHandleNotUniqueError : HandleNotUniqueError, ICreateBookError { }

  public class CreateBookHandleNotUniqueErrorType : ObjectType<CreateBookHandleNotUniqueError> { }
}