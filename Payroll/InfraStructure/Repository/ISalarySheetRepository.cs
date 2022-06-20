using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.Payroll;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.InfraStructure.Repository
{
  
       public interface ISalarySheetRepository : IRepository<SalarySheet>
    {
        Task<List<SalarySheet>> GetAllSalarySheetAsync();
    }
    public class SalarySheetRepository : Repository<SalarySheet>, ISalarySheetRepository
    {
        public SalarySheetRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<SalarySheet>> GetAllSalarySheetAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
