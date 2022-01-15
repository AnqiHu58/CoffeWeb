using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032__Ass_version2.Models;

namespace FIT5032__Ass_version2.Controllers
{
    public class EvaluationsController : Controller
    {
        private ModelForRC db = new ModelForRC();
        public static Evaluation eva = new Evaluation();

        // GET: Evaluations
        public ActionResult Index()
        {


            return View(db.Evaluation.ToList());
        }


        public ActionResult Rate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation evaluation = db.Evaluation.Find(id);
            eva = evaluation;
            if (evaluation == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> dropdownlist = new List<SelectListItem>();
            dropdownlist.Add(new SelectListItem() { Text = "Close ASAP (20)", Value = "20", Selected = false });
            dropdownlist.Add(new SelectListItem() { Text = "NEED IMPROVEMENT (40) ", Value = "40", Selected = false });
            dropdownlist.Add(new SelectListItem() { Text = "NOT BAD (60)", Value = "60", Selected = false });
            dropdownlist.Add(new SelectListItem() { Text = "GOOD JOB (80)", Value = "80", Selected = false });
            dropdownlist.Add(new SelectListItem() { Text = "PERFECT! (100)", Value = "100", Selected = true });

            ViewBag.DROPDOWNLIST = dropdownlist;



            return View(evaluation);
        }

        [HttpPost]
        public ActionResult Rate(FormCollection form)
        {
            string rate = form["DROPDOWNLIST"];
            int ratenumer = 0;
            int.TryParse(rate, out ratenumer);
            double DOUBLE = double.Parse(eva.Rate);
            double NEWRATE = (DOUBLE * eva.Rate_num + ratenumer) / (eva.Rate_num + 1);
          
            eva.Rate = String.Format("{0:F}", NEWRATE);
            eva.Rate_num++;


            if (ModelState.IsValid)
            {
                db.Entry(eva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(eva);
        }








        // GET: Evaluations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation evaluation = db.Evaluation.Find(id);
            if (evaluation == null)
            {
                return HttpNotFound();
            }
            return View(evaluation);
        }

        // GET: Evaluations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evaluations/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rate,Rate_num")] Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                db.Evaluation.Add(evaluation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evaluation);
        }

        // GET: Evaluations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation evaluation = db.Evaluation.Find(id);
            if (evaluation == null)
            {
                return HttpNotFound();
            }
            return View(evaluation);
        }

        // POST: Evaluations/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rate,Rate_num")] Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evaluation);
        }

        // GET: Evaluations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation evaluation = db.Evaluation.Find(id);
            if (evaluation == null)
            {
                return HttpNotFound();
            }
            return View(evaluation);
        }

        // POST: Evaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluation evaluation = db.Evaluation.Find(id);
            db.Evaluation.Remove(evaluation);
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
