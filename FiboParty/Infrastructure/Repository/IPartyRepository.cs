using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboParty;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboParty.Infrastructure.Repository
{
    public interface IPartyRepository : IRepository<Party>
    {
        Task<List<Party>> GetAllPartyAsync();
    }
    public class PartyRepository : Repository<Party>, IPartyRepository
    {
        public PartyRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<List<Party>> GetAllPartyAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
