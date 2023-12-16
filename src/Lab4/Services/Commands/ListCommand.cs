using System;
using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class ListCommand : ICommand
{
    public ListCommand(IReadOnlyDictionary<string, string> flags)
    {
        ArgumentNullException.ThrowIfNull(flags);
        Flags = flags;
    }

    public IReadOnlyDictionary<string, string> Flags { get; }

    public void Execute(Context context)
    {
        ArgumentNullException.ThrowIfNull(context);
        Flags.TryGetValue("-d", out string? depth);
        Flags.TryGetValue("-m", out string? mode);
        context.List(StringToInt(depth, 1), mode ?? "console");
    }

    private static int StringToInt(string? str, int defaultValue)
    {
        return str == null ? defaultValue : int.Parse(str, CultureInfo.CurrentCulture);
    }
}