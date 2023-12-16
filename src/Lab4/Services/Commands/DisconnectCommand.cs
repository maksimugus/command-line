using System;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class DisconnectCommand : ICommand
{
    public void Execute(Context context)
    {
        ArgumentNullException.ThrowIfNull(context);
        context.Disconnect();
    }
}