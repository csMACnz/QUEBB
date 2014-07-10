using System;
using System.Collections.Generic;
using System.Linq;
using QUEBB.Core.Entities;

namespace QUEBB.Core.Boundary
{
    public class InMemoryRepository : IRepository
    {
        private readonly Dictionary<string, Post> _data = new Dictionary<string, Post>();

        public Post GetPost(string id)
        {
            return _data[id];
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return new List<Post>(_data.Values);
        }

        public string StorePost(Post post)
        {
            var id = Guid.NewGuid().ToString();
            _data[id] = new Post { Id = id, Title = post.Title };
            return id;
        }
    }

    public class InMemoryQueryableRepository : QueryableRepository
    {
        private readonly Dictionary<string, Post> _data = new Dictionary<string, Post>();

        public override string StorePost(Post post)
        {
            var id = Guid.NewGuid().ToString();
            _data[id] = new Post { Id = id, Title = post.Title };
            return id;
        }

        protected override IQueryable<Post> Query()
        {
            return _data.Values.AsQueryable();
        }
    }
}