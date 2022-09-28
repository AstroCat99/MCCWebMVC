using MCCWebAPI.Models;
using System.Collections.Generic;

namespace MCCWebAPI.Respositories.Interface
{
    public interface IJabatanRepository
    {
        List<Jabatan> Get();

        Jabatan Get(int id);

        int Post(Jabatan jabatan);

        int Put(Jabatan jabatan);

        int Delete(int id);
    }
}
