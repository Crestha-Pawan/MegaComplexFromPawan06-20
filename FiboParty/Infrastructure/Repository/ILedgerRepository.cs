
using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.Ledger;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboParty.Infrastructure.Repository
{
    public interface ILedgerRepository : IRepository<Ledger>
    {
        Task<List<Ledger>> GetAllLedgerAsync();
    }
    public class LedgerRepository : Repository<Ledger>, ILedgerRepository
    {
        public LedgerRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<List<Ledger>> GetAllLedgerAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
