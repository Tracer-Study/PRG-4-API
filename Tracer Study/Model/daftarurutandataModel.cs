using System.ComponentModel.DataAnnotations;

namespace PRG_4_API.Model
{
    public class daftarurutandataModel
    {
        [Required(ErrorMessage = "ID wajib diisi.")]
        public int id_daftarUrutanData { get; set; }

        [Required(ErrorMessage = "Kode wajib diisi.")]
        [MaxLength(255, ErrorMessage = "Kode maksimal 255 karakter.")]
        public string kode { get; set; }

        [Required(ErrorMessage = "Alias wajib diisi.")]
        [MaxLength(255, ErrorMessage = "Alias maksimal 255 karakter.")]
        public string alias { get; set; }

        [Required(ErrorMessage = "ID wajib diisi.")]
        public int id_detailJenisPeriode { get; set; }

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
