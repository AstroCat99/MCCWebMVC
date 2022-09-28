using MCCWebAPI.Models;
using MCCWebAPI.Models.ViewModels;
using System.Collections.Generic;

namespace MCCWebAPI.Respositories.Interface
{
    public interface IKaryawanRepository
    {
        List<Karyawan> Get();

        Karyawan Get(int id);

        int Post(KaryawanViewModel karyawan);

        int Put(KaryawanViewModel karyawan);

        int Delete(int id);
    }
}
