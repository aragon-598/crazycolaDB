using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crazycola.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UsuarioId"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            //string mensaje = "Hola desde ASP.NET";
            ViewBag.Mensaje = Session["UsuarioId"];
            return View();
        }

        public ActionResult About()
        {
            if (Session["UsuarioId"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (Session["UsuarioId"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}