using System.Text;
using B2B.Application.ACLs.SMS;
using B2B.Application.CommandHandlers;
using B2B.Application.Services.BaseInfo.City;
using B2B.CommandDb;
using B2B.CommandDB;
using B2B.CommandDb.Repository;
using B2B.Configurations.Swagger;
using B2B.Domain.Identity;
using B2B.Framework.Contracts.Extensions;
using B2B.Framework.Contracts.Makers;
using B2B.Framework.Contracts.Markers;
using B2B.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace B2B.Configurations.RegisterTypes;

public static class ConfigureServicesExtension
{
    public static void AddCommandsDBContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<BaseProjectCommandDb>(
            (provider, options) =>
            {
                //options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
                options.UseSqlServer(connectionString, builder =>
                {
                    builder.EnableRetryOnFailure(
                        5,
                        TimeSpan.FromSeconds(100),
                        null);
                });
                options.AddInterceptors(provider.GetRequiredService<BaseProjectDbContextSaveChangesInterceptor>());
            }
        );
    }

    public static void AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var conn = configuration.GetConnectionString("B2B");
        services.AddSettings(configuration);
        services.AddScoped<BaseProjectDbContextSaveChangesInterceptor>();
        //services.AddScoped<DefaultDataInitializer>();
        services.AddHttpClient();
        services.AddHttpContextAccessor();
        services.AddCommandsDBContext(conn);
        services.AddWithContract();
        //services.AddAuthenticationSettings();
        services.AddCors();
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
    }

    public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSetting>(options => configuration.GetSection("JWT").Bind(options));
        services.Configure<SmsSetting>(options => configuration.GetSection("Sms").Bind(options));
    }

    public static void AddConfigureAllServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddVersion();
        services.AddSwagger();

        services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
        ;
        var key = Encoding.ASCII.GetBytes("@#MY_BIG_SECRET_KEY@#");

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.Events = new JwtBearerEvents
            {
                OnTokenValidated = context => { return Task.CompletedTask; }
            };
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        //TODO : Should Read
        //services.AddControllers(options =>
        //{
        //    options.ModelBinderProviders.Insert(0, new EnumsModelBinderProvider());
        //}).AddNewtonsoftJson(options =>
        //{
        //    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        //});
        AddConfigureServices(services, configuration);
    }

    private static void AddVersion(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
        });
    }

    public static void AddWithContract(this IServiceCollection serviceCollection)
    {
        AddACLs(serviceCollection, typeof(IAcl));
        AddRepositories(serviceCollection, typeof(IRepository));
        AddApplicationServices(serviceCollection, typeof(IService));

        AddIdentityUser(serviceCollection, typeof(ApplicationUser));
        AddCommandHandlers(serviceCollection, typeof(IQueryHandler<,>));
        AddCommandHandlers(serviceCollection, typeof(ICommandHandler<,>));


        serviceCollection.AddSingleton<IDistributor>(new Handler(serviceCollection));
    }

    private static void AddCommandHandlers(IServiceCollection serviceCollection, Type handlerInterface)
    {
        ConfigureReflectionExtension.AddInterfacesWithAssemblyReference(typeof(CreateProjectCommandHandler).Assembly,
            serviceCollection, handlerInterface);
    }

    private static void AddRepositories(IServiceCollection serviceCollection, Type handlerInterface)
    {
        ConfigureReflectionExtension.AddInterfacesWithAssemblyReference(typeof(ProjectRepository).Assembly,
            serviceCollection, handlerInterface);
    }

    private static void AddApplicationServices(IServiceCollection serviceCollection, Type handlerInterface)
    {
        ConfigureReflectionExtension.AddInterfacesWithAssemblyReference(typeof(CityService).Assembly,
            serviceCollection, handlerInterface);
    }

    private static void AddIdentityUser(IServiceCollection serviceCollection, Type handlerInterface)
    {
        ConfigureReflectionExtension.AddInterfacesWithAssemblyReference(typeof(ApplicationUser).Assembly,
            serviceCollection, handlerInterface);
    }

    private static void AddACLs(IServiceCollection serviceCollection, Type handlerInterface)
    {
        ConfigureReflectionExtension.AddInterfacesWithAssemblyReference(typeof(SmsAcl).Assembly,
            serviceCollection, handlerInterface);
    }
}