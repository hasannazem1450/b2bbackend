using B2B.Application.Contracts.Commands.Product;
using B2B.Framework.Contracts.Markers;


namespace B2B.Application.Contracts.Repository.Product
{
    public interface IProductRepository : IRepository
    {
        Task<Domain.ProductBase.Product> ReadById(int id);

        Task<List<Domain.ProductBase.Product>> Read();

        Task Delete(int id);

        Task Update(Domain.ProductBase.Product product);

        Task Create(Domain.ProductBase.Product product);

        Task<List<Domain.ProductBase.Product>> ReadProductBySmeProfileId(int SmeProfileId);
    }
}
