using QUEBB.Core.AddPost;
using QUEBB.Core.Boundary;
using QUEBB.Core.GetAllPosts;

namespace QUEBB.Core
{
    /// <summary>
    /// This is the entry-point into the quebb. All services are exposed here.
    /// </summary>
    public class Quebb
    {
        private readonly IRepository _repository;

        public Quebb(IRepository repository)
        {
            _repository = repository;
        }

        public AddPostResponse AddPost(AddPostRequest request)
        {
            return new AddPostHandler(_repository).Handle(request);
        }

        public GetAllPostsResponse GetAllPosts(GetAllPostsRequest request)
        {
            return new GetAllPostsHandler(_repository).Handle(request);
        }
    }
}
