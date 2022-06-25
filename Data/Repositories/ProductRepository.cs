using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories{
    public class ProductRepository: IProductRepository{

        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            this._context = context;
        }

        public bool Delete(int idT)
        {
            var product = _context.Products.FirstOrDefault(i => i.Id == idT);
            if (product == null)
                return false;
            else
            {
                _context.Products.Remove(product);
                return true;
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Save(Product t) => _context.Add(t);


        public void Update(Product t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}