using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Writers;

public class ConsoleWriter : IWriter
{
    public void Write(string text)
    {
        Console.Write(text);
    }
}