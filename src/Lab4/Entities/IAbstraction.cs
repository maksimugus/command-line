using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public interface IAbstraction
{
    string Path { get; }
    string Name { get; }
    void Accept(IAbstractionVisitor visitor);
}