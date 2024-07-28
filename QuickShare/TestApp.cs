using Microsoft.EntityFrameworkCore;
using QuickShare.Data;
using QuickShare.Data.Entities;
using QuickShare.Services;
using QuickShare.Services.Interfaces;
using Newtonsoft.Json;

namespace QuickShare;

public class TestApp
{
    private readonly ApplicationDbContext _dbContext;
    private ISpaceService _spaceService;
    private IEntryService _entryService;
    
    public TestApp(ApplicationDbContext dbContext, ISpaceService spaceService, IEntryService entryService)
    {
        _dbContext = dbContext;
        _spaceService = spaceService;
        _entryService = entryService;
    }

    public async Task Start1()
    {
        var entity1 = new SpaceEntity()
        {
            Slug = "1q2w",
            TTL = 3600,
        };
        _dbContext.Spaces.Add(entity1);
        
        await _dbContext.SaveChangesAsync();
        
        
        Console.WriteLine("entity1.Id");
        Console.WriteLine(entity1.Id);
    }
    
    public async Task Start2()
    {

        var entity = await _dbContext.Spaces.FirstOrDefaultAsync();
        
        Console.WriteLine("_______entity data________");
        Console.WriteLine(entity.Id);
        Console.WriteLine(entity.Slug);
        Console.WriteLine(entity.TTL);
    }
    
    public async Task Start3()
    {
        var newSpace = await _spaceService.CreateSpace(5, 3600);
        
        Console.WriteLine("Slg");
        Console.WriteLine(newSpace.Slug);

        var entity = await _entryService.CreateEntry(newSpace.Id, "Lorem Ipsum Dolor 333");
        
        Console.WriteLine("Entity");
        Console.WriteLine(entity);

        var space = await _spaceService.GetSpace(newSpace.Slug);

        var json = JsonConvert.SerializeObject(space,
            new JsonSerializerSettings {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        
        Console.WriteLine(json);
    }
} 