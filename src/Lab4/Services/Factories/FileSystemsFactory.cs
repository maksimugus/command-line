using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Factories;

public class FileSystemsFactory : IFileSystemsFactory
{
    private readonly Dictionary<string, IFileSystem> _fileSystems;

    public FileSystemsFactory(Dictionary<string, IFileSystem> fileSystems)
    {
        ArgumentNullException.ThrowIfNull(fileSystems);
        _fileSystems = fileSystems;
        fileSystems.Add("disconnected", new DisconnectedFileSystem());
    }

    public IFileSystem GetByName(string name)
    {
        _fileSystems.TryGetValue(name, out IFileSystem? fileSystem);
        return fileSystem ?? throw new InvalidValueException("file system name", name);
    }
}