using Microsoft.AspNetCore.Mvc;
using RumahSakitWeb.Data;
using RumahSakitWeb.Models;

namespace RumahSakitWeb.Controllers
{
    public class DokterController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DokterController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ICollection<Dokter> dataDokter = _db.ParaDokter.ToList();
            return View(dataDokter);
        }

        //tambah data DOkter
        public IActionResult Tambah()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Tambah(Dokter dokter)
        {
            dokter.Alamat ??= "";
            if (dokter.Alamat.Equals(null))
            {
                dokter.Alamat = "-";
            }
            else if(dokter.Alamat.Equals("Bekasi"))
            {
                ModelState.AddModelError("Alamat", "Alamat gabole bekasi");
            }
            
            if (ModelState.IsValid)
            {
                _db.ParaDokter.Add(dokter);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dokter);
        }

        //edit data dokter
        public IActionResult Ubah(int id)
        {
            //if id not found
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Dokter dokter = _db.ParaDokter.Find(id);
            if (dokter == null)
            {
                return NotFound();
            }
            

            return View(dokter);
        }

        [HttpPost]
        public IActionResult Ubah(Dokter dokter)
        {
            if (ModelState.IsValid)
            {
                _db.ParaDokter.Update(dokter);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dokter);
        }


        //hapus data dokter
        public async Task<IActionResult> Hapus(int id)
        {
            Dokter dokter = _db.ParaDokter.Find(id);
            _db.ParaDokter.Remove(dokter);
            _db.SaveChanges();
            //set route to DokterController
            return RedirectToAction(nameof(Index));
        }

    }
}
