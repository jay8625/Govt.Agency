using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Govt.Agency.DAL.Model;
using Govt.Agency.Services.Repositories;
using System.Linq;

namespace Govt._Agency.Controllers
{
    public class CityController : Controller
    {
        private readonly ICity _cityRepo;
        private readonly IState _stateRepo;

        public CityController(ICity cityRepo, IState stateRepo)
        {
            _cityRepo = cityRepo;
            _stateRepo = stateRepo;
        }

        // GET: City
        public IActionResult Index()
        {
            return View(_cityRepo.GetAll());
        }

        // GET: City/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _cityRepo.GetById(id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: City/Create
        public IActionResult Create()
        {
            ViewData["StateId"] = new SelectList(_stateRepo.GetAll(), "Id", "Name");
            return View();
        }

        // POST: City/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,StateId")] City city)
        {
            if (ModelState.IsValid)
            {
                _cityRepo.Add(city);
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_stateRepo.GetAll(), "Id", "Name", city.StateId);
            return View(city);
        }

        // GET: City/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _cityRepo.GetById(id);
            if (city == null)
            {
                return NotFound();
            }
            ViewData["StateId"] = new SelectList(_stateRepo.GetAll(), "Id", "Name", city.StateId);
            return View(city);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,StateId")] City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _cityRepo.Update(city);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_stateRepo.GetAll(), "Id", "Name", city.StateId);
            return View(city);
        }

        // GET: City/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _cityRepo.GetById(id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _cityRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public JsonResult LoadCities(int stateId)
        {
            var cityList=_cityRepo.GetAll();
            var cities =cityList.Where(x => x.StateId == stateId).ToList();
            return Json(new SelectList(cities, "Id", "Name"));
        }

        private bool CityExists(int id)
        {
            return _cityRepo.Any(id);
        }
    }
}
