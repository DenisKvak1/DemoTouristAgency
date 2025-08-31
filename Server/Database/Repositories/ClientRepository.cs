using ClientDemoAngular.Server.Domain.Abstract;
using ClientDemoAngular.Server.Domain.Entities;
using ClientDemoAngular.Server.Domain.Repositories;
using ClientDemoAngular.Server.ViewModels.Client;
using Microsoft.EntityFrameworkCore;

namespace ClientDemoAngular.Server.DataBase.Repositories;

public class ClientRepository : DbRepository<Client>, IClientRepository
{
    private DbSet<ClientPhone> Phones;

    public ClientRepository(DbContext context) : base(context)
    {
        Phones = _context.Set<ClientPhone>();
    }

    public async Task<bool> UpdateItemAsync(Client client)
    {
        
        _context.Update(client);

        return await _context.SaveChangesAsync() > 0;
    }

    public async new Task<bool> AddItemAsync(Client item)
    {
        item.Tags.ForEach(tag => { _context.Entry(tag).State = EntityState.Unchanged; });

        foreach (SocialMedia socialMedia in item.Phones
                     .SelectMany(x => x.SocialMedias)
                     .DistinctBy(x => x.Id))
        {
            _context.Entry(socialMedia).State = EntityState.Unchanged;
        }
        return await base.AddItemAsync(item);
    }
}