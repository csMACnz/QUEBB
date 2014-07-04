using System;
using QUEBB.Core.Boundary;
using QUEBB.Core.Entities;

namespace QUEBB.Core.AddPost
{
    public class AddPostHandler
    {
        public AddPostResponse Handle(IRepository repository, AddPostRequest request)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            var id = repository.StorePost(new Post {Id = "newId", Title = request.Post.Title});
            var post = repository.GetPost(id);

            return new AddPostResponse(post);
        }
    }
}
