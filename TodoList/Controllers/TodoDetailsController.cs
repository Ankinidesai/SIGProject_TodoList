using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TodoDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TodoDetails
        public ActionResult Index()
        {
            //this will get us the current user
            //string currentUserId = User.Identity.GetUserId();
            //ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);//looking into db
            return View();// db.todoDetails.ToList().Where(x=>x.User==currentUser));
        }

        private IEnumerable<TodoDetail> getMytodos()
        {
             string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);//looking into db
            IEnumerable<TodoDetail> mytodo = db.todoDetails.ToList().Where(x => x.User == currentUser);
            //for complete percentage
            int count = 0;
            foreach(TodoDetail todoDetail in mytodo)
            {
                count++;
            }

            return mytodo;
        }

        public ActionResult tabView()
        {
            //this will get us the current user

            //string currentUserId = User.Identity.GetUserId();
            //ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);//looking into db
            //getting the list of todos for the user that is currently logged in the application

            return PartialView("_tabView", getMytodos());//,db.todoDetails.ToList().Where(x => x.User == currentUser));
        }


        public ActionResult allTodos()
        {
            return View(db.todoDetails.ToList());
        }

        // GET: TodoDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoDetail todoDetail = db.todoDetails.Find(id);
            if (todoDetail == null)
            {
                return HttpNotFound();
            }
            return View(todoDetail);
        }

        // GET: TodoDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,Isdone")] TodoDetail todoDetail)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x=>x.Id==currentUserId);
                todoDetail.User = currentUser;


                db.todoDetails.Add(todoDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todoDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate([Bind(Include = "ID,Description")] TodoDetail todoDetail)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
                todoDetail.User = currentUser;
                todoDetail.Isdone = false;//because we have just created

                db.todoDetails.Add(todoDetail);
                db.SaveChanges();
                //return RedirectToAction("Index"); //no need to redirect but we will return the partial view
                return PartialView("_tabView", getMytodos());
            }

            return View(todoDetail);
        }

        // GET: TodoDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoDetail todoDetail = db.todoDetails.Find(id);
            if (todoDetail == null)
            {
                return HttpNotFound();
            }

            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);//looking into db
            
            if(todoDetail.User!=currentUser)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(todoDetail);
        }

        // POST: TodoDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for runs when we click save
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,Isdone")] TodoDetail todoDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todoDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoDetail);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AjaxEdit(int? id, bool value)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoDetail todoDetail = db.todoDetails.Find(id);
            if (todoDetail == null)
            {
                return HttpNotFound();
            }
            else
            {
                todoDetail.Isdone = value;
                db.Entry(todoDetail).State = EntityState.Modified; //looks the todo and modifies the changes
                db.SaveChanges();
                return PartialView("_tabView", getMytodos());
            }

            //if (ModelState.IsValid)
            //{
            //    db.Entry(todoDetail).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(todoDetail);
        }

        // GET: TodoDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoDetail todoDetail = db.todoDetails.Find(id);
            if (todoDetail == null)
            {
                return HttpNotFound();
            }
            return View(todoDetail);
        }

        // POST: TodoDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TodoDetail todoDetail = db.todoDetails.Find(id);
            db.todoDetails.Remove(todoDetail);
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
