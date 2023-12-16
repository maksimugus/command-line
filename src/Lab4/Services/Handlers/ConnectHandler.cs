using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class ConnectHandler : CommandHandler
{
    private readonly IFlagsParser _flagsParser;

    public ConnectHandler(IFlagsParser flagsParser)
    {
        ArgumentNullException.ThrowIfNull(flagsParser);
        _flagsParser = flagsParser;
    }

    public override ICommand Handle(IEnumerator<string> iterator)
    {
        ArgumentNullException.ThrowIfNull(iterator);
        if (iterator.Current != "connect") return base.Handle(iterator);
        MoveWithCheck(iterator);
        string root = iterator.Current;
        iterator.MoveNext();
        return new ConnectCommand(root, _flagsParser.Parse(iterator));
    }
}