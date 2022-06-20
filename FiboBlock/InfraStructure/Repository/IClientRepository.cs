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
    public interface IClientRepository : IRepository<Client>
    {
        Task <List<Client>>GetAllClientAsync();
    }
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Client>> GetAllClientAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
