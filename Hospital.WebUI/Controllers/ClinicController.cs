using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospital.WebUI.Models;
using JokeCategory;

namespace Hospital.WebUI.Controllers
{
    public class ClinicController : Controller
    {
        private HospitalContext db ;
        private ClinicRepository _repo ;
        public ClinicController()
        {

        }
        public ClinicController(ClinicRepository  clinicRepository)
        {
            _repo = clinicRepository;
        }


        // GET: Clinics
        public async Task<ActionResult> Index()
        {
            
            var result= _repo.GetAll();

            //return View(await db.Clinics.ToListAsync());
            return View(result);
        }

        // GET: Clinics/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = await db.Clinics.FindAsync(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // GET: Clinics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clinics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                db.Clinics.Add(clinic);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(clinic);
        }

        // GET: Clinics/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = await db.Clinics.FindAsync(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // POST: Clinics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clinic).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clinic);
        }

        // GET: Clinics/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = await db.Clinics.FindAsync(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // POST: Clinics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Clinic clinic = await db.Clinics.FindAsync(id);
            db.Clinics.Remove(clinic);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
