using ClientDemoAngular.Server.Domain.Entities;
using ClientDemoAngular.Server.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClientDemoAngular.Server.DataBase.Repositories;

public class SocialMediaRepository : DbRepository<SocialMedia>, ISocialMediaRepository
{
    public SocialMediaRepository(DbContext context) : base(context)
    {
    }
}