using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCCWebAPI.Models
{
    public class Gaji
    {
        public Employee Employee { get; set; }
        [ForeignKey("Employee")]
        public int Id { get; set; }

        public int Pokok { get; set; }

        public string Bank { get; set; }

        public string Rekening { get; set; }
    }
}
