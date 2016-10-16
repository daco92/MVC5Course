using MVC5Course.Models;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        private FabricsEntities db = new FabricsEntities();

        // GET: EF
        public ActionResult Index()
        {
            var db = new FabricsEntities();
            var data = db.Product.Where(c => c.ProductName.Contains("White"));

            return View(data);
        }

        public ActionResult Create()
        {
            var product = new Product()
            {
                ProductName = "White dog",
                Price = 100,
                Stock = 10,
                Active = true,
            };

            db.Product.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var model = db.Product.Find(id);
            //db.OrderLine.RemoveRange(model.OrderLine);
            //db.Product.Remove(model);
            model.IsDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = db.Product.Find(id);
            return View(model);
        }

        public ActionResult Update(int id)
        {
            var model = db.Product.Find(id);
            model.ProductName += "!";
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eErrors in ex.EntityValidationErrors)
                {
                    foreach (var item in eErrors.ValidationErrors)
                    {
                        throw new DbEntityValidationException(item.PropertyName + "發生錯誤:" + item.ErrorMessage);
                    }

                }


                throw;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Add20Percent()
        {
            var data = db.Product.Where(c => c.ProductName.Contains("White"));
            foreach (var item in data)
            {
                if (item.Price.HasValue)
                {
                    item.Price = item.Price * 1.2m;
                }
            }

           
            return RedirectToAction("Index");
        }
    }
}