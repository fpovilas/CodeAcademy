namespace Task1.Model
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }

        public static Result Success(string msg = "") => new() { IsSuccess = true, Message = msg };

        public static Result Failure(string msg = "") => new() { IsSuccess = false, Message = msg };
    }

    public class Result<T> : Result
    {
        public T? Value { get; set; }

        public static Result<T> Success(string msg = "", T? t = default) => new() { IsSuccess = true, Message = msg, Value = t };

        public static new Result<T> Failure(string msg = "") => new() { IsSuccess = false, Message = msg };
    }

    public class ResultList<T> : Result
    {
        public IEnumerable<T>? ListValue { get; set; }

        public static ResultList<T> Success(string msg = "", IEnumerable<T>? t = default) => new() { IsSuccess = true, Message = msg, ListValue = t };

        public static new ResultList<T> Failure(string msg = "") => new() { IsSuccess = false, Message = msg };
    }
}
