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
    public interface IBlockRepository : IRepository<Block>
    {
        Task<List<Block>> GetAllBlockAsync();
    }
    public class BlockRepository : Repository<Block>, IBlockRepository
    {
        public BlockRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Block>> GetAllBlockAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
