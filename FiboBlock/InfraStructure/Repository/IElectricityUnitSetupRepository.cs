using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboBlock;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboBlock.InfraStructure.Repository
{
    public interface IElectricityUnitSetupRepository : IRepository<ElectricityUnitSetup>
    {
        Task<List<ElectricityUnitSetup>> GetAllElectricityUnitSetupAsync();
    }
    public class ElectricityUnitSetupRepository : Repository<ElectricityUnitSetup>, IElectricityUnitSetupRepository
    {
        public ElectricityUnitSetupRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<ElectricityUnitSetup>> GetAllElectricityUnitSetupAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
