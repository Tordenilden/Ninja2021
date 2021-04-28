using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ninja2021.Models;
using Microsoft.EntityFrameworkCore;


namespace Ninja2021
{
    public class Startup
    {
        #region skrald
        /// <summary>
        /// svarer næsten til Main (det er ikke rigtigt det jeg skriver, men er for at give jer en ide om det)
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        #endregion skrald
        // expand .NET CORE
        public void ConfigureServices(IServiceCollection services) //DI hvad er dog det?
        {
            var connectionString = @"Server=TEC-5350-LA0052;Database=NinjaBlodig; Trusted_Connection=true";

            services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(connectionString));
            services.AddControllers()
                         .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // her siger vi til .NET CORE at vi vil benytte Swagger, så det er opsætning mm.
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

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
