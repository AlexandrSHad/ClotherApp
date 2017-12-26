using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClothApp.Data;
using ClothApp.Domain;
using ClothApp.Models;
using ClothApp.Services;

namespace ClothApp.Controllers
{
    public class ClothController : Controller
    {
        private readonly ClothService _clotherService = new ClothService();

        // GET: Clother
        public ActionResult Index()
        {
            var clothers = _clotherService.GetAllClothes().Select(s => new ClothIndexViewModel(s));
            return View(clothers.ToList());
        }

        //// GET: Clother/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Clother clother = db.Clothers.Find(id);
        //    if (clother == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(clother);
        //}

        // GET: Clother/Create
        public ActionResult Create()
        {
            return View(new ClothCreateViewModel
            {
                ClothTypes = _clotherService.GetAllClothTypes().ToSelectList("Id", "Name"),
                Brands = _clotherService.GetAllBrands().ToSelectList("Id", "Name"),
            });
        }

        // POST: Clother/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Form")] ClothCreateViewModel model, HttpPostedFileBase[] uploadImages)
        {
            var pictures = _clotherService.GetPicturesList(uploadImages);

            var cloth = new Cloth
            {
                Name = model.Form.Name,
                ClothTypeId = model.Form.ClothTypeId,
                BrandId = model.Form.BrandId,
                Pictures = pictures
            };

            _clotherService.CreateCloth(cloth);

            return RedirectToAction("Index");
        }

        // GET: Clother/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cloth clother = _clotherService.GetClothById(id);
            if (clother == null)
            {
                return HttpNotFound();
            }

            return View(new ClothCreateViewModel {
                ClothTypes = _clotherService.GetAllClothTypes().ToSelectList("Id", "Name", clother.ClothTypeId),
                Brands = _clotherService.GetAllBrands().ToSelectList("Id", "Name", clother.BrandId),
                Form = new ClothCreateForm
                {
                    Id = clother.Id,
                    Name = clother.Name,
                    BrandId = clother.BrandId,
                    ClothTypeId = clother.ClothTypeId,
                    Pictures = clother.Pictures
                },
                UploadPictureForm = new UploadPictureForm
                {
                    ClothId = clother.Id
                }
            });
        }

        // POST: Clother/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Form")] ClothCreateViewModel model)
        {
            _clotherService.UpdateCloth(new Cloth
            {
                Id = model.Form.Id,
                Name = model.Form.Name,
                ClothTypeId = model.Form.ClothTypeId,
                BrandId = model.Form.BrandId
            });

            return RedirectToAction("Index");
        }

        //// GET: Clother/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Clother clother = db.Clothers.Find(id);
        //    if (clother == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(clother);
        //}

        //// POST: Clother/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Clother clother = db.Clothers.Find(id);
        //    db.Clothers.Remove(clother);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult UploadPicture([Bind(Include = "UploadPictureForm")] ClothCreateViewModel model, HttpPostedFileBase[] uploadImages)
        {
            _clotherService.CreatePicturesForCloth(model.UploadPictureForm.ClothId, uploadImages);

            return RedirectToAction("Edit", new { id = model.UploadPictureForm.ClothId });
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
