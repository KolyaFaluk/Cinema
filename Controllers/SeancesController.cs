using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class SeancesController : Controller
    {
        private CinemaContext db = new CinemaContext();

        // GET: Seances
        public ActionResult Index()
        {
            var seances = db.Seances.Include(s => s.Film);
            return View(seances.ToList());
        }

        // GET: Seances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seance seance = db.Seances.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            return View(seance);
        }

        // GET: Seances/Create
        public ActionResult Create()
        {
            ViewBag.FilmId = new SelectList(db.Films, "Id", "Name");
            return View();
        }

        // POST: Seances/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateTime,PriceTicket,CountTickets,HallId,FilmId")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                db.Seances.Add(seance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmId = new SelectList(db.Films, "Id", "Name", seance.FilmId);
            return View(seance);
        }

        // GET: Seances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seance seance = db.Seances.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmId = new SelectList(db.Films, "Id", "Name", seance.FilmId);
            return View(seance);
        }

        // POST: Seances/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateTime,PriceTicket,CountTickets,HallId,FilmId")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmId = new SelectList(db.Films, "Id", "Name", seance.FilmId);
            return View(seance);
        }

        // GET: Seances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seance seance = db.Seances.Find(id);
            Film film = db.Films.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            return View(seance);
        }

        // POST: Seances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            Seance seance = db.Seances.Find(id);
            db.Seances.Remove(seance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Ticket(int id)
        {

            var filmnames = db.Films.Where(p => p.Id == id);
            List<Film> filmsn = filmnames.ToList();
            ViewBag.FilmName = filmsn[0].Name;

            var datetime = db.Seances.Where(c => c.Id == id);
            List<Seance> vremya = datetime.ToList();
            List<Seance> vremya1 = datetime.ToList();

            ViewBag.DateTime = vremya[0].DateTime.ToShortDateString();
            ViewBag.DateTime1 = vremya1[0].DateTime.ToShortTimeString();

            var priceticket = db.Seances.Where(d => d.Id == id);
            List<Seance> priceticke = priceticket.ToList();
            ViewBag.PriceTicket = priceticke[0].PriceTicket;

            var count = db.Seances.Where(e => e.Id == id);
            List<Seance> countticket = count.ToList();
            ViewBag.CountTickets = countticket[0].CountTickets;
            // Ticket ticket = db.Tickets.Find(id);

            var hall = db.Seances.Where(k => k.Id == id);
            List<Seance> hallid = hall.ToList();
            ViewBag.HallId = hallid[0].HallId;

            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Order(int id, Film film,  Seance seance, Order order, int count)
      public ActionResult Ticket(Seance seance)
        {
            Order order = new Order();

            var Seance = db.Seances.FirstOrDefault(c => c.Id == seance.Id);

            var filmname = db.Films.FirstOrDefault(c => c.Id == Seance.FilmId).Name;
            var price = Seance.PriceTicket;
            var count = Seance.CountTickets;
            var date = Seance.DateTime;
            var orderCount = seance.CountTickets;

            order.SeanceId = seance.Id;
            order.FilmName = filmname;
            order.PriceId = price;
            order.CountId = orderCount;
            order.TimeDate = date;

            db.Orders.Add(order);
            db.SaveChanges();
            return View("Order",db.Orders);
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
