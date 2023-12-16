using System;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class MoveCommand : ICommand
{
    public MoveCommand(string source, string destination)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(destination);
        Source = source;
        Destination = destination;
    }

    public string Source { get; }
    public string Destination { get; }

    public void Execute(Context context)
    {
        ArgumentNullException.ThrowIfNull(context);
        context.Move(Source, Destination);
    }
}