using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Govt.Agenct.DAL.Model;
using Govt.Agency.Services.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Govt.Agency.DAL.Model;

namespace Govt._Agency.Controllers
{
    public class AgencyInfoController : Controller
    {
        private readonly IAngencyInfo _angencyInfoRepo;
        private readonly Govt_AgencyContext _context;

        public AgencyInfoController(IAngencyInfo angencyInfoRepo, Govt_AgencyContext context)
        {
            _angencyInfoRepo = angencyInfoRepo;
            _context = context;
        }











        // GET: Country
        public async Task<IActionResult> CountryIndex()
        {
            return View(await _context.Countries.ToListAsync());
        }

        // GET: State
        public async Task<IActionResult> StateIndex()
        {
            return View(await _context.States.ToListAsync());
        }

        // GET: State
        public async Task<IActionResult> CityIndex()
        {
            return View(await _context.Citys.ToListAsync());
        }

        // GET: Country/Create
        public IActionResult CountryCreate()
        {
            return View();
        }


        // POST: Country/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CountryCreate([Bind("Id,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CountryIndex));
            }
            return View(country);
        }

        // GET: State/Create
        public IActionResult StateCreate()
        {
            ViewBag.Countries = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: State/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StateCreate([Bind("Id,Name,CountryId")] State state)
        {
            if (ModelState.IsValid)
            {
                _context.Add(state);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(StateIndex));
            }
            return View(state);
        }

        // GET: City/Create
        public IActionResult CityCreate()
        {
            ViewBag.States = new SelectList(_context.States, "Id", "Name");
            return View();
        }

        // POST: City/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CityCreate([Bind("Id,Name,StateId")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CityIndex));
            }
            return View(city);
        }

        // GET: Country/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedCascade(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CountryIndex));
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }

        public IActionResult Cascade()
        {
            ViewBag.Countries = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        public JsonResult LoadStates(int Id)
        {
            var States = _context.States.Where(x => x.CountryId == Id).ToList();
            return Json(new SelectList(States, "Id", "Name"));
        }

        public JsonResult LoadCities(int Id)
        {
            var Cities = _context.Citys.Where(x => x.StateId == Id).ToList();
            return Json(new SelectList(Cities, "Id", "Name"));
        }








        // GET: AgencyInfo
        public IActionResult Index()
        {
            return View(_angencyInfoRepo.GetAllViews());
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
            ViewBag.Countries = new SelectList(_context.Countries, "Id", "Name");
            ViewBag.AgencyTypes=new SelectList(_context.AgencyTypes, "Id", "Name");
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
            return _angencyInfoRepo.any(id);
        }
    }
}
