namespace gql_hotchocolate_skd60.MediatR.Exceptions
{
  using FluentValidation.Results;

  public class AuthorizationException : Exception
  {
    public AuthorizationException()
      : base("One or more authorization failures have occurred.")
    {
      Errors = Array.Empty<ValidationFailure>();
    }

    public AuthorizationException(ValidationFailure[] failures)
      : this()
    {
      Errors = failures;
    }

    public AuthorizationException(string message)
      : base(message)
    {
      Errors = Array.Empty<ValidationFailure>();
    }

    public ValidationFailure[] Errors { get; }
  }
}