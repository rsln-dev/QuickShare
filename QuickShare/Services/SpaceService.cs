using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuickShare.Data;
using QuickShare.Data.Entities;
using QuickShare.Models.Dtos;
using QuickShare.Services.Interfaces;

namespace QuickShare.Services;

public class SpaceService : ISpaceService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly SlugService _slugService;
    private readonly IMapper _mapper;

    public SpaceService(ApplicationDbContext dbContext, SlugService slugService, IMapper mapper)
    {
        _dbContext = dbContext;
        _slugService = slugService;
        _mapper = mapper;
    }

    public async Task<string> CreateSpace(int length, int ttl)
    {
        var newSpace = new SpaceEntity()
        {
            Slug = _slugService.Generate(length),
            TTL = ttl,
        };
        _dbContext.Spaces.Add(newSpace);

        await _dbContext.SaveChangesAsync();

        return newSpace.Slug;
    }

    public async Task<bool> DeleteSpace(int id)
    {
        var entity = await _dbContext.Spaces.FirstOrDefaultAsync(el => el.Id == id);

        if (entity == null)
        {
            return false;
        }

        _dbContext.Entry(entity).State = EntityState.Deleted;

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<SpaceDto?> GetSpace(string slug)
    {
        var space = await _dbContext.Spaces.Include(s => s.Entries).FirstOrDefaultAsync(el => el.Slug == slug);

        return _mapper.Map<SpaceDto>(space);
    }
}