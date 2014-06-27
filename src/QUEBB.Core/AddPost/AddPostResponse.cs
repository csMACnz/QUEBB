using System;
using QUEBB.Core.Entities;

namespace QUEBB.Core.AddPost
{
    public class AddPostResponse
    {
        private readonly Post _post;

        public AddPostResponse(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }
            _post = post;
        }

        public Post Post
        {
            get { return _post; }
        }
    }
}
