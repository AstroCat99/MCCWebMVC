using MCCWebAPI.Models;
using MCCWebAPI.Models.ViewModels;
using System.Collections.Generic;

namespace MCCWebAPI.Respositories.Interface
{
    public interface IKaryawanRepository
    {
        List<EmployeeData> Get();

        EmployeeData Get(int id);

        int Post(KaryawanViewModel karyawan);

        int Put(KaryawanViewModel karyawan);

        int Delete(int id);
    }
}
