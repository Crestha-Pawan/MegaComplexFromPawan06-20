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
    public interface IClientRoomMaintenanceRepository : IRepository<ClientRoomMaintenance>
    {
        Task<List<ClientRoomMaintenance>> GetAllClientRoomMaintenanceAsync();
    }
    public class ClientRoomMaintenanceRepository : Repository<ClientRoomMaintenance>, IClientRoomMaintenanceRepository
    {
        public ClientRoomMaintenanceRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<ClientRoomMaintenance>> GetAllClientRoomMaintenanceAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
