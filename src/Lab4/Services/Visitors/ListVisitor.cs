using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Visitors;

public class ListVisitor : IAbstractionVisitor
{
    private readonly StringBuilder _stringBuilder = new();
    private int _depth;

    public string List => _stringBuilder.ToString();

    public void Visit(DirectoryAbstraction directoryAbstraction)
    {
        ArgumentNullException.ThrowIfNull(directoryAbstraction);
        AddAbstractionToList(directoryAbstraction);

        _depth++;

        foreach (IAbstraction e in directoryAbstraction.Abstractions)
        {
            e.Accept(this);
        }

        _depth--;
    }

    public void Visit(FileAbstraction fileAbstraction)
    {
        ArgumentNullException.ThrowIfNull(fileAbstraction);
        AddAbstractionToList(fileAbstraction);
    }

    private void AddAbstractionToList(IAbstraction abstraction)
    {
        ArgumentNullException.ThrowIfNull(abstraction);
        string offset = string.Concat(Enumerable.Repeat('\t', _depth));
        _stringBuilder.Append(CultureInfo.CurrentCulture, $"{offset}{abstraction.Name}\n");
    }
}