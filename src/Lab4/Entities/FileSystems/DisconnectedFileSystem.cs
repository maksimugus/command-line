using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class DisconnectedFileSystem : IFileSystem
{
    public string GetFileText(string source)
    {
        throw new FileSystemException("file system is disconnected");
    }

    public void MoveFile(string source, string destination)
    {
        throw new FileSystemException("file system is disconnected");
    }

    public void CopyFile(string source, string destination)
    {
        throw new FileSystemException("file system is disconnected");
    }

    public void DeleteFile(string source)
    {
        throw new FileSystemException("file system is disconnected");
    }

    public void RenameFile(string source, string name)
    {
        throw new FileSystemException("file system is disconnected");
    }

    public IEnumerable<IAbstraction> GetAbstractions(string source)
    {
        throw new FileSystemException("file system is disconnected");
    }

    public string GetNameFromPath(string path)
    {
        throw new FileSystemException("file system is disconnected");
    }

    public string GetAbsolutePath(string root, string source)
    {
        throw new FileSystemException("file system is disconnected");
    }
}