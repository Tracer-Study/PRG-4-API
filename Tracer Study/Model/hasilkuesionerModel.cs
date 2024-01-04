using System.ComponentModel.DataAnnotations;

namespace PRG_4_API.Model
{
    public class hasilkuesionerModel
    {
        [Required(ErrorMessage = "ID Hasil Kuesioner wajib diisi.")]
        public string id_hasilKuesioner { get; set; }

        [Required(ErrorMessage = "NIM wajib diisi.")]
        [MaxLength(10, ErrorMessage = "NIM maksimal 10 karakter.")]
        public string nim { get; set; }

        [Required(ErrorMessage = "Wajib diisi.")]
        public int id_detail_periode { get; set; }

        [Required(ErrorMessage = "Tanggal wajib diisi.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd  HH:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Format tanggal tidak valid.")]
        [Range(typeof(DateTime), "2000-01-01", "9999-12-31", ErrorMessage = "Tanggal harus berada di antara 2000-01-01 dan 9999-12-31.")]
        public DateTime tanggal_pengisian { get; set; }

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
    }
}
