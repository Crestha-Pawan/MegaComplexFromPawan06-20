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
    public interface IElectricityRepository : IRepository<Electricity>
    {
        Task<List<Electricity>> GetAllElectricityAsync();
    }
    public class ElectricityRepository : Repository<Electricity>, IElectricityRepository
    {
        public ElectricityRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Electricity>> GetAllElectricityAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
