using B2B.Framework.Contracts.Abstracts;

namespace B2B.Framework.Contracts.Makers;

public interface IDistributor
{
    Task<R> Push<C, R>(C command, CancellationToken cancellationToken) where C : Command where R : CommandResponse;

    Task<R> Send<Q, R>(Q query, CancellationToken cancellationToken) where Q : Query where R : QueryResponse;

}