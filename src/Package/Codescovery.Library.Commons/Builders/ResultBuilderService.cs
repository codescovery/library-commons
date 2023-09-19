using System;
using Codescovery.Library.Commons.Entities.Result;
using Codescovery.Library.Commons.Interfaces.Result;
using Codescovery.Library.Commons.Services;

namespace Codescovery.Library.Commons.Builders;

public class ResultBuilder
{
    public static IResultBuilderService Default() => new ResultBuilderService();

}