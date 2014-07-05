using System;

namespace QUEBB.Core.Entities
{
    public class Post
    {
        public string Title { get; set; }

        public string Id { get; set; }

        public static Post Clone(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }
            return new Post
            {
                Id = post.Id,
                Title = post.Title
            };
        }
    }
}