using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class ParsingException : Exception
{
    public ParsingException()
        : base("invalid command")
    {
    }

    public ParsingException(string? message)
        : base(message)
    {
    }

    public ParsingException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}