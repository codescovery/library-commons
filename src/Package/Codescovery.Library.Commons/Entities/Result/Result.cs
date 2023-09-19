using Codescovery.Library.Commons.Interfaces.Result;
using System;

namespace Codescovery.Library.Commons.Entities.Result;

internal readonly struct Result<T> : IResult<T>
{
    private readonly T? _value;

    public Result(T? value, string? message = null)
    {
        _value = value;
        Message = message;
    }

    public Result(Exception error, string? message = null)
    {
        Error = error;
        Message = message;
    }

    public bool HasError => Error != null;
    public bool HasValue => _value != null;

    public T Value => _value == null ? throw new InvalidOperationException("Value is null") : _value;
    public T? ValueOrDefault => _value ?? default;
    public Exception? Error { get; }

    public string? Message { get; }
}