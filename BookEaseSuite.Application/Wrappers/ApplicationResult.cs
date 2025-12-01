namespace BookEaseSuite.Application.Wrappers
{
    public class ApplicationResult<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public IList<Error>? Errors { get; set; }
        public int StatusCode { get; set; }
        public static ApplicationResult<T> Success(T data, string? message, int statusCode)
        {
            return new ApplicationResult<T> { IsSuccess = true, Message = message, Data = data, StatusCode = statusCode };
        }
        public static ApplicationResult<T> Fail(string? message, IList<Error>? errors, int statusCode)
        {
            return new ApplicationResult<T> { IsSuccess = false, Message = message, Errors = errors, StatusCode = statusCode };
        }
    }
    public class ApplicationResult
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public IList<Error>? Errors { get; set; }
        public int StatusCode { get; set; }
        public static ApplicationResult Success(string? message, int statusCode)
        {
            return new ApplicationResult { IsSuccess = true, Message = message, StatusCode = statusCode };
        }
        public static ApplicationResult Fail(string? message, IList<Error>? errors, int statusCode)
        {
            return new ApplicationResult { IsSuccess = false, Message = message, Errors = errors, StatusCode = statusCode };
        }
    }
    public class Error
    {
        public string FieldName { get; set; } = "Error";
        public string Message { get; set; } = string.Empty;

    }
}
