using System.ComponentModel.DataAnnotations;

namespace MCCWebMVC.Models
{
    public class Jabatan
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Tunjangan { get; set; }
    }
}
