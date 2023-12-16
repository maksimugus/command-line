using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public abstract class CommandHandler : ICommandHandler
{
    private ICommandHandler? _next;

    public virtual ICommand Handle(IEnumerator<string> iterator)
    {
        ArgumentNullException.ThrowIfNull(iterator);
        if (_next is null)
        {
            throw new ParsingException();
        }

        iterator.Reset();
        iterator.MoveNext();
        return _next.Handle(iterator);
    }

    public ICommandHandler AddNext(ICommandHandler handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        _next = handler;
        return _next;
    }

    protected static void MoveWithCheck(IEnumerator<string> iterator)
    {
        ArgumentNullException.ThrowIfNull(iterator);
        if (!iterator.MoveNext()) throw new ParsingException();
    }
}