using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Risk.Models;

namespace Risk.Controllers
{
    public class ProjectDescriptionController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: ProjectDescription
        public ActionResult Index()
        {
            try
            {
                var selected = from r in db.projectDescription
                               where r.USERID == "benktesh@gmail.com"
                               select r;
                return View(selected);
            }
            catch (Exception)
            {

                return null;
            }
            ///return View(db.projectDescription.ToList());
            
        }

        // GET: ProjectDescription/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectDescription projectDescription = db.projectDescription.Find(id);
            if (projectDescription == null)
            {
                return HttpNotFound();
            }
            return View(projectDescription);
        }

        // GET: ProjectDescription/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectDescription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CN,USERID,PROJECTNAME,COUNTRY,LATITUDE,LONGITUDE,POSTALADDRESS,PROJECTSTARTDATE,TIMESTAMP,DATEUPDATED")] ProjectDescription projectDescription)
        {
            if (ModelState.IsValid)
            {
                db.projectDescription.Add(projectDescription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectDescription);
        }

        // GET: ProjectDescription/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectDescription projectDescription = db.projectDescription.Find(id);
            if (projectDescription == null)
            {
                return HttpNotFound();
            }
            return View(projectDescription);
        }

        // POST: ProjectDescription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CN,USERID,PROJECTNAME,COUNTRY,LATITUDE,LONGITUDE,POSTALADDRESS,PROJECTSTARTDATE,TIMESTAMP,DATEUPDATED")] ProjectDescription projectDescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectDescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectDescription);
        }

        // GET: ProjectDescription/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectDescription projectDescription = db.projectDescription.Find(id);
            if (projectDescription == null)
            {
                return HttpNotFound();
            }
            return View(projectDescription);
        }

        // POST: ProjectDescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectDescription projectDescription = db.projectDescription.Find(id);
            db.projectDescription.Remove(projectDescription);
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
