using System.ComponentModel.DataAnnotations;

namespace PRG_4_API.Model
{
    public class pertanyaankuesionerModel
    {
        [Required(ErrorMessage = "ID wajib diisi.")]
        [MaxLength(10, ErrorMessage = "ID maksimal 10 karakter.")]
        public string id_pku { get; set; }

        [Required(ErrorMessage = "Deskripsi wajib diisi.")]
        [MaxLength(ErrorMessage = "")]
        public string deskripsiPertanyaan { get; set; }


        [Required(ErrorMessage = "Jenis wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Jenis maksimal 30 karakter.")]
        public string jenis { get; set; }

        [Required(ErrorMessage = "Kode wajib diisi.")]
        [MaxLength(ErrorMessage = "")]
        public string kode { get; set; }

        [Required(ErrorMessage = "ID wajib diisi.")]
        public int id_detailPeriode { get; set; }

        [Required(ErrorMessage = "Pertanyaan Utama wajib diisi.")]
        [MaxLength(11, ErrorMessage = "Pertanyaan Utama maksimal 11 karakter.")]
        public string pertanyaan_utama { get; set; }

        [Required(ErrorMessage = "Nomor Urutan wajib diisi.")]
        public int no_urutan { get; set; }

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
        [MaxLength(30, ErrorMessage = "Maksimal 30 karakter.")]
        public string status { get; set; }
    }
}
