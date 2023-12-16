using Itmo.ObjectOrientedProgramming.Lab4.Entities.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface IAbstractionVisitor
{
    void Visit(DirectoryAbstraction directoryAbstraction);
    void Visit(FileAbstraction fileAbstraction);
}