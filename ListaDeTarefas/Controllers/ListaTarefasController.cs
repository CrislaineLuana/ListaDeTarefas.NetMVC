using ListaDeTarefas.Data;
using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Controllers
{
    public class ListaTarefasController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ListaTarefasController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ListaTarefas> objListaTarefas = _db.Tarefas;
            return View(objListaTarefas);
        }

        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ListaTarefas obj)
        {

            if(ModelState.IsValid)
            {
                _db.Tarefas.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);

        }


        public IActionResult Update(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Tarefas.Find(id);

            if(obj == null)
            {
                return NotFound();
            }



            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(ListaTarefas obj)
        {
            if(obj == null)
            {
                return NotFound();
            }

            _db.Tarefas.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Tarefas.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(ListaTarefas obj)
        {
            if(obj == null)
            {
                return NotFound();
            }

            _db.Tarefas.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
