using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCCWebAPI.Models
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
