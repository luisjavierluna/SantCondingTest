
using Domain.DTO_s;

namespace Core.Interfaces.Services
{
    public interface IStoriesService
    {
        Task<List<StoryDTO>> GetStories(int n);
        Task<StoryDTO> BuildStory(long storyId);
    }
}
