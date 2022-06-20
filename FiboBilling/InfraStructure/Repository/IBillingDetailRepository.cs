using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboBilling;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboBilling.InfraStructure.Repository
{
    public interface IBillingDetailRepository : IRepository<BillingDetail>
    {
        Task<List<BillingDetail>> GetAllBillingAsync();
    }
    public class BillingDetailRepository : Repository<BillingDetail>, IBillingDetailRepository
    {
        public BillingDetailRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<BillingDetail>> GetAllBillingAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
