using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crazycola.Models;

namespace crazycola.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario objUser)
        {
            Console.WriteLine("ANTES DEL IFFFFFFFFFFF");

                using (crazycolaEntities db = new crazycolaEntities())
                {
                    var obj = db.Usuario.Where(a => a.Email.Equals(objUser.Email) && a.Contrasenia.Equals(objUser.Contrasenia)).FirstOrDefault();
                    Console.WriteLine(obj);
                    Content("HOLA");
                    if (obj != null)
                    {
                    Console.WriteLine("ENTREEEEE AL IFFFFFFFFFFFFFFFFF");
                        Session["UsuarioId"] = obj.UsuarioId.ToString();
                        Session["Email"] = obj.Email.ToString();
                        return RedirectToAction("About","HomeController");
                    }
                
            }
            Console.WriteLine("SIN ENTRAR AL IFFFFFFFFFFF");
            return View(objUser);
        }
    }
}