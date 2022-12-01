using Microsoft.AspNetCore.Mvc;
using RumahSakitWeb.Data;
using RumahSakitWeb.Models;


namespace RumahSakitWeb.Controllers
{
    public class PasienController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PasienController(ApplicationDbContext db )
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ICollection<Pasien> dataPasien = _db.ParaPasien.ToList();
            return View(dataPasien);
        }

        //tambah data pasien
        public IActionResult Tambah()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Tambah(Pasien pasien)
        {
            if (ModelState.IsValid)
            {
                _db.ParaPasien.Add(pasien);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pasien);
        }

        //edit data pasien
        public IActionResult Ubah(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Pasien pasien = _db.ParaPasien.Find(id);
            if (pasien == null)
            {
                return NotFound();
            }
            return View(pasien);
        }

        [HttpPost]
        public IActionResult Ubah(Pasien pasien)
        {
            if (ModelState.IsValid)
            {
                _db.ParaPasien.Update(pasien);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pasien);
        }

        //hapus data pasien
        public async Task<IActionResult> Hapus(int id)
        {
            Pasien pasien = _db.ParaPasien.Find(id);
            _db.ParaPasien.Remove(pasien);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Pasien pasien = _db.ParaPasien.Find(id);
            return View(pasien);
        }

    }
}
