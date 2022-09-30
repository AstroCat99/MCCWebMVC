using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MCCWebAPI.Models.ViewModels
{
    public class CutiLiburViewModel
    {
        public int EmployeeId { get; set; }

        public string Bulan { get; set; }

        public int Cuti { get; set; }

        public int Libur { get; set; }

        public string Status { get; set; }
    }
}
