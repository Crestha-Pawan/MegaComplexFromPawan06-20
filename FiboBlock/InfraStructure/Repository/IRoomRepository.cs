using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboBlock;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboBlock.InfraStructure.Repository
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<List<Room>> GetAllRoomAsync(); 
        Task<List<Room>> GetAllByRoomId(long id );
    
}
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Room>> GetAllRoomAsync()
        {
            return await GetAllAsync().ToListAsync();
        }

        public async Task<List<Room>> GetAllByRoomId(long id)
        {
            return await GetAllAsync().Where(x => x.Id == id).ToListAsync();
        }
    }
}