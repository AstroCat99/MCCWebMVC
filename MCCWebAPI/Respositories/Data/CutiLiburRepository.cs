using MCCWebAPI.Context;
using MCCWebAPI.Models;
using MCCWebAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MCCWebAPI.Respositories.Data
{
    public class CutiLiburRepository
    {
        MyContext myContext;

        public CutiLiburRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int NewSelfReport(CutiLiburViewModel cutiLiburViewModel)
        {
            var result = 0;
            CutiLibur cutiLibur = new CutiLibur
            {
                Id = 0,
                EmployeeId = cutiLiburViewModel.EmployeeId,
                Bulan = cutiLiburViewModel.Bulan,
                Cuti = cutiLiburViewModel.Cuti,
                Libur = cutiLiburViewModel.Libur,
                Status = "Belum Approve"
            };
            myContext.CutiLiburs.Add(cutiLibur);
            var dataSaved = myContext.SaveChanges();
            if (dataSaved > 0)
                    result = 1;
            else 
                return result;
            return result;  
        }

        public int ApproveSelfReport(CutiLiburViewModel cutiLiburViewModel)
        {
            var result = 0;
            var newData = myContext.CutiLiburs.FirstOrDefault(
                x => 
                x.EmployeeId.Equals(cutiLiburViewModel.EmployeeId)
                &&
                x.Bulan.Equals(cutiLiburViewModel.Bulan)
                );
            newData.EmployeeId = cutiLiburViewModel.EmployeeId;
            newData.Bulan = cutiLiburViewModel.Bulan;
            newData.Cuti = cutiLiburViewModel.Cuti;
            newData.Libur = cutiLiburViewModel.Libur;
            newData.Status = cutiLiburViewModel.Status;
            myContext.CutiLiburs.Update(newData);
            result = myContext.SaveChanges();
            var dataSaved = myContext.SaveChanges();
            if (dataSaved > 0)
                result = 1;
            else
                return result;
            return result;
        }

        


    }
}
