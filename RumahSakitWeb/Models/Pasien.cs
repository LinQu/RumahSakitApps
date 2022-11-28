using System.ComponentModel.DataAnnotations;


namespace RumahSakitWeb.Models
{
    public class Pasien
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Nama harus diisi")]
        public string? Nama { get; set; }

        [Required(ErrorMessage = "Alamat harus diisi")]
        public string? Alamat { get; set; }

        [Required(ErrorMessage   = "Tanggal harus diisi")]
        [DataType(DataType.Date)]
        [Display(Name = "Tanggal Lahir")]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        
        public DateTime? TglLahir { get; set; }

        public string? NoTelp { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
