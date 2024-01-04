using System.ComponentModel.DataAnnotations;

namespace PRG_4_API.Model
{
    public class adminModel
    {
        [Required(ErrorMessage = "ID wajib diisi.")]
        [MaxLength(5, ErrorMessage = "ID maksimal 5 karakter.")]
        public string id_admin { get; set; }

        [Required(ErrorMessage = "Nama wajib diisi.")]
        [MaxLength(50, ErrorMessage = "Nama maksimal 50 karakter.")]
        public string nama { get; set; }

        [Required(ErrorMessage = "Jenis Kelamin wajib diisi.")]
        [MaxLength(10, ErrorMessage = "Jenis Kelamin maksimal 10 karakter.")]
        public string jenis_kelamin { get; set; }

        [Required(ErrorMessage = "Email wajib diisi.")]
        [MaxLength(50, ErrorMessage = "Email maksimal 50 karakter.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Username wajib diisi.")]
        [MaxLength(20, ErrorMessage = "Username maksimal 20 karakter.")]

        public string username { get; set; }

        [Required(ErrorMessage = "Password wajib diisi.")]
        [MaxLength(50, ErrorMessage = "Password maksimal 50 karakter.")]
        public string password { get; set; }
    }
}
