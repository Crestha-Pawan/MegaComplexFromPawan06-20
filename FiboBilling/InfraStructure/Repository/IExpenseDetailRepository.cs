using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboBilling;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboBilling.InfraStructure.Repository
{
    public interface IExpenseDetailRepository : IRepository<ExpenseDetail>
    {
        Task<List<ExpenseDetail>> GetAllExpenseDetailAsync();
        Task<List<ExpenseDetail>> GetAllExpenseDetailById(long Id);
    }
    public class ExpenseDetailRepository : Repository<ExpenseDetail>, IExpenseDetailRepository
    {
        public ExpenseDetailRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<ExpenseDetail>> GetAllExpenseDetailAsync()
        {
            return await GetAllAsync().ToListAsync();
        }

        public async Task<List<ExpenseDetail>> GetAllExpenseDetailById(long Id)
        {
            return await GetAllAsync().Where(x => x.ExpenseId == Id).ToListAsync();
        }
    }
}
