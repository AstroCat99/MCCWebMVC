using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MCCWebAPI.Models.ViewModels
{
    public class KaryawanViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Ktp { get; set; }

        public string Telpon { get; set; }

        public int JabatanId { get; set; }

        public int GajiId { get; set; }
    }
}
