using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class TreeListHandler : CommandHandler
{
    private readonly IFlagsParser _flagsParser;

    public TreeListHandler(IFlagsParser flagsParser)
    {
        ArgumentNullException.ThrowIfNull(flagsParser);
        _flagsParser = flagsParser;
    }

    public override ICommand Handle(IEnumerator<string> iterator)
    {
        ArgumentNullException.ThrowIfNull(iterator);
        if (iterator.Current != "tree") return base.Handle(iterator);
        MoveWithCheck(iterator);
        if (iterator.Current != "list") return base.Handle(iterator);
        iterator.MoveNext();
        return new ListCommand(_flagsParser.Parse(iterator));
    }
}