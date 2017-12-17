using ClotherApp.Data.Repositories.Interfaces;
using ClotherApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClotherApp.Data.Repositories
{
    public class ClotherTypeRepository : IClotherTypeRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Create(ClotherType clotherType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClotherType> GetAll()
        {
            return _context.ClotherTypes.ToList();
        }
    }
}