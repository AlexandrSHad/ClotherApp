using ClotherApp.Data;
using ClotherApp.Data.Repositories.Interfaces;
using ClotherApp.Domain;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClotherApp.Data.Repositories
{
    public class ClotherRepository : IClotherRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Create(Clother clother)
        {
            _context.Clothers.Add(clother);
            _context.SaveChanges();
        }

        public IEnumerable<Clother> GetAll()
        {
            return _context.Clothers.Include(c => c.Brand).Include(c => c.ClotherType);
        }

        public Clother GetById(int id)
        {
            return _context.Clothers.Include(c => c.Pictures).Single(c => c.Id == id);
        }

        public void Update(Clother clother)
        {
            _context.Clothers.Attach(clother);
            _context.Entry(clother).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}