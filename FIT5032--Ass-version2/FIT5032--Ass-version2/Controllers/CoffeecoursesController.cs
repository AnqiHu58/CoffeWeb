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
    public class CoffeecoursesController : Controller
    {
        private ModelForRC db = new ModelForRC();

        // GET: Coffeecourses
        public ActionResult Index()
        {
            return View(db.Coffeecourse.ToList());
        }

        // GET: Coffeecourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffeecourse coffeecourse = db.Coffeecourse.Find(id);
            if (coffeecourse == null)
            {
                return HttpNotFound();
            }
            return View(coffeecourse);
        }

        // GET: Coffeecourses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coffeecourses/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Date")] Coffeecourse coffeecourse)
        {

            foreach(Coffeecourse course in db.Coffeecourse.ToList())
            {
                if(course.Date == coffeecourse.Date)
                {
                    return RedirectToAction("BookingConflict");
                }
            }


            if (ModelState.IsValid)
            {
                db.Coffeecourse.Add(coffeecourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coffeecourse);
        }



        public ActionResult BookingConflict()
        {
            return View();
        }

        // GET: Coffeecourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffeecourse coffeecourse = db.Coffeecourse.Find(id);
            if (coffeecourse == null)
            {
                return HttpNotFound();
            }
            return View(coffeecourse);
        }

        // POST: Coffeecourses/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Date")] Coffeecourse coffeecourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffeecourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coffeecourse);
        }

        // GET: Coffeecourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffeecourse coffeecourse = db.Coffeecourse.Find(id);
            if (coffeecourse == null)
            {
                return HttpNotFound();
            }
            return View(coffeecourse);
        }

        // POST: Coffeecourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coffeecourse coffeecourse = db.Coffeecourse.Find(id);
            db.Coffeecourse.Remove(coffeecourse);
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
