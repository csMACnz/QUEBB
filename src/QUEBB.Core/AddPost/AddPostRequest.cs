using System;
using QUEBB.Core.Entities;

namespace QUEBB.Core.AddPost
{
    public class AddPostRequest
    {
        public AddPostRequest(NewPost post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }
            Post = post;
        }

        public NewPost Post { get; private set; }
    }
}
