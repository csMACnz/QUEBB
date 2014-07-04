using QUEBB.Core.Entities;

namespace QUEBB.Core.Boundary
{
    public interface IRepository
    {
        string StorePost(Post post);
        Post GetPost(string id);
    }
}