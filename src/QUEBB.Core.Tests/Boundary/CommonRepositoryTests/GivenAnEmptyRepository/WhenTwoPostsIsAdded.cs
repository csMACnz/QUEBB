using System.Linq;
using QUEBB.Core.Boundary;
using QUEBB.Core.Entities;
using Xunit;

namespace QUEBB.Core.Tests.Boundary.CommonRepositoryTests.GivenAnEmptyRepository
{
    public abstract class WhenTwoPostsIsAdded
    {
        private IRepository _repository;
        private string _firstCreatedId;
        private const string CreatedTitle1 = "First Title";
        private const string CreatedTitle2 = "second Title";
        private string _secondCreatedId;

        protected abstract IRepository CreateRepository();

        public WhenTwoPostsIsAdded()
        {
            _repository = CreateRepository();
            _firstCreatedId = _repository.StorePost(new Post {Id = null, Title = CreatedTitle1});
            _secondCreatedId = _repository.StorePost(new Post {Id = null, Title = CreatedTitle2});
        }

        [Fact]
        public void ThenGetPostWithFirstCreatedIdReturnsFirstPost()
        {
            var retrievedPost = _repository.GetPost(_firstCreatedId);
            Assert.NotNull(retrievedPost);
            Assert.Equal(CreatedTitle1, retrievedPost.Title);
        }

        [Fact]
        public void ThenGetPostWithSecondCreatedIdReturnsSecondPost()
        {
            var retrievedPost = _repository.GetPost(_secondCreatedId);
            Assert.NotNull(retrievedPost);
            Assert.Equal(CreatedTitle2, retrievedPost.Title);
        }

        [Fact]
        public void ThenGetPostReturnsTwoResults()
        {
            var retrievedPosts = _repository.GetAllPosts();
            Assert.Equal(2, retrievedPosts.Count());
        }
    }
}