using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClotherApp.Domain
{
    public class Clother
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClotherTypeId { get; set; }
        public ClotherType ClotherType { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}