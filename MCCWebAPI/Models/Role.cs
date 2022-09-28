using System.ComponentModel.DataAnnotations;

namespace MCCWebAPI.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
