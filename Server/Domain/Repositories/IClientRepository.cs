using ClientDemoAngular.Server.DataBase.Repositories;
using ClientDemoAngular.Server.Domain.Entities;
using ClientDemoAngular.Server.Domain.Repositories.Abstract;
using ClientDemoAngular.Server.ViewModels.Client;

namespace ClientDemoAngular.Server.Domain.Repositories;

public interface IClientRepository : IDbRepository<Client>
{
}