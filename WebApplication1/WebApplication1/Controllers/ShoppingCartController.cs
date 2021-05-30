using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ShoppingCartController : Controller
    {
        private CT25Team15Entities db = new CT25Team15Entities();
        private List<CHITIETGIOHANG> ShoppingCart = null;

        public ShoppingCartController()
        {
            var session = System.Web.HttpContext.Current.Session;
            if (session["ShoppingCart"] != null)
                ShoppingCart = session["ShoppingCart"] as List<CHITIETGIOHANG>;
            else
            {
                ShoppingCart = new List<CHITIETGIOHANG>();
                session["ShoppingCart"] = ShoppingCart;
            }
        }

        // GET: ShoppingCart
        public ActionResult Index()
        {

            return View(ShoppingCart);
        }

      

        // GET: ShoppingCart/Create
        [HttpPost]
        public ActionResult Create(int MaSP, int SoLuong)
        {
            var product = db.SANPHAMs.Find(MaSP);
            ShoppingCart.Add(new CHITIETGIOHANG
            {
                SANPHAM = product,
                MaSP = MaSP

            });
            return RedirectToAction("Index");
        }
       

        // GET: ShoppingCart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETGIOHANG cHITIETGIOHANG = db.CHITIETGIOHANGs.Find(id);
            if (cHITIETGIOHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGH = new SelectList(db.GIOHANGs, "id", "SOLUONG", cHITIETGIOHANG.MaGH);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", cHITIETGIOHANG.MaSP);
            return View(cHITIETGIOHANG);
        }

       

        // GET: ShoppingCart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETGIOHANG cHITIETGIOHANG = db.CHITIETGIOHANGs.Find(id);
            if (cHITIETGIOHANG == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETGIOHANG);
        }


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
