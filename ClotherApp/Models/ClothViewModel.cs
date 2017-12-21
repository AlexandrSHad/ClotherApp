using ClothApp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothApp.Models
{
    public class ClothIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Cloth type")]
        public string ClothTypeName { get; set; }
        [Display(Name = "Brand")]
        public string BrandName { get; set; }

        public ClothIndexViewModel(Cloth cloth)
        {
            Id = cloth.Id;
            Name = cloth.Name;
            ClothTypeName = cloth.ClothType.Name;
            BrandName = cloth.Brand.Name;
        }
    }

    public class ClothCreateViewModel
    {
        public SelectList ClothTypes { get; set; }
        public SelectList Brands { get; set; }
        public ClothCreateForm Form { get; set; }
        public UploadPictureForm UploadPictureForm { get; set; }
    }

    public class ClothCreateForm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Clother type")]
        public int ClothTypeId { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        public List<Picture> Pictures { get; set; }
    }

    public class UploadPictureForm
    {
        public int ClothId { get; set; }
    }
}