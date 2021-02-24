using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityCoches;

namespace EntityCoches.Controllers
{
    public class CompraVentasController : Controller
    {
        private cochescutresEntities db = new cochescutresEntities();

        // GET: CompraVentas
        public ActionResult Index()
        {
            var compraVentas = db.CompraVentas.Include(c => c.Cliente).Include(c => c.Empleado).Include(c => c.Vehiculo);
            return View(compraVentas.ToList());
        }

        // GET: CompraVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraVenta compraVenta = db.CompraVentas.Find(id);
            if (compraVenta == null)
            {
                return HttpNotFound();
            }
            return View(compraVenta);
        }

        // GET: CompraVentas/Create
        public ActionResult CreateVehiculo()
        {
            IList<string> l = new List<string>();
            l.Add("Compra");
            l.Add("Venta");
            ViewBag.TIPO = l.Select(x => new SelectListItem
            {
                Text = x,
                Value = x
            }).Distinct();
            ViewBag.ID_CLIENTE = new SelectList(db.Clientes, "NIF", "NIF");
            ViewBag.ID_EMPLEADO = new SelectList(db.Empleados, "NIF", "NIF");
            return View();
        }

        // GET: CompraVentas/Create
        public ActionResult Create()
        {
            IList < string > l= new List<string>();
            l.Add("Compra");
            l.Add("Venta");
            ViewBag.TIPO=l.Select(x => new SelectListItem
            {
                Text = x,
                Value = x
            }).Distinct();
            ViewBag.ID_CLIENTE = new SelectList(db.Clientes, "NIF", "NIF");
            ViewBag.ID_EMPLEADO = new SelectList(db.Empleados, "NIF", "NIF");
            return View();
        }

        // POST: CompraVentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CompraVenta,fecha,Precio,tipo,ID_CLIENTE,ID_EMPLEADO")] CompraVenta compraVenta)
        {
            if (ModelState.IsValid)
            {
                db.CompraVentas.Add(compraVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLIENTE = new SelectList(db.Clientes, "ID", "NIF", compraVenta.ID_CLIENTE);
            ViewBag.ID_EMPLEADO = new SelectList(db.Empleados, "ID", "NIF", compraVenta.ID_EMPLEADO);
            return View(compraVenta);
        }

        // GET: CompraVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraVenta compraVenta = db.CompraVentas.Find(id);
            if (compraVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLIENTE = new SelectList(db.Clientes, "ID", "NIF", compraVenta.ID_CLIENTE);
            ViewBag.ID_EMPLEADO = new SelectList(db.Empleados, "ID", "NIF", compraVenta.ID_EMPLEADO);
            return View(compraVenta);
        }

        // POST: CompraVentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CompraVenta,fecha,Precio,tipo,ID_CLIENTE,ID_EMPLEADO")] CompraVenta compraVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compraVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLIENTE = new SelectList(db.Clientes, "ID", "NIF", compraVenta.ID_CLIENTE);
            ViewBag.ID_EMPLEADO = new SelectList(db.Empleados, "ID", "NIF", compraVenta.ID_EMPLEADO);
            return View(compraVenta);
        }

        // GET: CompraVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraVenta compraVenta = db.CompraVentas.Find(id);
            if (compraVenta == null)
            {
                return HttpNotFound();
            }
            return View(compraVenta);
        }

        // POST: CompraVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompraVenta compraVenta = db.CompraVentas.Find(id);
            db.CompraVentas.Remove(compraVenta);
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
