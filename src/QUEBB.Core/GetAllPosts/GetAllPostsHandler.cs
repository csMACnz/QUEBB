using System;
using System.Linq;
using QUEBB.Core.Boundary;

namespace QUEBB.Core.GetAllPosts
{
    public class GetAllPostsHandler
    {
        private readonly IRepository _repository;

        public GetAllPostsHandler(IRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            _repository = repository;
        }

        public GetAllPostsResponse Handle(GetAllPostsRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            var posts = _repository.GetPosts();

            return new GetAllPostsResponse(posts);
        }
    }
}
