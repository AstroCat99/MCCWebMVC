using System.ComponentModel.DataAnnotations;

namespace MCCWebMVC.Models
{
    public class Gaji
    {
        public int Id { get; set; }

        public int Pokok { get; set; }

        public string Bank { get; set; }

        public string Rekening { get; set; }
    }
}
