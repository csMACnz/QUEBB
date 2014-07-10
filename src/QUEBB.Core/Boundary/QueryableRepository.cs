using System.Collections.Generic;
using System.Linq;
using QUEBB.Core.Entities;

namespace QUEBB.Core.Boundary
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class QueryableRepository: IRepository
    {
        public abstract string StorePost(Post post);

        public Post GetPost(string id)
        {
            return Query().SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return Query();
        }

        protected abstract IQueryable<Post> Query();
    }
}
