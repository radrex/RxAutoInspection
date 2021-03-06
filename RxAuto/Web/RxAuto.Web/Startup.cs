namespace RxAuto.Web
{
    using RxAuto.Data;
    using RxAuto.Data.Models;
    using RxAuto.Data.Seeding;

    using RxAuto.Services.Data;
    using RxAuto.Services.Data.Implementations;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class Startup
    {
        //---------------- FIELDS -----------------
        private readonly IConfiguration configuration;

        //------------- CONSTRUCTORS --------------
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //--------------- METHODS -----------------
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions).AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()); // CSRF
            //});

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSingleton(this.configuration);

            // Application services
            services.AddTransient<IQualificationsService, QualificationsService>();
            services.AddTransient<IJobPositionsService, JobPositionsService>();
            services.AddTransient<IEmployeesService, EmployeesService>();
            services.AddTransient<IPhonesService, PhonesService>();
            services.AddTransient<IOperatingLocationsService, OperatingLocationsService>();
            services.AddTransient<IDepartmentsService, DepartmentsService>();
            services.AddTransient<IPhonesService, PhonesService>();
            services.AddTransient<IServiceTypesService, ServiceTypesService>();
            services.AddTransient<IServicesService, ServicesService>();
            services.AddTransient<IDocumentsService, DocumentsService>();
            services.AddTransient<IVehicleTypesService, VehicleTypesService>();
            services.AddTransient<IReservationsService, ReservationsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "serviceType", pattern: "Services/{name}", new { controller = "ServiceTypes", action = "ByName" });
                endpoints.MapControllerRoute(name: "areaRoute", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
