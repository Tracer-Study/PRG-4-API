using System.ComponentModel.DataAnnotations;

namespace PRG_4_API.Model
{
    public class kabkotaModel
    {
        [Required(ErrorMessage = "ID wajib diisi.")]
        [MaxLength(10, ErrorMessage = "ID maksimal 10 karakter.")]
        public string kabkota_id { get; set; }


        [Required(ErrorMessage = "Deskripsi wajib diisi.")]
        [MaxLength(100, ErrorMessage = "Deskripsi maksimal 100 karakter.")]
        public string kabkota_deskripsi { get; set; }

        [Required(ErrorMessage = "ID wajib diisi.")]
        [MaxLength(10, ErrorMessage = "ID maksimal 10 karakter.")]
        public string kabkota_provinsi_id { get; set; }
    }
}
