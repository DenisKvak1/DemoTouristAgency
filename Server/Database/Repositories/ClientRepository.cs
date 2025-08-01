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

    public async Task<bool> AddPhone(CreateClientPhoneVM model)
    {
        await Phones.AddAsync(new ClientPhone
        {
            Id = Guid.NewGuid(),
            ClientId = model.ClientId,
            Number = model.Number,
            SocialMedias = model.SocialMedias.Select(id => new SocialMedia { Id = id }).ToList()
        });
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task DeletePhone(Guid phoneId)
    {
        await Phones
            .Where(x => x.Id == phoneId)
            .ExecuteDeleteAsync();
    }

    private void UpdatePhones(Guid clientId, IEnumerable<ClientPhone> phones)
    {
        var deleted = Phones
            .Where(x => phones.All(y => y.ClientId != clientId))
            .ToListAsync();

        foreach (var phone in phones)
        {
            _context.Entry(phone).State = phone.Id == null ? EntityState.Added : EntityState.Modified;
        }
        _context.RemoveRange(deleted);
    }

    public async new Task<bool> AddItemAsync(Client item)
    {
        item.Tags.ForEach(tag => { _context.Entry(tag).State = EntityState.Unchanged; });
        item.Phones.ForEach(phone => phone.SocialMedias.ForEach(sm=>_context.Entry(sm).State = EntityState.Unchanged));
        return await base.AddItemAsync(item);
    }
}