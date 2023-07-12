using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoitureExpress.Models;

namespace VoitureExpress.Controllers
{

    public class VoitureController : Controller
    {
        private readonly VoitureExpressContext _context;

        public VoitureController(VoitureExpressContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var voitures = _context.Voitures != null ? await _context.Voitures.ToListAsync() : new List<Voiture>();
            return View("Index", voitures);
        }

        public async Task<IActionResult> Index0()
        {
            return _context.Voitures != null ?
                View(await _context.Voitures.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Voiture' is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voitures.Include(v => v.ReparationVoiture).FirstOrDefaultAsync(m => m.Id == id);

            if (voiture == null)
            {
                return NotFound();

            }

            return View(voiture);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Marque,Modele,Annee,Finition,DateAchat,Prix,Réparations,CoûtsDeRéparations,Disponibilité,PrixDeVente,DateDeVente")] Models.Voiture voiture)
        {
            if (ModelState.IsValid)
            {
                // Exemple d'ajout d'une nouvelle réparation à la liste existante
                
                _context.Add(voiture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voiture);
        }
                public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }
            var voiture = await _context.Voitures.Include(v => v.ReparationVoiture).FirstOrDefaultAsync(m => m.Id == id);
            if (voiture == null)
            {
                return NotFound();
            }
                        
            return View (voiture);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marque,Modele,Annee,Finition,DateAchat,Prix,Réparations,CoûtsDeRéparations,Disponibilité,PrixDeVente,DateDeVente")] Models.Voiture voiture)
        {
            if (id != voiture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voiture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoitureExists(voiture.Id))
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
            return View(voiture);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voitures.Include(v => v.ReparationVoiture).FirstOrDefaultAsync(m => m.Id == id);
            return voiture switch
            {
                null => NotFound(),
                _ => View(voiture)
            };
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Voitures == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Voiture' is null.");
            }
            var voiture = await _context.Voitures.FindAsync(id);
            if (voiture != null)
            {
                _context.Voitures.Remove(voiture);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoitureExists(int id)
        {
            return (_context.Voitures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Search(string searchString)
        {
            var voitures = from v in _context.Voitures
                           select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                voitures = voitures.Where(v =>
                (v.Marque != null && v.Marque.Contains(searchString)) ||
    (v.Modele != null && v.Modele.Contains(searchString)) ||
    (v.Finition != null && v.Finition.Contains(searchString))
);
            }

            return View(await voitures.ToListAsync());
        }
    }
}
