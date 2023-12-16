using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class CommandParser
{
    private readonly ICommandHandler _commandHandler;

    public CommandParser(ICommandHandler commandHandler)
    {
        ArgumentNullException.ThrowIfNull(commandHandler);
        _commandHandler = commandHandler;
    }

    public ICommand Parse(string command)
    {
        ArgumentNullException.ThrowIfNull(command);
        IEnumerator<string> iterator = command.Split().ToList().GetEnumerator();
        iterator.MoveNext();
        return _commandHandler.Handle(iterator);
    }
}