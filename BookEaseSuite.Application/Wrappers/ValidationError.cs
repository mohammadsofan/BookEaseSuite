namespace BookEaseSuite.Application.Wrappers
{
    public class ValidationError
    {
        private readonly string _PropertyName;
        private readonly string _ErrorMessage;

        public ValidationError(string propertyName, string errorMessage)
        {
            _PropertyName = propertyName;
            _ErrorMessage = errorMessage;
        }
        public string PropertyName => _PropertyName;
        public string ErrorMessage => _ErrorMessage;
    }
}