using AutoMapper;
using RedStarter.Database.Contexts;
using RedStarter.Database.DataContract.Product;
using RedStarter.Database.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
