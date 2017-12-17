using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClotherApp.Models
{
    //public class ClotherIndexViewModel
    //{
    //    //public List<ClotherListView>
    //}

    public class ClotherCreateViewModel
    {
        public SelectList ClotherTypes { get; set; }
        public SelectList Brands { get; set; }
        public ClotherCreateForm Form { get; set; }
    }

    public class ClotherCreateForm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Clother type")]
        public int ClotherTypeId { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
    }
}