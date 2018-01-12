using ClothApp.Data.Repositories.Interfaces;
using ClothApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothApp.Data.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _context;

        public BrandRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Brand brand)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brand> GetAll()
        {
            return _context.Brands.ToList();
        }
    }
}