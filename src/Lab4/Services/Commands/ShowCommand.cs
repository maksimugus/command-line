using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class ShowCommand : ICommand
{
    public ShowCommand(string source, IReadOnlyDictionary<string, string> flags)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(flags);
        Source = source;
        Flags = flags;
    }

    public string Source { get; }
    public IReadOnlyDictionary<string, string> Flags { get; }

    public void Execute(Context context)
    {
        ArgumentNullException.ThrowIfNull(context);
        Flags.TryGetValue("-m", out string? mode);
        context.Show(Source, mode ?? "console");
    }
}