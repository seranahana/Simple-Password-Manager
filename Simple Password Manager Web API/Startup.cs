using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SimplePM.Library.Repositories;
using SimplePM.Library.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SimplePM.WebAPI
{
    public class Startup
    {
        private IWebHostEnvironment _hostEnv;
        public Startup(IConfiguration configuration, IWebHostEnvironment hostEnv)
        {
            Configuration = configuration;
            _hostEnv = hostEnv;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string databasePath = System.IO.Path.Combine("..", "Assets.cs");
            services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false);
            services.AddDbContext<AssetsContext>(options => { options.UseSqlite($"Data Source={_hostEnv.ContentRootPath}/Assets.db"); });
            services.AddDataProtection();
            services.AddHttpClient(name: "SMP_Service", 
                configureClient: options =>
                {
                    options.BaseAddress = new Uri("https://localhost:5001/");
                    options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json", 1.0));
                });
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IUserDataRepository, UserDataRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Simple_Password_Manager_Web_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple_Password_Manager_Web_API v1");
                    c.SupportedSubmitMethods(new[] { SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Put, SubmitMethod.Delete, SubmitMethod.Patch });
                });
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
