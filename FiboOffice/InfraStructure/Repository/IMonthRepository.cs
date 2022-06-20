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
    
    public interface IMonthRepository : IRepository<Month>
    {
        Task<List<Month>> GetAllMonthAsync();
    }
    public class MonthRepository : Repository<Month>, IMonthRepository
    {
        public MonthRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Month>> GetAllMonthAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
