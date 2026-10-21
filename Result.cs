using System;

public class Result<T>
{
    public T Value { get; }
    public string ErrorMessage { get; }

    public bool IsSuccess => ErrorMessage == null; // Property to check if the operation was successful

    private Result(T value)
    {
        Value = value;
        ErrorMessage = null;
    }

    private Result(string errorMessage)
    {
        Value = default(T);
        ErrorMessage = errorMessage;
    }

    public static Result<T> Success(T value) => new Result<T>(value);
    public static Result<T> Failure(string errorMessage) => new Result<T>(errorMessage);

}
