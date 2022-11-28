using System.ComponentModel.DataAnnotations;

namespace RumahSakitWeb.Models
{
    public class Dokter
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Nama harus diisi")]
        public string? Nama { get; set; }
        [Required(ErrorMessage = "Spesialis harus diisi")]
        public string? Spesialis { get; set; }
        public string? Alamat { get; set; }

        [Display(Name = "Nomor Izin")]
        public string? NoIzin { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;



    }

}
