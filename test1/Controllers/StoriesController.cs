using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IStoriesService _storiesService;

        public StoriesController(IStoriesService storiesService)
        {
            _storiesService = storiesService;
        }

        /// <summary>
        /// It gets a list of the best stories.
        /// </summary>
        /// <param name="storiesNumber">Number of stories to retrieve.</param>
        /// <returns>
        /// An IActionResult object that represents the HTTP response.
        /// If the operation succeeds, it returns an Ok result with the list of stories.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetBestStories(int storiesNumber)
        {
            try
            {
                var response = await _storiesService.GetStories(storiesNumber);

                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
