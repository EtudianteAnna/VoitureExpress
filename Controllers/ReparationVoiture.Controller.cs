using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VoitureExpress.Data;
using VoitureExpress.Models;

namespace VoitureExpress.Controllers
{
    public class ReparationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReparationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reparation
        public async Task<IActionResult> Index()
        {
            var reparations = await _context.Reparation.Include(r => r.Voiture).ToListAsync();
            return View(reparations);
        }

        // GET: Reparation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparation = await _context.Reparation.Include(r => r.Voiture).FirstOrDefaultAsync(r => r.Id == id);

            if (reparation == null)
            {
                return NotFound();
            }

            return View(reparation);
        }

        // GET: Reparation/Create creation liste de types de réparation
        public IActionResult Create()
        {
            ViewBag.Voitures = _context.Voitures.ToList();
            ViewBag.TypesReparation = new List<string> { "Freins", "Autre" }; // Ajout du type de réparation "freins"
            return View();
        }

        // POST: Reparation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateReparation,CoutReparation,VoitureId,TypeReparation")] ReparationVoiture reparation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reparation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Voitures = _context.Voitures.ToList();
            ViewBag.TypesReparation = new List<string> { "Freins", "Autre" }; // Ajout du type de réparation "frein
            return View(reparation);
        }

        // GET: Reparation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparation = await _context.Reparation.FindAsync(id);
            if (reparation == null)
            {
                return NotFound();
            }

            ViewBag.Voitures = _context.Voitures.ToList();
            return View(reparation);
        }

        // POST: Reparation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateReparation,CoutReparation,VoitureId")] ReparationVoiture reparation)
        {
            if (id != reparation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reparation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReparationExists(reparation.Id))
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

            ViewBag.Voitures = _context.Voitures.ToList();
            return View(reparation);
        }

        // GET: Reparation/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparation = await _context.Reparation.Include(r => r.Voiture).FirstOrDefaultAsync(r => r.Id == id);
            if (reparation == null)
            {
                return NotFound();
            }

            return View(reparation);
        }

        // POST: Reparation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reparation = await _context.Reparation.FindAsync(id);
            if (reparation == null)
            {
                return NotFound();
            }

            _context.Reparation.Remove(reparation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReparationExists(int id)
        {
            return _context.Reparation.Any(r => r.Id == id);
        }
    }
}
        
    

