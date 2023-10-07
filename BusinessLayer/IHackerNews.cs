using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IHackerNews
    {
        public  Task<Story> StoryDetails(string id);

        public Task<IEnumerable<Story>> TopStoriesDetails(IEnumerable<int> storiesId);

        public Task<IEnumerable<int>> TopStoriesId();
    }
}
