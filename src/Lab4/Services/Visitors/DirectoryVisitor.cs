using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Visitors;

public class DirectoryVisitor : IAbstractionVisitor
{
    private readonly IFileSystem _fileSystem;
    private int _depth;

    public DirectoryVisitor(IFileSystem fileSystem, int depth)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);
        if (depth < 0)
        {
            throw new InvalidValueException(nameof(depth), $"{depth}");
        }

        _fileSystem = fileSystem;
        _depth = depth;
    }

    public void Visit(DirectoryAbstraction directoryAbstraction)
    {
        ArgumentNullException.ThrowIfNull(directoryAbstraction);

        if (_depth == 0)
        {
            return;
        }

        _depth--;

        foreach (IAbstraction e in _fileSystem.GetAbstractions(directoryAbstraction.Path))
        {
            e.Accept(this);
            directoryAbstraction.AddAbstraction(e);
        }

        _depth++;
    }

    public void Visit(FileAbstraction fileAbstraction)
    {
    }
}