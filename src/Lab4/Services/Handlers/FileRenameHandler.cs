using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class FileRenameHandler : CommandHandler
{
    public override ICommand Handle(IEnumerator<string> iterator)
    {
        ArgumentNullException.ThrowIfNull(iterator);
        if (iterator.Current != "file") return base.Handle(iterator);
        MoveWithCheck(iterator);
        if (iterator.Current != "rename") return base.Handle(iterator);
        MoveWithCheck(iterator);
        string source = iterator.Current;
        MoveWithCheck(iterator);
        string name = iterator.Current;
        if (iterator.MoveNext()) throw new ParsingException();
        return new RenameCommand(source, name);
    }
}