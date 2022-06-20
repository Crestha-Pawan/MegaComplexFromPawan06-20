using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.Payroll;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.InfraStructure.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<List<Employee>> GetAllEmployeeAsync();
        Task<Employee> GetEmployee(string email);
    }
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            return await GetAllAsync().ToListAsync();
        }

        public async Task<Employee> GetEmployee(string email)
        {
            return await GetAllAsync().Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }

}
