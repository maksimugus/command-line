using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Contexts;

public class Context
{
    private readonly IFileSystemsFactory _fileSystemsFactory;
    private readonly IWritersFactory _writersFactory;
    private IFileSystem _fileSystem;
    private string _rootDirectory;

    public Context(IFileSystemsFactory fileSystemsFactory, IWritersFactory writersFactory)
    {
        ArgumentNullException.ThrowIfNull(fileSystemsFactory);
        ArgumentNullException.ThrowIfNull(writersFactory);
        _fileSystemsFactory = fileSystemsFactory;
        _writersFactory = writersFactory;
        _fileSystem = _fileSystemsFactory.GetByName("disconnected");
        _rootDirectory = string.Empty;
    }

    public void Connect(string root, string mode)
    {
        _fileSystem = _fileSystemsFactory.GetByName(mode);
        GoToDirectory(root);
    }

    public void Disconnect()
    {
        _fileSystem = _fileSystemsFactory.GetByName("disconnected");
    }

    public void GoToDirectory(string path)
    {
        _rootDirectory = GetAbsolutePath(path);
    }

    public void List(int depth, string mode)
    {
        var visitor = new ListVisitor();
        visitor.Visit(CreateRootAbstraction(depth));
        _writersFactory.GetByName(mode).Write(visitor.List);
    }

    public void Show(string source, string mode)
    {
        _writersFactory.GetByName(mode).Write(_fileSystem.GetFileText(GetAbsolutePath(source)));
    }

    public void Move(string source, string destination)
    {
        _fileSystem.MoveFile(GetAbsolutePath(source), GetAbsolutePath(destination));
    }

    public void Copy(string source, string destination)
    {
        _fileSystem.CopyFile(GetAbsolutePath(source), GetAbsolutePath(destination));
    }

    public void Delete(string source)
    {
        _fileSystem.DeleteFile(GetAbsolutePath(source));
    }

    public void Rename(string source, string newName)
    {
        _fileSystem.RenameFile(GetAbsolutePath(source), GetAbsolutePath(newName));
    }

    private DirectoryAbstraction CreateRootAbstraction(int depth)
    {
        var visitor = new DirectoryVisitor(_fileSystem, depth);
        var directory = new DirectoryAbstraction(_rootDirectory, GetNameFromPath(_rootDirectory));
        visitor.Visit(directory);
        return directory;
    }

    private string GetAbsolutePath(string path)
    {
        return _fileSystem.GetAbsolutePath(_rootDirectory, path);
    }

    private string GetNameFromPath(string path)
    {
        return _fileSystem.GetNameFromPath(path);
    }
}