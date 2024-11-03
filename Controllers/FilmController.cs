using Film3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Film3.Controllers
{
    public class FilmController : Controller
    {
        private static IList<Film> films = new List<Film>
        {
            new Film(){ Id =  1, Name = "Film1", Description = "Opis1", Price = 3 },
            new Film(){ Id =  2, Name = "Film2", Description = "Opis2", Price = 4 },
            new Film(){ Id =  3, Name = "Film3", Description = "Opis3", Price = 5 }
        };

        // GET: FilmController
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            var found = films.FirstOrDefault(x => x.Id == id);
            return View(found);
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            film.Id = films.Count + 1;
            films.Add(film);
            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            var found = films.FirstOrDefault(x => x.Id == id);
            return View(found);
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            var film = films.FirstOrDefault(x => x.Id == id);

            if (film != null)
            {
                film.Name = collection["Name"];
                film.Description = collection["Description"];
                film.Price = int.Parse(collection["Price"]);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            var found = films.FirstOrDefault(x => x.Id == id);
            return View(found);
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var found = films.FirstOrDefault(x => x.Id == id);

            if (found != null)
            {
                films.Remove(found);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
