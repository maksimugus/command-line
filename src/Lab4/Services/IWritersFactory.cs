namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface IWritersFactory
{
    IWriter GetByName(string name);
}