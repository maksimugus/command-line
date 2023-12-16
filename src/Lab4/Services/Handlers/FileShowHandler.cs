using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class FileShowHandler : CommandHandler
{
    private readonly IFlagsParser _flagsParser;

    public FileShowHandler(IFlagsParser flagsParser)
    {
        ArgumentNullException.ThrowIfNull(flagsParser);
        _flagsParser = flagsParser;
    }

    public override ICommand Handle(IEnumerator<string> iterator)
    {
        ArgumentNullException.ThrowIfNull(iterator);
        if (iterator.Current != "file") return base.Handle(iterator);
        MoveWithCheck(iterator);
        if (iterator.Current != "show") return base.Handle(iterator);
        MoveWithCheck(iterator);
        string source = iterator.Current;
        iterator.MoveNext();
        return new ShowCommand(source, _flagsParser.Parse(iterator));
    }
}