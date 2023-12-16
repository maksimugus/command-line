using System;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class GotoCommand : ICommand
{
    public GotoCommand(string root)
    {
        ArgumentNullException.ThrowIfNull(root);
        Root = root;
    }

    public string Root { get; }

    public void Execute(Context context)
    {
        ArgumentNullException.ThrowIfNull(context);
        context.GoToDirectory(Root);
    }
}