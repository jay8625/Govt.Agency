using Microsoft.AspNetCore.Mvc;
using Govt.Agency.DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Govt.Agency.Services.Repositories;

namespace Govt._Agency.Controllers
{
    //Authorize Validation Applied
    [Authorize(Roles = "Admin")]
    public class AgencyTypeController : Controller
    {
        //Services Injected 
        private readonly IAgencyType _agencyType;

        public AgencyTypeController(IAgencyType agencyType)
        {
            _agencyType = agencyType;
        }


        // GET: AgencyType
        public IActionResult Index()
        {
            return View(_agencyType.GetAll());
        }

        // GET: AgencyType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AgencyType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] AgencyType agencyType)
        {
            if (ModelState.IsValid)
            {
                _agencyType.Add(agencyType);
                return RedirectToAction(nameof(Index));
            }
            return View(agencyType);
        }

        // GET: AgencyType/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencyType = _agencyType.GetById(id);
            if (agencyType == null)
            {
                return NotFound();
            }

            return View(agencyType);
        }

        // POST: AgencyType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _agencyType.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        //Any Type Condition
        private bool AgencyTypeExists(int id)
        {
            return _agencyType.Any(id);
        }
    }
}
