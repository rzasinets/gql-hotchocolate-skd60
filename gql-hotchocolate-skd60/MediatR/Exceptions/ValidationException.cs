namespace gql_hotchocolate_skd60.MediatR.Exceptions
{
  using FluentValidation.Results;

  public class ValidationException : Exception
  {
    public ValidationException()
      : base("One or more validation failures have occurred.")
    {
      Errors = Array.Empty<ValidationFailure>();
    }

    public ValidationException(ValidationFailure[] failures)
      : this()
    {
      Errors = failures;
    }

    public ValidationException(string message)
      : base(message)
    {
      Errors = Array.Empty<ValidationFailure>();
    }

    public ValidationFailure[] Errors { get; }
  }
}