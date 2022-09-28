using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCCWebAPI.Models
{
    public class User
    {
        [Key]
        public Employee Employee { get; set; }
        [ForeignKey("Employee")]
        public int Id { get; set; }

        public string Password { get; set; }
    }
}
