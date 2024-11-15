using Priyank.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Priyank.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students (Index view - List all students)
        public ActionResult Index()
        {
            List<Student> students = StudentRepository.GetAllStudents();
            return View(students);
        }

        // GET: Students/Create (Load the Create view)
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create (Handle Create form submission)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentRepository.AddStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Edit/5 (Load the Edit view)
        public ActionResult Edit(int id)
        {
            Student student = StudentRepository.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5 (Handle Edit form submission)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentRepository.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5 (Load the Delete view)
        public ActionResult Delete(int id)
        {
            Student student = StudentRepository.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5 (Handle Delete form submission)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentRepository.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        // GET: Students/Details/5 (View student details)
        public ActionResult Details(int id)
        {
            Student student = StudentRepository.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
    }
}
