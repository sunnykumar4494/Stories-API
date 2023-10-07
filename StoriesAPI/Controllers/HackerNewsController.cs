using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography.X509Certificates;

namespace StoriesAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HackerNewsController : ControllerBase
    {    
        private readonly IHackerNews _hackernews;
        //public HackerNews _hackernews;
        public HackerNewsController(IHackerNews hackernews)
        {
            _hackernews= hackernews;
        }
        [HttpGet(Name = "GetStoryDetails")]
        public  Story GetStoryDetails(string Id)
        {
            return _hackernews.StoryDetails(Id).Result;
        }

        [HttpGet(Name = "GetTopStories")]
        [ResponseCache(Duration =100)]
        public IEnumerable<Story> GetTopStories()
        {
            IEnumerable<int> _storiesId = _hackernews.TopStoriesId().Result.Take(10);
            IEnumerable<Story> _stories=_hackernews.TopStoriesDetails(_storiesId).Result;
            return _stories;
        }


    }
}
