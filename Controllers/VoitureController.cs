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
            var voitures = await _context.Voiture.ToListAsync();
            return View("Index", voitures);
        }

        public async Task<IActionResult> Index0()
        {
            return _context.Voiture != null ?
                View(await _context.Voiture.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Voiture' is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Voiture == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voiture.FirstOrDefaultAsync(m => m.Id == id);
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
                voiture.ReparationVoiture.Add(new Reparation { DateReparation = DateTime.Now, TypeReparation = "Nouvelle intervention", CoutReparation = 100 });

                _context.Add(voiture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voiture);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Voiture == null)
            {
                return NotFound();
            }
            var voiture = await _context.Voiture.FindAsync(id);
            if (voiture == null)
            {
                return NotFound();
            }

            // Effectuer les modifications souhaitées sur la voiture
            voiture.Marque = "Nouvelle marque";
            voiture.Modele = "Nouveau modèle";
            voiture.Annee = 2023;
            voiture.Finition = "Nouvelle finition";
           
            // ...

            // Enregistrer les changements
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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
            if (id == null || _context.Voiture == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voiture.FirstOrDefaultAsync(m => m.Id == id);
            if (voiture == null)
            {
                return NotFound();
            }

            return View(voiture);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Voiture == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Voiture' is null.");
            }
            var voiture = await _context.Voiture.FindAsync(id);
            if (voiture != null)
            {
                _context.Voiture.Remove(voiture);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoitureExists(int id)
        {
            return (_context.Voiture?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Search(string searchString)
        {
            var voitures = from v in _context.Voiture
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
