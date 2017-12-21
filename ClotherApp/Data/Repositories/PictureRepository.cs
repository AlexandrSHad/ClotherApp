using ClotherApp.Data.Repositories.Interfaces;
using ClotherApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClotherApp.Data.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Create(Picture picture)
        {
            _context.Pictures.Add(picture);
            _context.SaveChanges();
        }
    }
}