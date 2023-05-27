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
    public class AlmacenProductosController : Controller
    {
        private crazycolaEntities db = new crazycolaEntities();

        // GET: AlmacenProductos
        public ActionResult Index()
        {
            var almacenProducto = db.AlmacenProducto.Include(a => a.Almacen).Include(a => a.Producto);
            return View(almacenProducto.ToList());
        }

        // GET: AlmacenProductos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlmacenProducto almacenProducto = db.AlmacenProducto.Find(id);
            if (almacenProducto == null)
            {
                return HttpNotFound();
            }
            return View(almacenProducto);
        }

        // GET: AlmacenProductos/Create
        public ActionResult Create()
        {
            ViewBag.AlmacenId = new SelectList(db.Almacen, "AlmacenId", "Nombre");
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Nombre");
            return View();
        }

        // POST: AlmacenProductos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlmacenProductoId,AlmacenId,ProductoId,Stock")] AlmacenProducto almacenProducto)
        {
            if (ModelState.IsValid)
            {
                db.AlmacenProducto.Add(almacenProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlmacenId = new SelectList(db.Almacen, "AlmacenId", "Nombre", almacenProducto.AlmacenId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Nombre", almacenProducto.ProductoId);
            return View(almacenProducto);
        }

        // GET: AlmacenProductos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlmacenProducto almacenProducto = db.AlmacenProducto.Find(id);
            if (almacenProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlmacenId = new SelectList(db.Almacen, "AlmacenId", "Nombre", almacenProducto.AlmacenId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Nombre", almacenProducto.ProductoId);
            return View(almacenProducto);
        }

        // POST: AlmacenProductos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlmacenProductoId,AlmacenId,ProductoId,Stock")] AlmacenProducto almacenProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(almacenProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlmacenId = new SelectList(db.Almacen, "AlmacenId", "Nombre", almacenProducto.AlmacenId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Nombre", almacenProducto.ProductoId);
            return View(almacenProducto);
        }

        // GET: AlmacenProductos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlmacenProducto almacenProducto = db.AlmacenProducto.Find(id);
            if (almacenProducto == null)
            {
                return HttpNotFound();
            }
            return View(almacenProducto);
        }

        // POST: AlmacenProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlmacenProducto almacenProducto = db.AlmacenProducto.Find(id);
            db.AlmacenProducto.Remove(almacenProducto);
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
