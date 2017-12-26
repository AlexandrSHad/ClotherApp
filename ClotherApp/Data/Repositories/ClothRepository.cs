using ClothApp.Data;
using ClothApp.Data.Repositories.Interfaces;
using ClothApp.Domain;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothApp.Data.Repositories
{
    public class ClothRepository : IClothRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Create(Cloth clother)
        {
            _context.Clothes.Add(clother);
            _context.SaveChanges();
        }

        public IEnumerable<Cloth> GetAll()
        {
            return _context.Clothes.Include(c => c.Brand).Include(c => c.ClothType).ToList();
        }

        public Cloth GetById(int id)
        {
            return _context.Clothes.Include(c => c.Pictures).Single(c => c.Id == id);
        }

        public void Update(Cloth clother)
        {
            _context.Clothes.Attach(clother);
            _context.Entry(clother).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}