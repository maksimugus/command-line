using System;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class CopyCommand : ICommand
{
    public CopyCommand(string source, string destination)
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
        context.Copy(Source, Destination);
    }
}