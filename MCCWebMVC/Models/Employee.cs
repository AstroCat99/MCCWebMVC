using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MCCWebMVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Telpon { get; set; }

        public Jabatan Jabatan { get; set; }
        [ForeignKey("Jabatan")]
        public int JabatanId { get; set; }
    }
}
