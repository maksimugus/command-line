using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CommandsParserTests
{
    private const string TestPath = "testPath";
    private readonly CommandParser _parser;

    public CommandsParserTests()
    {
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
        _parser = new CommandParser(commandHandler);
    }

    [Fact]
    public void ParseConnectTest()
    {
        ICommand result = _parser.Parse($"connect {TestPath} -m local");
        Assert.True(result is ConnectCommand);
        if (result is not ConnectCommand c) return;
        Assert.Equal(TestPath, c.Root);
        Assert.Contains("-m", c.Flags);
        Assert.Equal("local", c.Flags["-m"]);
    }

    [Fact]
    public void ParseDisconnectTest()
    {
        Assert.IsType<DisconnectCommand>(_parser.Parse("disconnect"));
    }

    [Fact]
    public void ParseTreeGotoTest()
    {
        ICommand command = _parser.Parse($"tree goto {TestPath}");
        Assert.True(command is GotoCommand);
        if (command is not GotoCommand c) return;
        Assert.Equal(TestPath, c.Root);
    }

    [Fact]
    public void ParseTreeListTest()
    {
        ICommand command = _parser.Parse("tree list -d 5 -m console");
        Assert.True(command is ListCommand);
        if (command is not ListCommand c) return;
        Assert.Contains("-d", c.Flags);
        Assert.Contains("-m", c.Flags);
        Assert.Equal("5", c.Flags["-d"]);
        Assert.Equal("console", c.Flags["-m"]);
    }

    [Fact]
    public void ParseFileShowTest()
    {
        ICommand command = _parser.Parse($"file show {TestPath} -m console");
        Assert.True(command is ShowCommand);
        if (command is not ShowCommand c) return;
        Assert.Equal(TestPath, c.Source);
        Assert.Contains("-m", c.Flags);
        Assert.Equal("console", c.Flags["-m"]);
    }

    [Fact]
    public void ParseFileMoveTest()
    {
        ICommand command = _parser.Parse($"file move {TestPath} {TestPath}");
        Assert.True(command is MoveCommand);
        if (command is not MoveCommand c) return;
        Assert.Equal(TestPath, c.Source);
        Assert.Equal(TestPath, c.Destination);
    }

    [Fact]
    public void ParseFileCopyTest()
    {
        ICommand command = _parser.Parse($"file copy {TestPath} {TestPath}");
        Assert.True(command is CopyCommand);
        if (command is not CopyCommand c) return;
        Assert.Equal(TestPath, c.Source);
        Assert.Equal(TestPath, c.Destination);
    }

    [Fact]
    public void ParseFileDeleteTest()
    {
        ICommand command = _parser.Parse($"file delete {TestPath}");
        Assert.True(command is DeleteCommand);
        if (command is not DeleteCommand c) return;
        Assert.Equal(TestPath, c.Source);
    }

    [Fact]
    public void ParseFileRenameTest()
    {
        ICommand command = _parser.Parse($"file rename {TestPath} newName");
        Assert.True(command is RenameCommand);
        if (command is not RenameCommand c) return;
        Assert.Equal(TestPath, c.Source);
        Assert.Equal("newName", c.Name);
    }
}