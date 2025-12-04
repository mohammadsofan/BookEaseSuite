using BookEaseSuite.Application.Wrappers;

namespace BookEaseSuite.Application.Exceptions
{
    public class ValidationException:Exception
    {
        public List<ValidationError> Errors { get; }
        public ValidationException(List<ValidationError> errors)
            : base("One or more validation errors occurred.")
        {
            Errors = errors;
        }
    }
}
