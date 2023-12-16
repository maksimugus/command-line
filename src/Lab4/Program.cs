using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Controllers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var fileSystemFactory = new FileSystemsFactory(new Dictionary<string, IFileSystem>
        {
            { "local", new LocalFileSystem() },
        });
        var writerFactory = new WritersFactory(new Dictionary<string, IWriter>
        {
            { "console", new ConsoleWriter() },
        });
        var flagsParser = new FlagsParser();
        ICommandHandler commandHandler = new ConnectHandler(flagsParser);
        commandHandler
            .AddNext(new DisconnectHandler())
            .AddNext(new TreeListHandler(flagsParser))
            .AddNext(new FileShowHandler(flagsParser))
            .AddNext(new FileMoveHandler())
            .AddNext(new FileCopyHandler())
            .AddNext(new FileDeleteHandler())
            .AddNext(new FileRenameHandler())
            .AddNext(new TreeGotoHandler());
        var controller = new ApplicationController(
            commandHandler,
            fileSystemFactory,
            writerFactory,
            "console");

        while (true)
        {
            string? command = Console.ReadLine();
            if (command == null)
            {
                continue;
            }

            if (command == "exit")
            {
                break;
            }

            controller.Execute(command);
        }
    }
}