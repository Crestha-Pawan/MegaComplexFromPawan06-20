using CItyCenterSystem.Permission;
using FiboAddress.InfraStructure.Assembler;
using FiboAddress.InfraStructure.Repository;
using FiboAddress.InfraStructure.Service;
using FiboBilling.InfraStructure.Assembler;
using FiboBilling.InfraStructure.Repository;
using FiboBilling.InfraStructure.Service;
using FiboBlock.InfraStructure.Assembler;
using FiboBlock.InfraStructure.Repository;
using FiboBlock.InfraStructure.Service;
using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboOffice.InfraStructure.Assembler;
using FiboOffice.InfraStructure.Repository;
using FiboOffice.InfraStructure.Service;
using FiboParty.Infrastructure.Assembler;
using FiboParty.Infrastructure.Repository;
using FiboParty.Infrastructure.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Payroll.InfraStructure.Assembler;
using Payroll.InfraStructure.Repository;
using Payroll.InfraStructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CItyCenterSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("CityCenterSystem"), x => x.MigrationsAssembly("FiboInfraStructure")));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(24);
            });
            
            //client
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IClientAssembler, ClientAssembler>();
            services.AddTransient<IClientService, ClientService>();

            //Room
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IRoomAssembler, RoomAssembler>();
            services.AddTransient<IRoomService, RoomService>();

            //Block
            services.AddTransient<IBlockRepository, BlockRepository>();
            services.AddTransient<IBlockAssembler, BlockAssembler>();
            services.AddTransient<IBlockService, BlockService>();

            //Electricity
            services.AddTransient<IElectricityRepository, ElectricityRepository>();
            services.AddTransient<IElectricityAssembler, ElectricityAssembler>();
            services.AddTransient<IElectricityService, ElectricityService>();
            //Billing
            services.AddTransient<IBillingRepository, BillingRepository>();
            services.AddTransient<IBillingAssembler, BillingAssembler>();
            services.AddTransient<IBillingService, BillingService>();
            //Billing Detail
            services.AddTransient<IBillingDetailRepository, BillingDetailRepository>();
            services.AddTransient<IBillingDetailAssembler, BillingDetailAssembler>();
            services.AddTransient<IBillingDetailService, BillingDetailService>();

            //Month Year
            services.AddTransient<IMonthRepository, MonthRepository>();
            services.AddTransient<IYearRepository, YearRepository>();
            //Office
            services.AddTransient<IOfficeRepository, OfficeRepository>();
            services.AddTransient<IOfficeAssembler, OfficeAssembler>();
            services.AddTransient<IOfficeService, OfficeService>();

            services.AddTransient<IProvienceRepository, ProvienceRepository>();
            services.AddTransient<IProvienceAssembler, ProvienceAssembler>();
            services.AddTransient<IProvienceService, ProvienceService>();

            services.AddTransient<IDistrictRepository, DistrictRepository>();
            services.AddTransient<IDistrictAssembler, DistrictAssembler>();
            services.AddTransient<IDistrictService, DistrictService>();

            services.AddTransient<ILocalLevelRepository, LocalLevelRepository>();
            services.AddTransient<ILocalLevelAssembler, LocalLevelAssembler>();
            services.AddTransient<ILocalLevelService, LocalLevelService>();

            services.AddTransient<IElectricityUnitSetupRepository, ElectricityUnitSetupRepository>();
            services.AddTransient<IElectricityUnitSetupAssembler, ElectricityUnitSetupAssembler>();
            services.AddTransient<IElectricityUnitSetupService, ElectricityUnitSetupService>();

            services.AddTransient<IFineSetupRepository, FineSetupRepository>();
            services.AddTransient<IFineSetupAssembler, FineSetupAssembler>();
            services.AddTransient<IFineSetupService, FineSetupService>();


            services.AddTransient<IClientBlockRoomSetupRepository, ClientBlockRoomSetupRepository>();
            services.AddTransient<IClientBlockRoomSetupAssembler, ClientBlockRoomSetupAssembler>();
            services.AddTransient<IClientBlockRoomSetupService, ClientBlockRoomSetupService>();

            services.AddTransient<IElectricityFineSetupRepository, ElectricityFineSetupRepository>();
            services.AddTransient<IElectricityFineSetupAssembler, ElectricityFineSetupAssembler>();
            services.AddTransient<IElectricityFineSetupService, ElectricityFineSetupService>();

            //Party
            services.AddTransient<IPartyRepository, PartyRepository>();
            services.AddTransient<IPartyService, PartyService>();
            services.AddTransient<IPartyAssembler, PartyAssembler>();

            //Ledger//
            services.AddTransient<ILedgerRepository, LedgerRepository>();
            services.AddTransient<ILedgerService, LedgerService>();
            services.AddTransient<ILedgerAssembler, LedgerAssembler>();

            //LedgerDetails//
            services.AddTransient<ILedgerDetailRepository, LedgerDetailRepository>();
            services.AddTransient<ILedgerDetailService, LedgerDetailService>();
            services.AddTransient<ILedgerDetailAssembler, LedgerDetailAssembler>();

            //FiscalYear//
            services.AddTransient<IFiscalYearRepository, FiscalYearRepository>();
            services.AddTransient<IFiscalYearService, FiscalYearService>();
            services.AddTransient<IFiscalYearAssembler, FiscalYearAssembler>();

            //Espense//
            services.AddTransient<IExpenseRepository, ExpenseRepository>();
            services.AddTransient<IExpenseService, ExpenseService>();
            services.AddTransient<IExpenseAssembler, ExpenseAssembler>();

            //EspenseDetail//
            services.AddTransient<IExpenseDetailRepository, ExpenseDetailRepository>();
            services.AddTransient<IExpenseDetailService, ExpenseDetailService>();
            services.AddTransient<IExpenseDetailAssembler, ExpenseDetailAssembler>();

            //Employee
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeAssembler, EmployeeAssembler>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            //Post
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostAssembler, PostAssembler>();
            services.AddTransient<IPostService, PostService>();

            //Salary Sheet
            services.AddTransient<ISalarySheetRepository, SalarySheetRepository>();
            services.AddTransient<ISalarySheetService, SalarySheetService>();
            services.AddTransient<ISalarySheetAssembler, SalarySheetAssembler>();

            //Maintenance Charge
            services.AddTransient<IClientRoomMaintenanceRepository, ClientRoomMaintenanceRepository>();
            services.AddTransient<IClientRoomMaintenanceService, ClientRoomMaintenanceService>();
            services.AddTransient<IClientRoomMaintenanceAssembler, ClientRoomMaintenanceAssembler>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddControllersWithViews();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = false;
            })

          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/login";
                options.Cookie.IsEssential = true;
                options.SlidingExpiration = true; // here 1
                options.ExpireTimeSpan = TimeSpan.FromSeconds(10);// here 2
            });


            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
