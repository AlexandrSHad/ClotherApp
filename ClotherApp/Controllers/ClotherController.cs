using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClotherApp.Data;
using ClotherApp.Domain;
using ClotherApp.Models;
using ClotherApp.Services;

namespace ClotherApp.Controllers
{
    public class ClotherController : Controller
    {
        private readonly ClotherService _clotherService = new ClotherService();

        // GET: Clother
        public ActionResult Index()
        {
            var clothers = _clotherService.GetAllClother();
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
            return View(new ClotherCreateViewModel
            {
                ClotherTypes = _clotherService.GetAllClotherTypes().ToSelectList("Id", "Name"),
                Brands = _clotherService.GetAllBrands().ToSelectList("Id", "Name"),
            });
        }

        // POST: Clother/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Form")] ClotherCreateViewModel model)
        {
            _clotherService.CreateClother(new Clother {
                Name = model.Form.Name,
                ClotherTypeId = model.Form.ClotherTypeId,
                BrandId = model.Form.BrandId
            });

            return RedirectToAction("Index");
        }

        // GET: Clother/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clother clother = _clotherService.GetClotherById(id);
            if (clother == null)
            {
                return HttpNotFound();
            }

            return View(new ClotherCreateViewModel {
                ClotherTypes = _clotherService.GetAllClotherTypes().ToSelectList("Id", "Name", clother.ClotherTypeId),
                Brands = _clotherService.GetAllBrands().ToSelectList("Id", "Name", clother.BrandId),
                Form = new ClotherCreateForm
                {
                    Id = clother.Id,
                    Name = clother.Name,
                    BrandId = clother.BrandId,
                    ClotherTypeId = clother.ClotherTypeId,
                    Pictures = clother.Pictures
                },
                FormId = new ClotherIdForm
                {
                    Id = clother.Id
                }
            });
        }

        // POST: Clother/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Form")] ClotherCreateViewModel model)
        {
            _clotherService.UpdateClother(new Clother
            {
                Id = model.Form.Id,
                Name = model.Form.Name,
                ClotherTypeId = model.Form.ClotherTypeId,
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
        public ActionResult UploadPicture([Bind(Include = "FormId")] ClotherCreateViewModel model, HttpPostedFileBase[] uploadImages)
        {
            foreach (var img in uploadImages)
            {
                if (img != null)
                {
                    _clotherService.CreatePictureForClother(model.FormId.Id, img);
                }
            }

            return RedirectToAction("Edit", new { id = model.FormId.Id });
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
