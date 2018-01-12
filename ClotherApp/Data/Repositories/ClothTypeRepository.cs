using ClothApp.Data.Repositories.Interfaces;
using ClothApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothApp.Data.Repositories
{
    public class ClothTypeRepository : IClothTypeRepository
    {
        private readonly AppDbContext _context;

        public ClothTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(ClothType clotherType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClothType> GetAll()
        {
            return _context.ClothTypes.ToList();
        }
    }
}