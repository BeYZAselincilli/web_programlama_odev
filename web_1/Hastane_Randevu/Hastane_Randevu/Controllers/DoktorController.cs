using Hastane_Randevu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace Hastane_Randevu.Controllers


{
    public class DoktorController : Controller
    {
        private readonly HastaneContext _context;

        public DoktorController(HastaneContext context)
        {
            _context = context;
        }

        // Doktor listesini göster
        public async Task<IActionResult> Index()
        {
            var doktorlar = await _context.Doktorlar.ToListAsync();
            return View(doktorlar);
        }

        // Yeni doktor ekleme sayfasını göster
        public IActionResult Create()
        {
            return View();
        }

        // Yeni doktor ekleme işlemini gerçekleştir
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoktorID,Ad,Soyad,UzmanlikAlaniID")] Doktor doktor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doktor);
        }

        // Doktor detayını göster
        public async Task<IActionResult> Details(int id)
        {
            var doktor = await _context.Doktorlar
                .FirstOrDefaultAsync(m => m.DoktorID == id);
            if (doktor == null)
            {
                return NotFound();
            }
            return View(doktor);
        }

        // Doktor düzenleme sayfasını göster
        public async Task<IActionResult> Edit(int id)
        {
            var doktor = await _context.Doktorlar.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }
            return View(doktor);
        }

        // Doktor düzenleme işlemini gerçekleştir
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoktorID,Ad,Soyad,UzmanlikAlaniID")] Doktor doktor)
        {
            if (id != doktor.DoktorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorExists(doktor.DoktorID))
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
            return View(doktor);
        }

        // Doktor silme işlemini onaylama sayfasını göster
        public async Task<IActionResult> Delete(int id)
        {
            var doktor = await _context.Doktorlar
                .FirstOrDefaultAsync(m => m.DoktorID == id);
            if (doktor == null)
            {
                return NotFound();
            }
            return View(doktor);
        }

        // Doktor silme işlemini gerçekleştir
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doktor = await _context.Doktorlar.FindAsync(id);
            _context.Doktorlar.Remove(doktor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorExists(int id)
        {
            return _context.Doktorlar.Any(e => e.DoktorID == id);
        }
    }
}
