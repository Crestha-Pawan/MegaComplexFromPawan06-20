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
    public interface IFineSetupRepository : IRepository<FineSetup>
    {
        Task<List<FineSetup>> GetAllFineSetupAsync();
    }
    public class FineSetupRepository : Repository<FineSetup>, IFineSetupRepository
    {
        public FineSetupRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<FineSetup>> GetAllFineSetupAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
