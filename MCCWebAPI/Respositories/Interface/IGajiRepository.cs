using MCCWebAPI.Models;
using System.Collections.Generic;

namespace MCCWebAPI.Respositories.Interface
{
    public interface IGajiRepository
    {
        List<Gaji> Get();

        Gaji Get(int id);

        int Post(Gaji gaji);

        int Put(Gaji gaji);

        int Delete(int id);
    }
}
