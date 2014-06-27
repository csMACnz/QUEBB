using System;
using QUEBB.Core.Entities;

namespace QUEBB.Core.AddPost
{
    public class AddPostHandler
    {
        public AddPostResponse Handle(AddPostRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            return new AddPostResponse(new Post {Id = 1, Title = request.Post.Title});
        }
    }
}
