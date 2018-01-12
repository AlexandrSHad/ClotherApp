using ClothApp.Data.Repositories.Interfaces;
using ClothApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothApp.Data.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        private readonly AppDbContext _context;

        public PictureRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Picture picture)
        {
            _context.Pictures.Add(picture);
            _context.SaveChanges();
        }
    }
}