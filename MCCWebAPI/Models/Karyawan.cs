using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MCCWebAPI.Models
{
    public class Karyawan
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Ktp { get; set; }

        public string Telpon { get; set; }

        public Jabatan Jabatan { get; set; }
        [ForeignKey("Jabatan")]
        public int JabatanId { get; set; }

        public Gaji Gaji { get; set; }
        [ForeignKey("Gaji")]
        public int GajiId { get; set; }
    }
}
