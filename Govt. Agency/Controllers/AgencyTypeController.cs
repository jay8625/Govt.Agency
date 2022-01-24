using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Govt.Agency.DAL.Model;

namespace Govt._Agency.Controllers
{
    public class AgencyTypeController : Controller
    {
        private readonly Govt_AgencyContext _context;

        public AgencyTypeController(Govt_AgencyContext context)
        {
            _context = context;
        }

        // GET: AgencyType
        public async Task<IActionResult> Index()
        {
            return View(await _context.AgencyTypes.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id,Name")] AgencyType agencyType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agencyType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agencyType);
        }

        // GET: AgencyType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencyType = await _context.AgencyTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agencyType == null)
            {
                return NotFound();
            }

            return View(agencyType);
        }

        // POST: AgencyType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agencyType = await _context.AgencyTypes.FindAsync(id);
            _context.AgencyTypes.Remove(agencyType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgencyTypeExists(int id)
        {
            return _context.AgencyTypes.Any(e => e.Id == id);
        }
    }
}
