using QUEBB.Core.AddPost;
using QUEBB.Core.Boundary;

namespace QUEBB.Core
{
    /// <summary>
    /// This is the entry-point into the quebb. All services are exposed here.
    /// </summary>
    public class Quebb
    {
        private IRepository _repository;

        public Quebb(IRepository repository)
        {
            _repository = repository;
        }

        public AddPostResponse AddPost(AddPostRequest request)
        {
            return new AddPostHandler().Handle(_repository, request);
        }
    }
}
