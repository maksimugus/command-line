using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class FileDeleteHandler : CommandHandler
{
    public override ICommand Handle(IEnumerator<string> iterator)
    {
        ArgumentNullException.ThrowIfNull(iterator);
        if (iterator.Current != "file") return base.Handle(iterator);
        MoveWithCheck(iterator);
        if (iterator.Current != "delete") return base.Handle(iterator);
        MoveWithCheck(iterator);
        string source = iterator.Current;
        if (iterator.MoveNext()) throw new ParsingException();
        return new DeleteCommand(source);
    }
}