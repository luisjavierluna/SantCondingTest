using Domain.Models;

namespace Core.Interfaces.Services
{
    public interface IHackerNewsAPIService
    {
        Task<Story> GetStoryById(long storyId);
        Task<IEnumerable<long>> GetStoryIds(int IdsNumber);
    }
}
