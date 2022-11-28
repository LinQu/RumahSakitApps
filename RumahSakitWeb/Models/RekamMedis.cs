using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RumahSakitWeb.Models
{
    public class RekamMedis
    {
        [Key]
        public int ID { get; set; }

        //foreign key dokter dan pasien
        [ForeignKey("Dokter")]
        public int DokterID { get; set; }
        [ForeignKey("Pasien")]
        public int PasienID { get; set; }

        [Required]
        public string? Keluhan { get; set; }

        [Required]
        public string? Penanganan { get; set; }

        [Required]
        public DateTime TglPeriksa { get; set; } = DateTime.Now;



    }
}
