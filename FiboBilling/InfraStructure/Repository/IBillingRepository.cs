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
    public interface IBillingRepository : IRepository<Billing>
    {
        Task<List<Billing>> GetAllBillingAsync();
    }
    public class BillingRepository : Repository<Billing>, IBillingRepository
    {
        public BillingRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Billing>> GetAllBillingAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
