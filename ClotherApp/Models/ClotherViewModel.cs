using ClotherApp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClotherApp.Models
{
    public class ClotherIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Clother type")]
        public string ClotherTypeName { get; set; }
        [Display(Name = "Brand")]
        public string BrandName { get; set; }

        public ClotherIndexViewModel(Clother clother)
        {
            Id = clother.Id;
            Name = clother.Name;
            ClotherTypeName = clother.ClotherType.Name;
            BrandName = clother.Brand.Name;
        }
    }

    public class ClotherCreateViewModel
    {
        public SelectList ClotherTypes { get; set; }
        public SelectList Brands { get; set; }
        public ClotherCreateForm Form { get; set; }
        public ClotherIdForm FormId { get; set; }
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

        public List<Picture> Pictures { get; set; }
    }

    public class ClotherIdForm
    {
        public int Id { get; set; }
    }
}