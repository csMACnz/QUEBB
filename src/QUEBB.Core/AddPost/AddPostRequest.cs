using System;
using QUEBB.Core.Entities;

namespace QUEBB.Core.AddPost
{
    public class AddPostRequest
    {
        public AddPostRequest(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }
            Post = post;
        }

        public Post Post { get; private set; }
    }
}
