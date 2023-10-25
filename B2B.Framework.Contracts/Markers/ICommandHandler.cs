using B2B.Framework.Contracts.Abstracts;

namespace B2B.Framework.Contracts.Makers;

public interface ICommandHandler<C, R> where C : Command where R : CommandResponse
{
    Task<R> Execute(C command, CancellationToken cancellationToken);
}