using System.ComponentModel.DataAnnotations;

namespace PRG_4_API.Model
{
    public class detailpengisiankuesionerModel
    {
        [Required(ErrorMessage = "ID wajib diisi.")]
        public int id { get; set; }

        [Required(ErrorMessage = "Tahun Lulus wajib diisi.")]
        [MaxLength(4, ErrorMessage = "Tahun Lulus maksimal 4 karakter.")]
        public string tahun_lulus { get; set; }

        [Required(ErrorMessage = "Tahun Kuesioner wajib diisi.")]
        [MaxLength(4, ErrorMessage = "Tahun Kuesioner maksimal 4 karakter.")]
        public string tahun_kuesioner { get; set; }

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
