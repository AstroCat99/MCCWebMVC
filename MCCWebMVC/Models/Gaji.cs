using System.ComponentModel.DataAnnotations;

namespace MCCWebMVC.Models
{
    public class Gaji
    {
        [Key]
        public int Id { get; set; }

        public int Pokok { get; set; }

        public int Tunjangan { get; set; }

        public int Akomodasi { get; set; }

        public string Bank { get; set; }

        public string Rekening { get; set; }
    }
}
