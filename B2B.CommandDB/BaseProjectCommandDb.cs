using System.Linq.Expressions;
using B2B.Domain.BaseInfo;
using B2B.Domain.Event;
using B2B.Domain.Identity;
using B2B.Domain.News;
using B2B.Domain.ProductBase;
using B2B.Domain.Profile;
using B2B.Domain.Profile.FollowProfile;
using B2B.Domain.Profile.Member;
using B2B.Domain.Project;
using B2B.Domain.Sms;
using B2B.Domain.SystemMessages;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace B2B.CommandDB;

public sealed class BaseProjectCommandDb : IdentityDbContext<ApplicationUser>
{
    public BaseProjectCommandDb(DbContextOptions<BaseProjectCommandDb> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<SystemMessage> SystemMessages { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<IndustrialPark> IndustrialParks { get; set; }
    public DbSet<SmeProfile> SmeProfiles { get; set; }
    public DbSet<SmeRank> SmeRanks { get; set; }
    public DbSet<SmeRater> SmeRaters { get; set; }
    public DbSet<SmeMember> SmeMembers { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<EventInfo> EventInfos { get; set; }
    public DbSet<EventAttender> EventAttenders { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<FollowProfile> FollowProfiles { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SmsInfo> SmsInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var isDeletedProperty = entityType.FindProperty("IsDeleted");
            if (isDeletedProperty != null && isDeletedProperty.ClrType == typeof(bool))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "p");
                var filter = Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(parameter, isDeletedProperty.PropertyInfo),
                        Expression.Constant(false, typeof(bool))
                    )
                    , parameter);
                entityType.SetQueryFilter(filter);
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}

public class BaseProjectContextFactory : IDesignTimeDbContextFactory<BaseProjectCommandDb>
{
    public BaseProjectCommandDb CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BaseProjectCommandDb>();
        optionsBuilder.UseSqlServer(@"Data Source=.\\nsql;Initial Catalog=B2B;User Id=sa;Password=123;");

        return new BaseProjectCommandDb(optionsBuilder.Options);
    }
}