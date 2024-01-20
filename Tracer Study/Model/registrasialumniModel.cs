using System.ComponentModel.DataAnnotations;

namespace PRG_4_API.Model
{
    public class registrasialumniModel
    {
        [Required(ErrorMessage = "Wajib diisi.")]
        public int id { get; set; }

        [Required(ErrorMessage = "NIM wajib diisi.")]
        [MaxLength(10, ErrorMessage = "NIM maksimal 10 karakter.")]
        public string nim { get; set; }


        [Required(ErrorMessage = "NIK wajib diisi.")]
        [MaxLength(16, ErrorMessage = "NIK maksimal 16 karakter.")]
        public string nik { get; set; }

        [Required(ErrorMessage = "NPWP wajib diisi.")]
        [MaxLength(20, ErrorMessage = "NPWP maksimal 20 karakter.")]
        public string npwp { get; set; }

        [Required(ErrorMessage = "Nama wajib diisi.")]
        [MaxLength(100, ErrorMessage = "Nama maksimal 100 karakter.")]
        public string nama { get; set; }

        [Required(ErrorMessage = "Alamat wajib diisi.")]
        public string alamat { get; set; }

        [Required(ErrorMessage = "Tanggal wajib diisi.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd  HH:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Format tanggal tidak valid.")]
        [Range(typeof(DateTime), "2000-01-01", "9999-12-31", ErrorMessage = "Tanggal harus berada di antara 2000-01-01 dan 9999-12-31.")]
        public DateTime tanggal_lahir { get; set; }

        [Required(ErrorMessage = "Tahun Lulus wajib diisi.")]
        [MaxLength(4, ErrorMessage = "Tahun Lulus maksimal 4 karakter.")]
        public string tahun_lulus { get; set; }

        [Required(ErrorMessage = "Email wajib diisi.")]
        [MaxLength(100, ErrorMessage = "Email maksimal 100 karakter.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password wajib diisi.")]
        [MaxLength(50, ErrorMessage = "Password maksimal 50 karakter.")]
        public string password { get; set; } = "-";

        [Required(ErrorMessage = "Status wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Status maksimal 30 karakter.")]
        public string status { get; set; }

        [Required(ErrorMessage = "Nomor Telepon Petugas wajib diisi.")]
        [MaxLength(13, ErrorMessage = "Nomor Telepon Petugas maksimal 13 karakter.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Nomor Telepon Petugas hanya boleh berupa angka.")]
        public string telepon { get; set; }

        [Required(ErrorMessage = "Wajib diisi.")]
        [MaxLength(50, ErrorMessage = "Maksimal 50 karakter.")]
        public string created_by { get; set; }

        [Required(ErrorMessage = "Tanggal wajib diisi.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd  HH:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Format tanggal tidak valid.")]
        [Range(typeof(DateTime), "2000-01-01", "9999-12-31", ErrorMessage = "Tanggal harus berada di antara 2000-01-01 dan 9999-12-31.")]
        public DateTime created_date { get; set; }

        [Required(ErrorMessage = "Wajib diisi.")]
        [MaxLength(50, ErrorMessage = "Maksimal 50 karakter.")]
        public string modified_by { get; set; }

        [Required(ErrorMessage = "Tanggal wajib diisi.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd  HH:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Format tanggal tidak valid.")]
        [Range(typeof(DateTime), "2000-01-01", "9999-12-31", ErrorMessage = "Tanggal harus berada di antara 2000-01-01 dan 9999-12-31.")]
        public DateTime modified_date { get; set; }

        [Required(ErrorMessage = "Wajib diisi.")]
        public int id_kodeProdi { get; set; }
    }
}
