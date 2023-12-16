using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class ConnectCommand : ICommand
{
    public ConnectCommand(string root, IReadOnlyDictionary<string, string> flags)
    {
        ArgumentNullException.ThrowIfNull(root);
        ArgumentNullException.ThrowIfNull(flags);
        Root = root;
        Flags = flags;
    }

    public string Root { get; }

    public IReadOnlyDictionary<string, string> Flags { get; }

    public void Execute(Context context)
    {
        ArgumentNullException.ThrowIfNull(context);
        Flags.TryGetValue("-m", out string? mode);
        context.Connect(Root, mode ?? "local");
    }
}