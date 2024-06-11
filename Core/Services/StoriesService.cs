using AutoMapper;
using Core.Interfaces.Services;
using Domain.DTO_s;

namespace Core.Services
{
    public class StoriesService : IStoriesService
    {
        private readonly IMapper _mapper;
        private readonly IHackerNewsAPIService _apiService;

        public StoriesService(
            IMapper mapper,
            IHackerNewsAPIService apiService)
        {
            _mapper = mapper;
            _apiService = apiService;
        }

        /// <summary>
        /// It dgts a list of stories with their respective fields.
        /// </summary>
        /// <param name="storiesNumber">Number of stories to retrieve.</param>
        /// <returns>
        /// A list of StoryDTO objects that represent the retrieved stories,
        /// ordered by score from highest to lowest.
        /// </returns>
        public async Task<List<StoryDTO>> GetStories(int storiesNumber)
        {
            try
            {
                IEnumerable<long> ids = new List<long>();
                ids = await _apiService.GetStoryIds(storiesNumber);

                List<StoryDTO> stories = new List<StoryDTO>();

                foreach (var id in ids)
                {
                    StoryDTO storyDto = await BuildStory(id);
                    stories.Add(storyDto);
                }

                return stories.OrderByDescending(x => x.Score).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        /// <summary>
        /// It builds a StoryDTO object from a story ID.
        /// </summary>
        /// <param name="storyId">The ID of the story to build.</param>
        /// <returns>
        /// A StoryDTO object that represents the story corresponding to the given ID.
        /// </returns>
        public async Task<StoryDTO> BuildStory(long storyId)
        {
            try
            {
                var story = await _apiService.GetStoryById(storyId);

                var storyDto = _mapper.Map<StoryDTO>(story);

                return storyDto;

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
