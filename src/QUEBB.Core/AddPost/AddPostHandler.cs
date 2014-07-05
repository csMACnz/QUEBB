using System;
using QUEBB.Core.Boundary;
using QUEBB.Core.Entities;
using QUEBB.Core.Infrastructure;

namespace QUEBB.Core.AddPost
{
    public class AddPostHandler
    {
        private readonly IRepository _repository;
        
        public AddPostHandler(IRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            _repository = repository;
        }

        public AddPostResponse Handle(AddPostRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            
            //validation
            if (request.Post.Id != null)
            {
                throw new ValidationException();
            }
            if (request.Post.Title == null)
            {
                throw new ValidationException();
            }
            
            //Handle
            var id = _repository.StorePost(new Post {Title = request.Post.Title});

            var post = _repository.GetPost(id);

            return new AddPostResponse(post);
        }
    }
}
