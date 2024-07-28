using QuickShare.Data.Entities;

namespace QuickShare.Services.Interfaces;

public interface ISpaceService
{
    Task<SpaceEntity> CreateSpace(int length, int ttl);
    Task<bool> DeleteSpace(int id);
    Task<SpaceEntity> GetSpace(string slug);
}