using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
namespace EcoomerceMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult validate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult validate(string username,string password)
        {
            bool status = Class1.Validate(username, password);
            if(status)
            {
                return RedirectToAction("Index", "Product");
            }
            return View();

        }
    }
}