using System.Linq;
using QUEBB.Core.Boundary;
using QUEBB.Core.Entities;
using Xunit;

namespace QUEBB.Core.Tests.Boundary.CommonRepositoryTests.GivenAnEmptyRepository
{
    public abstract class WhenAPostIsAdded
    {
        private readonly IRepository _repository;
        private readonly string _createdId;
        private readonly Post _addedPost;
        private const string CreatedTitle = "The Title";

        protected abstract IRepository CreateRepository();

        public WhenAPostIsAdded()
        {
            _repository = CreateRepository();
            _addedPost = new Post {Id = null, Title = CreatedTitle};
            _createdId = _repository.StorePost(_addedPost);
        }

        [Fact]
        public void ThenCreatedIdIsNotNull()
        {
            Assert.NotNull(_createdId);
        }

        [Fact]
        public void ThenGetPostWithCreatedIdReturnsThatPost()
        {
            var retrievedPost = _repository.GetPost(_createdId);
            Assert.NotNull(retrievedPost);
        }

        [Fact]
        public void ThenGetPostReturnsSavedTitle()
        {
            var retrievedPost = _repository.GetPost(_createdId);
            Assert.Equal(CreatedTitle, retrievedPost.Title);
        }

        [Fact]
        public void ThenGetPostReturnsWithCorrectId()
        {
            var retrievedPost = _repository.GetPost(_createdId);
            Assert.Equal(_createdId, retrievedPost.Id);
        }

        [Fact]
        public void ThenGetPostReturnsAPostThatIsReferenciallyDifferent()
        {
            var retrievedPost = _repository.GetPost(_createdId);
            Assert.NotSame(_addedPost, retrievedPost);
        }

        [Fact]
        public void ThenGetPostReturnsOneResult()
        {
            var retrievedPosts = _repository.GetAllPosts();
            Assert.Equal(1, retrievedPosts.Count());
        }
    }
}