using ManageIdentity.Data;
using ManageIdentity.Models;
using ManageIdentity.Repositories;
using ManageIdentity.Repositories.IRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageIdentity
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

            services.AddDbContext<SignUpDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SignUpConnectionString")));

            //Add identity for the application user with default identity role of identity core.
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<SignUpDbContext>().AddDefaultTokenProviders();

            services.AddTransient<ISignUpRepository, SignUpRepository>();

            services.AddSwaggerGen(options => options.SwaggerDoc("SignUpIdentityAPI", new OpenApiInfo
            {
                Title = "Manage Identiy",
                Description = "Entity Framework Core ManageIdentity"

            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/SignUpIdentityAPI/swagger.json", "SignUp Identity API"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
