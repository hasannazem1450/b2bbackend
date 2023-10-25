using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.MessageCodes.IdentityPersianErrorsHandler;
using B2B.CommandDB;
using B2B.Configurations.RegisterTypes;
using B2B.Configurations.Swagger;
using B2B.Domain.Identity;
using B2B.Framework.Contracts.Abstracts;
using B2B.Host.Middleware;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace B2B
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var defaultDataConfig = Configuration.GetSection("defaultData");

            services.AddHealthChecks();

            services.AddIdentity<ApplicationUser,  IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.User.AllowedUserNameCharacters = "0123456789";
                })
                .AddEntityFrameworkStores<BaseProjectCommandDb>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<PersianIdentityErrorDescriber>();

            var key = Encoding.ASCII.GetBytes("@#MY_BIG_SECRET_KEY@#");


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "B2B.Host", Version = "v1" });
            });

            //services.Configure<DefaultDataSchemas>(defaultDataConfig);

            services.AddConfigureAllServices(Configuration);
            services.AddOptions();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                //app.ConfigureSystemMessages(serviceProvider, assemblies);

                //app.InitializerExecute(serviceProvider);

                app.SwaggerConfigure();

                //var detectionAccessibleForms = serviceProvider.GetRequiredService(typeof(DetectionAccessibleForms)) as DetectionAccessibleForms;

                //detectionAccessibleForms.StartExploring();
            }

            app.UseSwagger();

            app.SwaggerConfigure();

            app.UseCors(
                options => options.WithOrigins("*").AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
            );

            app.UseMiddleware<CustomExceptionMiddleware>();

            app.UseHsts();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/healthcheck");
                endpoints.MapControllers();
            });
        }
    }
}
