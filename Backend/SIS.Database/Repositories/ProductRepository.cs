using AutoMapper;
using PrimePaper.Database.Contexts;
using PrimePaper.Database.DataContract.Product;
using PrimePaper.Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PrimePaper.Database.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SISContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(SISContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateProduct(ProductCreateRAO rao)
        {
            var entity = _mapper.Map<ProductEntity>(rao);
            await _context.ProductTableAccess.AddAsync(entity);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> EditProduct(ProductEditRAO rao)
        {
            var entity = _mapper.Map<ProductEntity>(rao);
            _context.ProductTableAccess.Update(entity);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<ProductGetListItemRAO> GetProductById(int id)
        {
            var query = _context.ProductTableAccess.Single(x => x.ProductEntityId == id);
            var rao = _mapper.Map<ProductGetListItemRAO>(query);
            
            return rao;
        }

        public async Task<IEnumerable<ProductGetListItemRAO>> GetProducts()
        {
            var query = await _context.ProductTableAccess.ToArrayAsync();
            var rao = _mapper.Map<IEnumerable<ProductGetListItemRAO>>(query);

            return rao;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            _context.ProductTableAccess.Remove(_context.ProductTableAccess.Single(x => x.ProductEntityId == id));
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
