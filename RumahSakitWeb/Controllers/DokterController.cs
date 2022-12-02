using Microsoft.AspNetCore.Mvc;
using RumahSakitWeb.Data;
using RumahSakitWeb.Models;

namespace RumahSakitWeb.Controllers
{
    public class DokterController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly string URL = "https://localhost:44383/api/Dokter/";

        public DokterController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Dokter> dataDokter;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync("GetAll");
                if (response.IsSuccessStatusCode)
                {
                    dataDokter = await response.Content.ReadAsAsync<IEnumerable<Dokter>>();
                    return View(dataDokter);
                }
                return NotFound();
            }



        }

        //tambah data DOkter
        public IActionResult Tambah()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Tambah(Dokter dokter)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                HttpResponseMessage response = await client.PostAsJsonAsync("Create", dokter);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Notifikasi"] = "Data Berhasil Ditambah";
                    return RedirectToAction("Index");
                    
                }
                return NotFound();
                
            }

            
            //dokter.Alamat ??= "";
            //if (dokter.Alamat.Equals(null))
            //{
            //    dokter.Alamat = "-";
            //}
            //else if (dokter.Alamat.Equals("Bekasi"))
            //{
            //    ModelState.AddModelError("Alamat", "Alamat gabole bekasi");
            //}

            //if (ModelState.IsValid)
            //{
            //    _db.ParaDokter.Add(dokter);
            //    _db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(dokter);
        }

        //edit data dokter
        public async Task<IActionResult> Ubah(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                var response = await client.GetAsync("GetById/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var dataDokter = response.Content.ReadAsAsync<Dokter>().Result;
                    return View(dataDokter);
                }
                return NotFound();
            }
        
            
            ////if id not found
            //if (id == null || id == 0)
            //{
            //    return NotFound();
            //}

            //Dokter dokter = _db.ParaDokter.Find(id);
            //if (dokter == null)
            //{
            //    return NotFound();
            //}


            //return View(dokter);
        }

        [HttpPost]
        public IActionResult Ubah(Dokter dokter)
        {
            if (ModelState.IsValid)
            {
                _db.ParaDokter.Update(dokter);
                _db.SaveChanges();
                TempData["Notifikasi"] = "Data Berhasil DiUbah";

                return RedirectToAction("Index");
            }
            return View(dokter);
        }


        //hapus data dokter
        public async Task<IActionResult> Hapus(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                HttpResponseMessage response = await client.DeleteAsync("Delete/" + id);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Notifikasi"] = "Data Berhasil Dihapus";
                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            

        }
    }
}
