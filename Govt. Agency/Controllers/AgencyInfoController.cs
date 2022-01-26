using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Govt.Agency.Services.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Govt.Agency.DAL.Model;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Govt._Agency.Controllers
{
    [Authorize]
    public class AgencyInfoController : Controller
    {
        private readonly IAngencyInfo _angencyInfoRepo;
        private readonly ICountry _countryRepo;
        private readonly IAgencyType _agencyTypeRepo;


        public AgencyInfoController(IAngencyInfo angencyInfoRepo, ICountry countryRepo, IAgencyType agencyTypeRepo)
        {
            _angencyInfoRepo = angencyInfoRepo;
            _countryRepo = countryRepo;
            _agencyTypeRepo = agencyTypeRepo;
        }


        [Authorize(Roles = "Admin")]
        // GET: AgencyInfo
        public IActionResult Index(string searchBy, string search)
        {
            var agency = _angencyInfoRepo.GetAllViews().ToList();
            if (search != null)
            {
                if (searchBy == "Name")
                {
                    string srcname = search.ToLower();
                    agency = agency.Where(x => x.Name.ToLower().Contains(srcname)).ToList();
                    return View(agency);
                }
                if (searchBy == "Phone")
                {
                    string srcname = search.ToLower();
                    agency = agency.Where(x => x.phone.Contains(srcname)).ToList();
                    return View(agency);
                }
                if (searchBy == "Email")
                {
                    string srcname = search.ToLower();
                    agency = agency.Where(x => x.Email.ToLower().Contains(srcname)).ToList();
                    return View(agency);
                }
                if (searchBy == "Address")
                {
                    string srcname = search.ToLower();
                    agency = agency.Where(x => x.Address.ToLower().Contains(srcname)).ToList();
                    return View(agency);
                }
            }
            return View(agency);
        }

        [HttpGet]
        public PartialViewResult SideNav()
        {
            return PartialView();
        }

        // GET: AgencyInfo/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencyInfo = _angencyInfoRepo.GetById(id);
            if (agencyInfo == null)
            {
                return NotFound();
            }

            return View(agencyInfo);
        }

        // GET: AgencyInfo/Create
        public IActionResult Create()
        {
            ViewBag.Countries = new SelectList(_countryRepo.GetAll(), "Id", "Name");
            ViewBag.AgencyTypes = new SelectList(_agencyTypeRepo.GetAll(), "Id", "Name");
            return View();
        }

        // POST: AgencyInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Address,City,Name,PostalCode,Country,State,Email,OfficePhone,PhoneNumber,GovtImage,Type,JurisdictionalBoundaries,Description,Broucher,AidOrganization,BroucherCopy,Comments,Notify,DocumentAttachment")] AgencyInfo agencyInfo)
        {
            if (ModelState.IsValid)
            {
                _angencyInfoRepo.Add(agencyInfo);
                return RedirectToAction(nameof(Index));
            }
            return View(agencyInfo);
        }

        // GET: AgencyInfo/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencyInfo = _angencyInfoRepo.GetById(id);
            if (agencyInfo == null)
            {
                return NotFound();
            }
            return View(agencyInfo);
        }

        // POST: AgencyInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Address,City,Name,PostalCode,Country,State,Email,OfficePhone,PhoneNumber,GovtImage,Type,JurisdictionalBoundaries,Description,Broucher,AidOrganization,BroucherCopy,Comments,Notify,DocumentAttachment")] AgencyInfo agencyInfo)
        {
            if (id != agencyInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _angencyInfoRepo.Update(agencyInfo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgencyInfoExists(agencyInfo.Id))
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
            return View(agencyInfo);
        }

        // GET: AgencyInfo/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencyInfo = _angencyInfoRepo.GetById(id);
            if (agencyInfo == null)
            {
                return NotFound();
            }

            return View(agencyInfo);
        }

        // POST: AgencyInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _angencyInfoRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AgencyInfoExists(int id)
        {
            return _angencyInfoRepo.Any(id);
        }
    }
}
