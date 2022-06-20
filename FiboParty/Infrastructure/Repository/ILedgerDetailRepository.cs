using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboParty;
using FiboInfraStructure.Entity.Ledger;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboParty.Infrastructure.Repository
{
    public interface ILedgerDetailRepository : IRepository<LedgerDetail>
    {
        Task<List<LedgerDetail>> GetAllLedgerDetailAsync();
        Task<List<LedgerDetail>> GetByLedgerDetailsId(long id);
    }
    public class LedgerDetailRepository : Repository<LedgerDetail>, ILedgerDetailRepository
    {
        public LedgerDetailRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<List<LedgerDetail>> GetAllLedgerDetailAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
        public async Task<List<LedgerDetail>> GetByLedgerDetailsId(long id)
        {
            return await GetAllAsync().Where(x => x.LedgerId == id).ToListAsync();
        }

    }
}
