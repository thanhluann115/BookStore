using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DonHangController : Controller
    {
        private CT25Team15Entities db = new CT25Team15Entities();
        private List<CHITIETGIOHANG> ShoppingCart = null;
        public void ShoppingCartController()
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

        // GET: DonHang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ShoppingCartController();
            ViewBag.Cart = ShoppingCart;
            return View();

        }
    }
}