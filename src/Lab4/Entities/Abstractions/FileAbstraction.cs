using System;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Abstractions;

public class FileAbstraction : IAbstraction
{
    public FileAbstraction(string path, string name)
    {
        ArgumentNullException.ThrowIfNull(path);
        ArgumentNullException.ThrowIfNull(name);
        Path = path;
        Name = name;
    }

    public string Path { get; }
    public string Name { get; }

    public void Accept(IAbstractionVisitor visitor)
    {
        ArgumentNullException.ThrowIfNull(visitor);
        visitor.Visit(this);
    }
}