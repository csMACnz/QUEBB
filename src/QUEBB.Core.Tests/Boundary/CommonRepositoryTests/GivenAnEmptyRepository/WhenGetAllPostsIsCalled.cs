using System.Collections.Generic;
using System.Linq;
using QUEBB.Core.Boundary;
using QUEBB.Core.Entities;
using Xunit;

namespace QUEBB.Core.Tests.Boundary.CommonRepositoryTests.GivenAnEmptyRepository
{
    public abstract class WhenGetAllPostsIsCalled
    {
        private readonly IEnumerable<Post> _result;

        protected abstract IRepository CreateRepository();

        public WhenGetAllPostsIsCalled()
        {
            var repository = CreateRepository();
            _result = repository.GetAllPosts();
        }

        [Fact]
        public void ThenResultIsNotNull()
        {
            Assert.NotNull(_result);
        }

        [Fact]
        public void ThenResultEvaluatesToEmpty()
        {
            Assert.Equal(0, _result.Count());
        }
    }
}