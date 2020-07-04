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

namespace WebApi_SP
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
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://85.240.156.204")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                        builder.WithOrigins("http://94.61.228.206")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            services.AddMvc()
                .ConfigureApiBehaviorOptions(options => {
                    options.SuppressModelStateInvalidFilter = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
                
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => {
                builder.WithOrigins("http://85.240.156.204");
                builder.WithOrigins("http://94.61.228.206");
            }
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
