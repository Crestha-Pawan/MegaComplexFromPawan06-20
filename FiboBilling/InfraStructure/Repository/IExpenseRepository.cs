
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
  
    public interface IExpenseRepository : IRepository<Expense>
    {
        Task<List<Expense>> GetAllExpense();
        IQueryable<Expense> GetAllExpenses();
        IQueryable<Expense> GetAllExpenseByFilter(string searchString);
    }

    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Expense>> GetAllExpense()
        {
            return await GetAllAsync().ToListAsync();
        }
        public IQueryable<Expense> GetAllExpenses()
        {
            return GetAllAsync();
        }


        public IQueryable<Expense> GetAllExpenseByFilter(string searchString = null)
        {
            return GetAllAsync().Where(x =>
                                           x.Name.Trim().ToLower().Contains(searchString.Trim().ToLower())) ;
        }
    }
}
