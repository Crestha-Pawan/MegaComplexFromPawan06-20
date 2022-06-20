using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboOffice;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboOffice.InfraStructure.Repository
{
    
    public interface IYearRepository : IRepository<Year>
    {
        Task<List<Year>> GetAllYearAsync();
    }
    public class YearRepository : Repository<Year>, IYearRepository
    {
        public YearRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Year>> GetAllYearAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
