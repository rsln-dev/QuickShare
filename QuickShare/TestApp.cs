using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using QuickShare.Data;
using QuickShare.Data.Entities;

namespace QuickShare;

public class TestApp
{
    private ApplicationDbContext _dbContext;
    
    public TestApp(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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
}