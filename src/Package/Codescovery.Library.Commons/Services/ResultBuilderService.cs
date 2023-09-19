using Codescovery.Library.Commons.Entities.Result;
using Codescovery.Library.Commons.Interfaces.Result;
using System;

namespace Codescovery.Library.Commons.Services;

internal class ResultBuilderService : IResultBuilderService
{
    public IResult<T> Success<T>(T? value = default) => new Result<T>(value);
    public IResult<T> Success<T>(string message) => new Result<T>(value: default, message);
    public IResult<T> Success<T>(T? value, string message) => new Result<T>(value, message);
    public IResult<T> Error<T>(Exception error) => new Result<T>(error);
    public IResult<T> Error<T>(Exception error, string message) => new Result<T>(error, message);
    public IResult<T> Error<T>(string message) => new Result<T>(new Exception(message), message);
}