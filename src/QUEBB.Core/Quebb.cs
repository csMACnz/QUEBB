using QUEBB.Core.AddPost;

namespace QUEBB.Core
{
    /// <summary>
    /// This is the entry-point into the quebb. All services are exposed here.
    /// </summary>
    public class Quebb
    {
        public AddPostResponse AddPost(AddPostRequest request)
        {
            return new AddPostHandler().Handle(request);
        }
    }
}
