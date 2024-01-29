using System.ComponentModel.DataAnnotations;

namespace PRG_4_API.Model
{
    public class hasilPertanyaanModel
    {
        
        public string id_pku { get; set; }
        public string deskripsiPertanyaan { get; set; }
        public string kode { get; set; }
        public string jawabanKuesioner { get; set; }
        public int jumlahKoresponden { get; set; }
    }
}
