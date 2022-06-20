using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.Payroll;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.InfraStructure.Repository
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<List<Post>> GetAllPostAsync();
    }
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Post>> GetAllPostAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
