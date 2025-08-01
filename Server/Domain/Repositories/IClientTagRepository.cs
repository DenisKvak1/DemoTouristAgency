using ClientDemoAngular.Server.Domain.Entities;
using ClientDemoAngular.Server.Domain.Repositories.Abstract;

namespace ClientDemoAngular.Server.Domain.Repositories;

public interface IClientTagRepository : IDbRepository<ClientTag>
{
}