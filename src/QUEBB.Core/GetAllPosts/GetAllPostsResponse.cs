using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using QUEBB.Core.Entities;

namespace QUEBB.Core.GetAllPosts
{
    public class GetAllPostsResponse
    {
        public GetAllPostsResponse(IEnumerable<Post> posts)
        {
            Posts = new ReadOnlyCollection<Post>(posts.ToList());
        }

        public ReadOnlyCollection<Post> Posts { get; private set; }
    }
}