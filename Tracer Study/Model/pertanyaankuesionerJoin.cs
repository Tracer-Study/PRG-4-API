using System.ComponentModel.DataAnnotations;

namespace PRG_4_API.Model
{
    public class pertanyaankuesionerJoin
    {
        public string id_pku { get; set; }
        public string deskripsiPertanyaan { get; set; }
        public string jenis { get; set; }
        public string kode { get; set; }
        public int id_detailPeriode { get; set; }
        public string jenisPeriode { get; set; }
        public string pertanyaan_utama { get; set; }
        public int no_urutan { get; set; }
        public string status { get; set; }
    }
}
