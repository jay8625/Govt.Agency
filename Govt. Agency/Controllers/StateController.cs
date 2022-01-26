using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Govt.Agency.DAL.Model;
using Govt.Agency.Services.Repositories;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Govt._Agency.Controllers
{
    //Authorize Validation Applied
    [Authorize(Roles = "Admin")]
    public class StateController : Controller
    {
        //Services Injected
        private readonly IState _stateRepo;
        private readonly ICountry _countryRepo;

        public StateController(IState stateRepo, ICountry countryRepo)
        {
            _stateRepo = stateRepo;
            _countryRepo = countryRepo;
        }

        // GET: State
        public IActionResult Index()
        {
            return View(_stateRepo.GetAll());
        }

        // GET: State/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state =_stateRepo.GetById(id);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // GET: State/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_countryRepo.GetAll(), "Id", "Name");
            return View();
        }

        // POST: State/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,CountryId")] State state)
        {
            if (ModelState.IsValid)
            {
                _stateRepo.Add(state);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_countryRepo.GetAll(), "Id", "Name", state.CountryId);
            return View(state);
        }

        // GET: State/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = _stateRepo.GetById(id);
            if (state == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_countryRepo.GetAll(), "Id", "Name", state.CountryId);
            return View(state);
        }

        // POST: State/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,CountryId")] State state)
        {
            if (id != state.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _stateRepo.Update(state);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StateExists(state.Id))
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
            ViewData["CountryId"] = new SelectList(_countryRepo.GetAll(), "Id", "Name", state.CountryId);
            return View(state);
        }

        // GET: State/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = _stateRepo.GetById(id);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // POST: State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _stateRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        //Anonymous Validation applied
        [AllowAnonymous]
        //Loads States under Country
        public JsonResult LoadStates(int countryId)
        {
            var stateList = _stateRepo.GetAll();
            var states = stateList.Where(x => x.CountryId == countryId).ToList();
            return Json(new SelectList(states, "Id", "Name"));
        }

        //Any State Condition
        private bool StateExists(int id)
        {
            return _stateRepo.Any(id);
        }
    }
}
