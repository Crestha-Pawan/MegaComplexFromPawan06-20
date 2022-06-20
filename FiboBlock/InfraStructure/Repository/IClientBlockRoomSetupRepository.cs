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
    public interface IClientBlockRoomSetupRepository : IRepository<ClientBlockRoomSetup>
    {
        Task<List<ClientBlockRoomSetup>> GetAllClientBlockRoomSetupAsync();
    }
    public class ClientBlockRoomSetupRepository : Repository<ClientBlockRoomSetup>, IClientBlockRoomSetupRepository
    {
        public ClientBlockRoomSetupRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<ClientBlockRoomSetup>> GetAllClientBlockRoomSetupAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
