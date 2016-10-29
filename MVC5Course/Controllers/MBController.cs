using MVC5Course.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index()
        {


            ViewData["Tmp1"] = "暫存資料  tmp1";
            
            ViewBag.Temp2 = "暫存資料  tmp2";

            var b = new ClientLoginViewModel()
            {
                FirstName = "Will",
                LastName = "Huang"
            };

            ViewData["ccc"] = b;

            return View();
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientLoginViewModel c)
        {
            if(ModelState.IsValid)
            {
                TempData["MyForm"] = c;
                return RedirectToAction("ActionResult");
            }
            return View();
        }
        
        public ActionResult ActionResult()
        {

            return View();
        }


        public ActionResult ProductList()
        {
            var data = db.Product.Take(10).ToList();
            return View(data);
        }

        public ActionResult BatchUpdate(List<ProductBatchUpdateViewModel> items)
        {
            if(ModelState.IsValid)
            {
                foreach (var viewitem in items)
                {
                    var model = db.Product.Find(viewitem.ProductId);
                    model.ProductName = viewitem.ProductName;
                    model.Stock = viewitem.Stock;
                    model.Price = viewitem.Price;
                    model.Active = viewitem.Active;
                }
                db.SaveChanges();

                return RedirectToAction("ProductList");
            }

            return View();
        }

    }
}