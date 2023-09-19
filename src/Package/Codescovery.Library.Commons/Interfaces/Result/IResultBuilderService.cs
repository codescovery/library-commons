using Codescovery.Library.Commons.Entities.Result;
using System;

namespace Codescovery.Library.Commons.Interfaces.Result;

public interface IResultBuilderService
{
    IResult<T> Success<T>(T? value = default) => new Result<T>(value);
    IResult<T> Success<T>(string message) => new Result<T>(value: default, message);
    IResult<T> Success<T>(T? value, string message) => new Result<T>(value, message);
    IResult<T> Error<T>(Exception error) => new Result<T>(error);
    IResult<T> Error<T>(Exception error, string message) => new Result<T>(error, message);
    IResult<T> Error<T>(string message) => new Result<T>(new Exception(message), message);
}