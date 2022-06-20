using FiboInfraStructure.Entity.FiboAddress;
using FiboInfraStructure.Entity.FiboBilling;
using FiboInfraStructure.Entity.FiboBlock;
using FiboInfraStructure.Entity.FiboOffice;
using FiboInfraStructure.Entity.FiboParty;
using FiboInfraStructure.Entity.Ledger;
using FiboInfraStructure.Entity.Payroll;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboInfraStructure.Data
{
    public class ApplicationUser : IdentityUser
    {

    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Block> Blocks { get; set; }
        public virtual DbSet<Electricity> Electricities { get; set; }
        public virtual DbSet<Billing> Billings { get; set; }
        public virtual DbSet<BillingDetail> BillingDetails { get; set; }
        public virtual DbSet<Month> Months { get; set; }
        public virtual DbSet<Year> Years { get; set; }
        public virtual DbSet<Provience> Proviences { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<LocalLevel> LocalLevels { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<ElectricityUnitSetup> ElectricityUnitSetups { get; set; }

        public virtual DbSet<FineSetup> FineSetups { get; set; }
        public virtual DbSet<ElectricityFineSetup> ElectricityFineSetups { get; set; }

        public virtual DbSet<ClientBlockRoomSetup> ClientBlockRoomSetups { get; set; }

        public virtual DbSet<FiscalYear> FiscalYears { get; set; }
        //Party//
        public virtual DbSet<Party> Parties { get; set; }

        //Ledger//
        public virtual DbSet<Ledger> Ledgers { get; set; }

        //LedgerDetails//
        public virtual DbSet<LedgerDetail> LedgerDetails { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<ExpenseDetail> ExpenseDetails { get; set; }

        //Payroll
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<SalarySheet> SalarySheets { get; set; }
        public virtual DbSet<ClientRoomMaintenance> ClientRoomMaintenances { get; set; }
    }
}
