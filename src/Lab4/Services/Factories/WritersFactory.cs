using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Factories;

public class WritersFactory : IWritersFactory
{
    private readonly IDictionary<string, IWriter> _writers;

    public WritersFactory(IDictionary<string, IWriter> writers)
    {
        ArgumentNullException.ThrowIfNull(writers);
        _writers = writers;
    }

    public IWriter GetByName(string name)
    {
        _writers.TryGetValue(name, out IWriter? writer);
        return writer ?? throw new InvalidValueException("writer name", name);
    }
}