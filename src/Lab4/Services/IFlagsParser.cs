using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface IFlagsParser
{
    IReadOnlyDictionary<string, string> Parse(IEnumerator<string> iterator);
}