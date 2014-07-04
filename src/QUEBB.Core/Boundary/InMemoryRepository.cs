using System;
using System.Collections.Generic;
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

        public string StorePost(Post post)
        {
            var id = Guid.NewGuid().ToString();
            _data.Add(id, new Post{Id=id, Title=post.Title});
            return id;
        }
    }
}