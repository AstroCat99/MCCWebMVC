using MCCWebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MCCWebMVC.Models
{
    public class CutiLibur
    {
        [Key]
        public int Id { get; set; }

        public Employee Employee { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public string Bulan { get; set; }

        public int Cuti { get; set; }

        public int Libur { get; set; }

        public string Status { get; set; }
    }
}
