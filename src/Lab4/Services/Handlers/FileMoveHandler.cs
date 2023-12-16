using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class FileMoveHandler : CommandHandler
{
    public override ICommand Handle(IEnumerator<string> iterator)
    {
        ArgumentNullException.ThrowIfNull(iterator);
        if (iterator.Current != "file") return base.Handle(iterator);
        MoveWithCheck(iterator);
        if (iterator.Current != "move") return base.Handle(iterator);
        MoveWithCheck(iterator);
        string source = iterator.Current;
        MoveWithCheck(iterator);
        string destination = iterator.Current;
        if (iterator.MoveNext()) throw new ParsingException();
        return new MoveCommand(source, destination);
    }
}