using System.ComponentModel.DataAnnotations;

namespace PRG_4_API.Model
{
    public class detailpengisiankuesionerAlumni
    {
        public string nim { get; set; }
        public string nama { get; set; }
        public string id_hasilKuesioner { get; set; }
        public string id_detailPeriode { get; set; }
        public string jenis_periode{ get; set; }
        public string id_pku { get; set; }
        public string kode { get; set; }
        public string deskripsiPertanyaan { get; set; }
        public string jawabanKuesioner { get; set; }
    }
}
