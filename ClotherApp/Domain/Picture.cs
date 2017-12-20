using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClotherApp.Domain
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public int ClotherId { get; set; }
        public Clother Clother { get; set; }
    }
}