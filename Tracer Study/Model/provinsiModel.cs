using System.ComponentModel.DataAnnotations;

namespace PRG_4_API.Model
{
    public class provinsiModel
    {
        [Required(ErrorMessage = "ID wajib diisi.")]
        [MaxLength(10, ErrorMessage = "ID maksimal 10 karakter.")]
        public string provinsi_id { get; set; }

        [Required(ErrorMessage = "Deskripsi wajib diisi.")]
        [MaxLength(100, ErrorMessage = "Deskripsi maksimal 100 karakter.")]
        public string provinsi_deskripsi { get; set; }
    }
}
