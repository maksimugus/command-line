using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public string GetFileText(string source)
    {
        try
        {
            return File.ReadAllText(source);
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message);
        }
    }

    public void MoveFile(string source, string destination)
    {
        try
        {
            File.Move(source, GetAbsolutePath(destination, GetNameFromPath(source)));
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message);
        }
    }

    public void CopyFile(string source, string destination)
    {
        try
        {
            File.Copy(source, GetAbsolutePath(destination, GetNameFromPath(source)));
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message);
        }
    }

    public void DeleteFile(string source)
    {
        try
        {
            File.Delete(source);
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message);
        }
    }

    public void RenameFile(string source, string name)
    {
        try
        {
            File.Move(source, name);
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message);
        }
    }

    public IEnumerable<IAbstraction> GetAbstractions(string source)
    {
        var abstractions = new List<IAbstraction>();
        try
        {
            abstractions.AddRange(Directory.EnumerateDirectories(source)
                .Select(path => new DirectoryAbstraction(path, GetNameFromPath(path))));

            abstractions.AddRange(Directory.EnumerateFiles(source)
                .Select(path => new FileAbstraction(path, GetNameFromPath(path))));
            return abstractions;
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message);
        }
    }

    public string GetNameFromPath(string path)
    {
        try
        {
            return Path.GetFileName(path);
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message);
        }
    }

    public string GetAbsolutePath(string root, string source)
    {
        try
        {
            return Path.Exists(source) ? source : Path.Join(root, source);
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message);
        }
    }
}