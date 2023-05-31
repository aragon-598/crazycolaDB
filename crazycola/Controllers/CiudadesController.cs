using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crazycola.Models;

namespace crazycola.Controllers
{
    public class CiudadesController : Controller
    {
        private crazycolaEntities db = new crazycolaEntities();

        // GET: Ciudades
        public ActionResult Index()
        {
            if (Session["UsuarioId"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            var ciudad = db.Ciudad.Include(c => c.Pais);
            return View(ciudad.ToList());
        }

        // GET: Ciudades/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["UsuarioId"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.Ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // GET: Ciudades/Create
        public ActionResult Create()
        {
            if (Session["UsuarioId"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.PaisId = new SelectList(db.Pais, "PaisId", "Nombre");
            return View();
        }

        // POST: Ciudades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CiudadId,Nombre,PaisId")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Ciudad.Add(ciudad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PaisId = new SelectList(db.Pais, "PaisId", "Nombre", ciudad.PaisId);
            return View(ciudad);
        }

        // GET: Ciudades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["UsuarioId"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.Ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaisId = new SelectList(db.Pais, "PaisId", "Nombre", ciudad.PaisId);
            return View(ciudad);
        }

        // POST: Ciudades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CiudadId,Nombre,PaisId")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaisId = new SelectList(db.Pais, "PaisId", "Nombre", ciudad.PaisId);
            return View(ciudad);
        }

        // GET: Ciudades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UsuarioId"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.Ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ciudad ciudad = db.Ciudad.Find(id);
            db.Ciudad.Remove(ciudad);
            db.SaveChanges();
            return RedirectToAction("Index");
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
