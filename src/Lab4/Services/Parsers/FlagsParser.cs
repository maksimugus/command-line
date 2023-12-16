using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class FlagsParser : IFlagsParser
{
    public IReadOnlyDictionary<string, string> Parse(IEnumerator<string> iterator)
    {
        ArgumentNullException.ThrowIfNull(iterator);
        var flags = new Dictionary<string, string>();
        while (iterator.Current != null)
        {
            string key = iterator.Current;
            iterator.MoveNext();
            string value = iterator.Current;
            iterator.MoveNext();
            flags.Add(key, value);
        }

        return flags;
    }
}