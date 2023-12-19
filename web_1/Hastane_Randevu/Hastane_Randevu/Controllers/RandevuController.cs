using Hastane_Randevu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace Hastane_Randevu.Controllers
{
    public class RandevuController : Controller
    {
        private readonly HastaneContext _context;

        public RandevuController(HastaneContext context)
        {
            _context = context;
        }

        // Randevuları listele
        public async Task<IActionResult> Index()
        {
            var randevular = await _context.Randevular
                .Include(r => r.Doktor) // Doktor bilgisini de dahil et
                .Include(r => r.Kullanici) // Kullanıcı bilgisini de dahil et
                .Include(r => r.Poliklinik) // Poliklinik bilgisini de dahil et
                .ToListAsync();
            return View(randevular);
        }

        // Randevu detaylarını göster
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular
                .Include(r => r.Doktor)
                .Include(r => r.Kullanici)
                .Include(r => r.Poliklinik)
                .FirstOrDefaultAsync(m => m.RandevuID == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // Randevu ekleme sayfasını göster
        public IActionResult Create()
        {
            // İlgili model verilerini ViewData veya ViewBag ile view'a geçirebilirsiniz.
            return View();
        }

        // Randevu ekleme işlemini gerçekleştir
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RandevuID,KullaniciID,DoktorID,PoliklinikID,RandevuTarihi,RandevuSaati")] Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(randevu);
        }

        // Randevu düzenleme sayfasını göster
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            return View(randevu);
        }

        // Randevu düzenleme işlemini gerçekleştir
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RandevuID,KullaniciID,DoktorID,PoliklinikID,RandevuTarihi,RandevuSaati")] Randevu randevu)
        {
            if (id != randevu.RandevuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevuExists(randevu.RandevuID))
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
            return View(randevu);
        }

        // Randevu silme onay sayfasını göster
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular
                .Include(r => r.Doktor)
                .Include(r => r.Kullanici)
                .Include(r => r.Poliklinik)
                .FirstOrDefaultAsync(m => m.RandevuID == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // Randevu silme işlemini gerçekleştir
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var randevu = await _context.Randevular.FindAsync(id);
            _context.Randevular.Remove(randevu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuExists(int id)
        {
            return _context.Randevular.Any(e => e.RandevuID == id);
        }
    }
}
