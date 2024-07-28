using Microsoft.EntityFrameworkCore;
using QuickShare.Data;
using QuickShare.Data.Entities;
using QuickShare.Services.Interfaces;

namespace QuickShare.Services;

public class EntryService : IEntryService
{
    private readonly ApplicationDbContext _dbContext;

    public EntryService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateEntry(int spaceId, string? text)
    {
        var newEntry = new EntryEntity()
        {
            Type = text == null ? EntryType.Other : EntryType.Text,
            SpaceId = spaceId,
            Text = text
        };
        _dbContext.Entries.Add(newEntry);
        
        await _dbContext.SaveChangesAsync();

        return newEntry.Id > 0;
    }
    
    public async Task<bool> DeleteEntry(int id)
    {
        var entity = await _dbContext.Entries.FirstOrDefaultAsync(el => el.Id == id);

        if (entity == null)
        {
            return false;
        }

        _dbContext.Entry(entity).State = EntityState.Deleted;
        
        await _dbContext.SaveChangesAsync();

        return true;
    } 
    
    public async Task<bool> UpdateTextEntry(int id, string newText)
    {
        var entity = await _dbContext.Entries.FirstOrDefaultAsync(el => el.Id == id);

        if (entity?.Text == null)
        {
            return false;
        }

        entity.Text = newText; 

        _dbContext.Entry(entity).CurrentValues.SetValues(entity);
        await _dbContext.SaveChangesAsync();

        return true;
    } 
}