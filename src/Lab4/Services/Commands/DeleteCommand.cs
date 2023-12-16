using System;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class DeleteCommand : ICommand
{
    public DeleteCommand(string source)
    {
        ArgumentNullException.ThrowIfNull(source);
        Source = source;
    }

    public string Source { get; }

    public void Execute(Context context)
    {
        ArgumentNullException.ThrowIfNull(context);
        context.Delete(Source);
    }
}