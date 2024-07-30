using QuickShare.Data.Entities;
using QuickShare.Models.Dtos;

namespace QuickShare.Services.Interfaces;

public interface ISpaceService
{
    Task<string> CreateSpace(int length, int ttl);
    Task<bool> DeleteSpace(int id);
    Task<SpaceDto?> GetSpace(string slug);
}