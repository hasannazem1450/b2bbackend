using B2B.Application.Contracts.Repository.Product;
using B2B.CommandDB;
using B2B.Domain.ProductBase;
using Microsoft.EntityFrameworkCore;

namespace B2B.CommandDb.Repository.Product
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<Domain.ProductBase.Product> ReadById(int id)
        {
            var result = await _Db.Products.FirstOrDefaultAsync(s => s.Id == id);

            return result;
        }

        public async Task<List<Domain.ProductBase.Product>> Read()
        {
            var result = await _Db.Products.ToListAsync();

            return result;
        }

        public async Task Delete(int id)
        {
            var product = await _Db.Products.FirstOrDefaultAsync(s => s.Id == id);

            _Db.Products.Remove(product);

            await _Db.SaveChangesAsync();
        }

        public async Task Update(Domain.ProductBase.Product product)
        {
            var result = await _Db.Products.FirstOrDefaultAsync(s => s.Id == product.Id);

            //result.Name = smeMember.Name;
            //result.ProfilePhoto = smeMember.ProfilePhoto;
            //result.SmeProfileId = smeMember.SmeProfileId;
            //result.PositionId = smeMember.PositionId;

            _Db.Products.Update(result);

            await _Db.SaveChangesAsync();
        }

        public async Task Create(Domain.ProductBase.Product product)
        {
            await _Db.Products.AddAsync(product);
        }

        public async Task<List<Domain.ProductBase.Product>> ReadProductBySmeProfileId(int SmeProfileId) 
        {
            var result = await _Db.Products.Where(s => s.SmeProfileId == SmeProfileId).ToListAsync();

            return result;
        }
    }
}
