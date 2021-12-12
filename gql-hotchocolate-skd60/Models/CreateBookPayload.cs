namespace gql_hotchocolate_skd60.Models
{
  using gql_hotchocolate_skd60.GraphQL.Payload;

  public class CreateBookPayload : BasePayload<CreateBookPayload>
  {
    public Book? Book { get; set; }
  }

  public class CreateBookPayloadType : ObjectType<CreateBookPayload>
  {
    protected override void Configure(IObjectTypeDescriptor<CreateBookPayload> descriptor)
    {
      descriptor.Field(x => x.Error).Type<CreateBookErrorUnion>();
    }
  }

  /// <summary>
  /// Description
  /// <see cref="HandleNotUniqueErrorType"/> - handle non unique
  /// <see cref="InternalServerErrorType"/> - something bad happened on server
  /// </summary>
  public interface ICreateBookError { }

  public class CreateBookErrorUnion : UnionType<ICreateBookError>
  {
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
      
      descriptor.Type<HandleNotUniqueErrorType>();
      descriptor.Type<InternalServerErrorType>();
      // New from Mediatr
      descriptor.Type<UnAuthorisedErrorType>();
      descriptor.Type<ValidationErrorType>();
    }
  }
}