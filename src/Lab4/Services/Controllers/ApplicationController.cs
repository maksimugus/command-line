using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Controllers;

public class ApplicationController
{
    private readonly CommandParser _commandParser;
    private readonly Context _context;
    private readonly IWriter _exceptionsWriter;

    public ApplicationController(
        ICommandHandler commandHandler,
        IFileSystemsFactory fileSystemsFactory,
        IWritersFactory writersFactory,
        string exceptionsOutputMode)
    {
        ArgumentNullException.ThrowIfNull(commandHandler);
        ArgumentNullException.ThrowIfNull(fileSystemsFactory);
        ArgumentNullException.ThrowIfNull(writersFactory);
        ArgumentNullException.ThrowIfNull(exceptionsOutputMode);
        _commandParser = new CommandParser(commandHandler);
        _context = new Context(fileSystemsFactory, writersFactory);
        _exceptionsWriter = writersFactory.GetByName(exceptionsOutputMode);
    }

    public void Execute(string command)
    {
        ArgumentNullException.ThrowIfNull(command);
        try
        {
            ICommand c = _commandParser.Parse(command);
            c.Execute(_context);
        }
        catch (Exception e) when (e is FileSystemException or InvalidValueException or ParsingException)
        {
            _exceptionsWriter.Write(e.Message + '\n');
        }
    }
}