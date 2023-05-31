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
            if (Session["UsuarioId"]!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Usuario objUser)
        {
            Console.WriteLine("ANTES DEL IFFFFFFFFFFF");
            try
            {
                using (crazycolaEntities db = new crazycolaEntities())
                {
                    var obj = db.Usuario.Where(a => a.Email.Equals(objUser.Email) && a.Contrasenia.Equals(objUser.Contrasenia)).FirstOrDefault();
                    Console.WriteLine(obj);
                    Content("HOLA");
                    if (obj != null)
                    {
                        Console.WriteLine("ENTREEEEE AL IFFFFFFFFFFFFFFFFF");
                        Session["UsuarioId"] = obj.UsuarioId.ToString();
                        Session["UNombre"] = obj.Nombre.ToString();
                        Session["UApellido"] = obj.Apellido.ToString();
                        Session["UAlmacenId"] = obj.Almacen.AlmacenId.ToString();
                        Session["UAdmin"] = obj.IsAdmin.ToString();
                        return RedirectToAction("Index","Home");
                    }
                
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            string mensaje = "Credenciales incorrectas, vuelve a intentarlo";
            ViewBag.Mensaje = mensaje;
            return View(objUser);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            if (Session["UsuarioId"]!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}