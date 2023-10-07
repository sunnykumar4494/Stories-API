
using Newtonsoft.Json;

namespace BusinessLayer
{
    public class HackerNews :IHackerNews
    {
        public async Task<Story> StoryDetails(string id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(
                "https://hacker-news.firebaseio.com/v0/item/" + id + ".json?print=pretty")
                .ConfigureAwait(false);
            var _story = JsonConvert.DeserializeObject<Story>(await response.Content.ReadAsStringAsync());

            return _story;
        }

        public async Task<IEnumerable<Story>> TopStoriesDetails(IEnumerable<int> storiesId)
        {

            var tasks = storiesId.Select(id => StoryDetails(id.ToString()));
            var stories = await Task.WhenAll(tasks);

            return stories;
        }

        public async Task<IEnumerable<int>> TopStoriesId()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(
                "https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty")
                .ConfigureAwait(false);
            var _storisID = JsonConvert.DeserializeObject<IEnumerable<int>>(await response.Content.ReadAsStringAsync());

            return _storisID;
        }

    }
}