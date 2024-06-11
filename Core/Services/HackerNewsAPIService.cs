using Core.Interfaces.Services;
using Domain.Models;
using Newtonsoft.Json;

namespace Core.Services
{
    public class HackerNewsAPIService : IHackerNewsAPIService
    {
        private string baseUrl = "https://hacker-news.firebaseio.com/v0/";

        private readonly HttpClient _httpClient;

        public HackerNewsAPIService(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Retrieves a collection of the best story identifiers.
        /// </summary>
        /// <param name="IdsNumber">The number of story identifiers to retrieve.</param>
        /// <returns>
        /// A collection of long type identifiers representing the best stories, limited by the specified number.
        /// </returns>
        public async Task<IEnumerable<long>> GetStoryIds(int IdsNumber)
        {
            try
            {
                var endpoint = "beststories.json";

                var response = await _httpClient.GetAsync($"{baseUrl}{endpoint}");

                response.EnsureSuccessStatusCode();

                string content = response.Content.ReadAsStringAsync().Result;

                var storyIds = JsonConvert.DeserializeObject<List<long>>(content).Take(IdsNumber);

                return storyIds;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Retrieves a story by its unique identifier.
        /// </summary>
        /// <param name="storyId">The unique identifier of the story to retrieve.</param>
        /// <returns>
        /// The Task result contains the retrieved Story object.
        /// </returns>
        public async Task<Story> GetStoryById(long storyId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{baseUrl}item/{storyId}.json");

                response.EnsureSuccessStatusCode();

                string content = response.Content.ReadAsStringAsync().Result;

                var story = JsonConvert.DeserializeObject<Story>(content);

                return story;

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
