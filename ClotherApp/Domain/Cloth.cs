using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothApp.Domain
{
    public class Cloth
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClothTypeId { get; set; }
        public ClothType ClothType { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<Picture> Pictures { get; set; }
    }
}