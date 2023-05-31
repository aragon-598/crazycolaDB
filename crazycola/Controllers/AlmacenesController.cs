using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crazycola.Models;

namespace crazycola.Controllers
{
    public class AlmacenesController : Controller
    {
        private crazycolaEntities db = new crazycolaEntities();

        // GET: Almacenes
        public ActionResult Index()
        {
            if (Session["UsuarioId"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            var query = "select * from crazycola.dbo.Almacen a where a.AlmacenId = @param";
            var userAlmacenId = int.Parse(Session["UAlmacenId"].ToString());
            var listaAlmacenes = db.Almacen.SqlQuery(query, new SqlParameter("param", userAlmacenId));
            //var almacen = db.Almacen.Include(a => a.Ciudad);
            return View(listaAlmacenes.ToList());
        }

        // GET: Almacenes/Details/5
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
            Almacen almacen = db.Almacen.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            return View(almacen);
        }

        // GET: Almacenes/Create
        public ActionResult Create()
        {
            if (Session["UsuarioId"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.CiudadId = new SelectList(db.Ciudad, "CiudadId", "Nombre");
            return View();
        }

        // POST: Almacenes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlmacenId,Nombre,Direccion,CiudadId")] Almacen almacen)
        {
            if (ModelState.IsValid)
            {
                db.Almacen.Add(almacen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CiudadId = new SelectList(db.Ciudad, "CiudadId", "Nombre", almacen.CiudadId);
            return View(almacen);
        }

        // GET: Almacenes/Edit/5
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
            Almacen almacen = db.Almacen.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            ViewBag.CiudadId = new SelectList(db.Ciudad, "CiudadId", "Nombre", almacen.CiudadId);
            return View(almacen);
        }

        // POST: Almacenes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlmacenId,Nombre,Direccion,CiudadId")] Almacen almacen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(almacen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CiudadId = new SelectList(db.Ciudad, "CiudadId", "Nombre", almacen.CiudadId);
            return View(almacen);
        }

        // GET: Almacenes/Delete/5
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
            Almacen almacen = db.Almacen.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            return View(almacen);
        }

        // POST: Almacenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Almacen almacen = db.Almacen.Find(id);
            db.Almacen.Remove(almacen);
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
