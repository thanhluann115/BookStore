﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Transactions;

namespace WebApplication1.Controllers
{
    public class SANPHAMsController : Controller
    {
        private CT25Team15Entities db = new CT25Team15Entities();

        // GET: SANPHAMs
        public ActionResult Index()
        {
            return View(db.SANPHAMs.ToList());
        }
        public ActionResult Search(string keyword)
        {
            var model = db.SANPHAMs.ToList();
            model = model.Where(p => p.TenSP.ToLower().Contains(keyword.ToLower())).ToList();
            ViewBag.Keyword = keyword; return View("Index2", model);
        }

        public ActionResult Index2()
        {
            var model = db.SANPHAMs.ToList();
            return View(model);
        }

        // GET: SANPHAMs/Details/5
        public ActionResult Details(int MaSP)
        {
           
            var model = db.SANPHAMs.Find(MaSP);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: SANPHAMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost,ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SANPHAM model, HttpPostedFileBase Picture)
        {
            ValidateProduct(model);
            if (ModelState.IsValid)
            {
                if (Picture != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        db.SANPHAMs.Add(model);
                        db.SaveChanges();

                        var path = Server.MapPath(PICTURE_PATH);
                        Picture.SaveAs(path + model.MaSP);
                        
                        scope.Complete();
                        return RedirectToAction("Index");
                    }
                }
                else ModelState.AddModelError("", "Picture not found!!! ");
                
            }

            return View(model); 
        }
        private const string PICTURE_PATH = "~/Upload/Products/";
        public ActionResult picture(int MaSP)
        { 
            var path = Server.MapPath(PICTURE_PATH);
            return File(path + MaSP, "images");
        }
        private void ValidateProduct(SANPHAM model)
        {
            if (model.Gia < 0)
                ModelState.AddModelError("Price", "Price is less than Zero");
        }

        // GET: SANPHAMs/Edit/5
        public ActionResult Edit(int id)
        {
            
            var model = db.SANPHAMs.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: SANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost , ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SANPHAM model, HttpPostedFileBase Picture)
        {
            ValidateProduct(model);
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope())
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();

                    if(Picture != null)
                    {
                        var path = Server.MapPath(PICTURE_PATH);
                        Picture.SaveAs(path + model.MaSP);
                    }    

                    scope.Complete();
                    return RedirectToAction("Index");
                }      
            }
            return View(model);
        }

        // GET: SANPHAMs/Delete/5
        public ActionResult Delete(int MaSP)
        {
            if (MaSP == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.SANPHAMs.Find(MaSP);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        // POST: SANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int MaSP)
        {
            using (var scope = new TransactionScope())
            {
                var model = db.SANPHAMs.Find(MaSP);
                db.SANPHAMs.Remove(model);
                db.SaveChanges();

                var path = Server.MapPath(PICTURE_PATH);
                System.IO.File.Delete(path + model.MaSP);

                scope.Complete();
                return RedirectToAction("Index");
            }
        }
        // SEARCH

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
