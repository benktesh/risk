using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Risk.Controllers
{
    public class RiskDescriptionController : Controller
    {
        // GET: RiskDescription
        public ActionResult Index()
        {
            return View();
        }

        // GET: RiskDescription/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RiskDescription/Create
        public ActionResult Create()
        {

            Response.Redirect("~/riskInput.aspx");
            return null;
           // var result = new FilePathResult("~/Views/RiskDescription/Create.html", "text/html");
          //  return result;
            
        }

        // POST: RiskDescription/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                Response.Redirect("~/riskInput.aspx");
                return null;
            }
            catch
            {
                return View();
            }
        }

        // GET: RiskDescription/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RiskDescription/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RiskDescription/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RiskDescription/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
