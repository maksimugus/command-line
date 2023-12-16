using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface ICommandHandler
{
    ICommand Handle(IEnumerator<string> iterator);
    public ICommandHandler AddNext(ICommandHandler handler);
}