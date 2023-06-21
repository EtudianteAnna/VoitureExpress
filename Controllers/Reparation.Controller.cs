using Microsoft.AspNetCore.Authorization;
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
        public IActionResult IndexReparationVoiture()
        {
            var reparations = _context.ReparationVoiture
                .Include(r=> r.Voiture)
                .ToList();
            return View(reparations);
        
        }


        // GET: Reparation/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reparation reparation = await _context.ReparationVoiture
                .Include(r => r.Voiture)
    .FirstOrDefaultAsync(r => r.Id == id);


            if (reparation == null)
            {
                return NotFound();
            }
                   
            return View(reparation);
        }

        // GET: Reparation/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var voitures = _context.Voiture.ToList();
            if (voitures == null)
            {
                return NotFound();
            }
            ViewBag.TypesReparation = new List<string> { "Freins", "Autre" };
            return View();
        }

        // POST: Reparation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,DateReparation,CoutReparation,VoitureId,TypeReparation")] Reparation editedReparation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editedReparation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Voitures = _context.Voiture.ToList();
            ViewBag.TypesReparation = new List<string> { "Freins", "Autre" };
            return View(editedReparation);
        }

        // GET: Reparation/Edit/5
        [Authorize(Roles = "Admin")]
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
            var voitures = await _context.Voiture.ToListAsync();
            if (voitures == null)
            {
                return NotFound();
            }

            ViewBag.Voitures = voitures;
            return View(reparation);
        }

        // POST: Reparation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateReparation,CoutReparation,VoitureId")] Reparation editedReparation)
        {
            if (id == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = _context.Update(editedReparation);
                    _ = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReparationExists(editedReparation.Id))
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
            return View(editedReparation);
        }

        // GET: Reparation/Delete/5
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparation = await _context.ReparationVoiture
                .Include(r => r.Voiture)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reparation == null)
            {
                return NotFound();
            }

            return View(reparation);
        }

        // POST: Reparation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int reparationId)
        {
            var reparation = await _context.ReparationVoiture.FindAsync(reparationId);
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
            return _context.ReparationVoiture != null && _context.ReparationVoiture.Any(r => r.Id == id);
        }
    }
}
