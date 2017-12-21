using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothApp.Domain
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public int ClothId { get; set; }
        public Cloth Cloth { get; set; }
    }
}