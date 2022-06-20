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
    public interface IElectricityFineSetupRepository : IRepository<ElectricityFineSetup>
    {
        Task<List<ElectricityFineSetup>> GetAllFineSetupAsync();
    }
    public class ElectricityFineSetupRepository : Repository<ElectricityFineSetup>, IElectricityFineSetupRepository
    {
        public ElectricityFineSetupRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<ElectricityFineSetup>> GetAllFineSetupAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
