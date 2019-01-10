using AutoMapper;
using RedStarter.Database.Contexts;
using RedStarter.Database.DataContract.Product;
using RedStarter.Database.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedStarter.Business.DataContract.Product;

namespace RedStarter.Database.Product
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
            var entity = _context.ProductTableAccess.Single(x => x.ProductEntityId == rao.ProductEntityId);
            entity.ProductName = rao.ProductName;
            entity.Description = rao.Description;
            entity.Price = rao.Price;

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
