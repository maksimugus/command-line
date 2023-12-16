using System;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class RenameCommand : ICommand
{
    public RenameCommand(string source, string name)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(name);
        Source = source;
        Name = name;
    }

    public string Source { get; }
    public string Name { get; }

    public void Execute(Context context)
    {
        ArgumentNullException.ThrowIfNull(context);
        context.Rename(Source, Name);
    }
}