using ClotherApp.Data.Repositories.Interfaces;
using ClotherApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClotherApp.Data.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

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