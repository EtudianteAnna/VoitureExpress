using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult IndexReparation()
        {
            var reparations = _context.ReparationVoiture
                .Include(r=> r.Voiture)
                .ToList();
            return View(reparations);
        
        }

        public IActionResult ListeDesReparations(int Id_Voiture)
        {
            var reparations = _context.ReparationVoiture.Where(r=>r.VoitureId== Id_Voiture) 

                .Include(r => r.Voiture)  
                .ToList();
            return View("IndexReparation",reparations);

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

        // POST: Reparation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateReparationVoiture([Bind("Id,DateReparation,CoutReparation,VoitureId,TypeReparation")] Reparation editedReparation)
        {
            if (ModelState.IsValid)
            {
                _ = _context.Add(editedReparation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Voitures = new SelectList(_context.Voiture,"Id", "Marque"); // Sélection de la voiture par son identifiant et affichage du nom dans la liste déroulante
            ViewBag.TypesReparation = new List<string> { "Freins", "Autre" };
            return View("CreateReparationVoiture");
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
