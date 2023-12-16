using Itmo.ObjectOrientedProgramming.Lab4.Services.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface ICommand
{
    void Execute(Context context);
}