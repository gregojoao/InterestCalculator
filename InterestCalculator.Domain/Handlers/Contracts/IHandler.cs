using InterestCalculator.Domain.Commands.Contracts;

namespace InterestCalculator.Domain.Handlers.Contracts;

public interface IHandler<T> where T : ICommand
{
    Task<ICommandResult> Handle(T command, CancellationToken cancellationToken);
}