using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Abstractions;

public class DirectoryAbstraction : IAbstraction
{
    private readonly List<IAbstraction> _abstractions = new();

    public DirectoryAbstraction(string path, string name)
    {
        ArgumentNullException.ThrowIfNull(path);
        ArgumentNullException.ThrowIfNull(name);
        Path = path;
        Name = name;
    }

    public string Path { get; }
    public string Name { get; }

    public IEnumerable<IAbstraction> Abstractions => _abstractions;

    public void AddAbstraction(IAbstraction abstraction)
    {
        ArgumentNullException.ThrowIfNull(abstraction);
        _abstractions.Add(abstraction);
    }

    public void Accept(IAbstractionVisitor visitor)
    {
        ArgumentNullException.ThrowIfNull(visitor);
        visitor.Visit(this);
    }
}