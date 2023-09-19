using System;

namespace Codescovery.Library.Commons.Interfaces.Result;

public interface IResult<out T>
{
    bool HasError { get; }
    bool HasValue { get; }
    T Value { get; }
    T? ValueOrDefault { get; }
    Exception? Error { get; }
    string? Message { get; }
}