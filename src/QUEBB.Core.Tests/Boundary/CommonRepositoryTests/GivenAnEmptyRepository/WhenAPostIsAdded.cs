using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.Boundary;
using QUEBB.Core.Entities;

namespace QUEBB.Core.Tests.Boundary.CommonRepositoryTests.GivenAnEmptyRepository
{
    [TestClass]
    public abstract class WhenAPostIsAdded
    {
        private IRepository _repository;
        private string _createdId;
        private Post _addedPost;
        private const string CreatedTitle = "The Title";

        protected abstract IRepository CreateRepository();

        [TestInitialize]
        public void Setup()
        {
            _repository = CreateRepository();
            _addedPost = new Post {Id = null, Title = CreatedTitle};
            _createdId = _repository.StorePost(_addedPost);
        }

        [TestMethod]
        public void ThenCreatedIdIsNotNull()
        {
            Assert.IsNotNull(_createdId);
        }

        [TestMethod]
        public void ThenGetPostWithCreatedIdReturnsThatPost()
        {
            var retrievedPost = _repository.GetPost(_createdId);
            Assert.IsNotNull(retrievedPost);
        }

        [TestMethod]
        public void ThenGetPostReturnsSavedTitle()
        {
            var retrievedPost = _repository.GetPost(_createdId);
            Assert.AreEqual(CreatedTitle, retrievedPost.Title);
        }

        [TestMethod]
        public void ThenGetPostReturnsWithCorrectId()
        {
            var retrievedPost = _repository.GetPost(_createdId);
            Assert.AreEqual(_createdId, retrievedPost.Id);
        }

        [TestMethod]
        public void ThenGetPostReturnsAPostThatIsReferenciallyDifferent()
        {
            var retrievedPost = _repository.GetPost(_createdId);
            Assert.AreNotSame(_addedPost, retrievedPost);
        }

        [TestMethod]
        public void ThenGetPostReturnsOneResult()
        {
            var retrievedPosts = _repository.GetAllPosts();
            Assert.AreEqual(1, retrievedPosts.Count());
        }
    }
}