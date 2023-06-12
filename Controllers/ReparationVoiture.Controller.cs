using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



using VoitureExpress.Models;

namespace VoitureExpress.Controllers
{
    public class ReparationController : Controller
    {
        private readonly VoitureExpressContext _context;

        public ReparationController(VoitureExpressContext context)
        {
            _context = context;
        }

        // GET: Reparation
        public async Task<IActionResult> Index()
        {
#pragma warning disable CS8604 // Existence possible d'un argument de référence null.
            var reparations = await _context.ReparationVoiture                .Include(r => r.Voiture)
                .ToListAsync();

#pragma warning restore CS8604 // Existence possible d'un argument de référence null.

            return View(reparations);
        }

        // GET: Reparation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparation = await _context.ReparationVoiture.Include(r => r.Voiture).FirstOrDefaultAsync(r => r.Id == id);

            if (reparation == null)
            {
                return NotFound();
            }

            return View(reparation);
        }

        // GET: Reparation/Create creation liste de types de réparation
        public IActionResult Create()
        {
            ViewBag.Voitures = _context.Voiture.ToList();
            ViewBag.TypesReparation = new List<string> { "Freins", "Autre" }; // Ajout du type de réparation "freins"
            return View();
        }

        // POST: Reparation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateReparation,CoutReparation,VoitureId,TypeReparation")] ReparationVoiture reparations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reparations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Voitures = _context.Voiture.ToList();
            ViewBag.TypesReparation = new List<string> { "Freins", "Autre" }; // Ajout du type de réparation "frein
            return View(reparations);
        }

        // GET: Reparation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparation = await _context.ReparationVoiture.FindAsync(id);
            if (reparation == null)
            {
                return NotFound();
            }

            ViewBag.Voitures = _context.Voiture.ToList();
            return View(reparation);
        }

        // POST: Reparation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateReparation,CoutReparation,VoitureId")] ReparationVoiture reparations)
        {
            if (id != reparations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reparations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReparationExists(reparations.Id))
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

            ViewBag.Voitures = _context.Voiture.ToList();
            return View(reparations);
        }

        // GET: Reparation/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparation = await _context.ReparationVoiture.Include(r => r.Voiture).FirstOrDefaultAsync(r => r.Id == id);
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
            var reparation = await _context.ReparationVoiture.FindAsync(id);
            if (reparation == null)
            {
                return NotFound();
            }

            _context.ReparationVoiture.Remove(reparation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReparationExists(int id)
        {
            return _context.ReparationVoiture .Any(r => r.Id == id);
        }
    }
}
        
    

