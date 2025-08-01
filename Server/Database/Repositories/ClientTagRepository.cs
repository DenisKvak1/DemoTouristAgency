using ClientDemoAngular.Server.Domain.Entities;
using ClientDemoAngular.Server.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClientDemoAngular.Server.DataBase.Repositories;

public class ClientTagRepository : DbRepository<ClientTag>, IClientTagRepository
{
    public ClientTagRepository(DbContext context) : base(context)
    {
    }
}