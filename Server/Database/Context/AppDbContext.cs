using ClientDemoAngular.Server.DataBase.Configurations;
using ClientDemoAngular.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientDemoAngular.Server.DataBase.Context;

public class AppDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientPhone> ClientPhones { get; set; }
    public DbSet<ClientTag> ClientTags { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    
    protected AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientConfigure());
        modelBuilder.ApplyConfiguration(new ClientPhoneConfigure());
        modelBuilder.ApplyConfiguration(new ClientTagConfigure());
        modelBuilder.ApplyConfiguration(new SocialMediaConfigure());
        
        base.OnModelCreating(modelBuilder);
    }
}