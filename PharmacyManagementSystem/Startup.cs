using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PharmacyManagementSystem.Helper;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Repository;
using pharmacyManagementWebApiservice.Repository;


namespace SimpleAuthProject
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
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            _ = services.AddDbContext<Pharmacy_Management1Context>(options => options.UseSqlServer(Configuration["ConnectionString:DefaultConnection"]));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISuplierRepository, SupplierRepository>();
            services.AddScoped<IDrugRepository, DrugRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrdersRepostiory, OrdersRepository>();
            services.AddScoped<JwtService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiCore", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserMAnagementApi v1"));
            }

            app.UseRouting();
            app.UseCors(options => options
            .WithOrigins(new[] { "http://localhost:3000" })
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}