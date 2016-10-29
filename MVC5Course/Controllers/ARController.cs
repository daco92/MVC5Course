using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialViewTest()
        {
            return PartialView();
        }

        public ActionResult ContentResult()
        {
            return Content("Test");
        }

        public ActionResult FileAction()
        {
            var filepath = Server.MapPath("~/Content/ppap.jpg");
            return File(filepath, "image/jpeg");
        }

        public ActionResult FileAction2()
        {
            var filepath = Server.MapPath("~/Content/ppap.jpg");
            return File(filepath, "image/jpeg","ppap_dowload.jpg");
        }

        public ActionResult JsonTest()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.Product.Take(10);

            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}