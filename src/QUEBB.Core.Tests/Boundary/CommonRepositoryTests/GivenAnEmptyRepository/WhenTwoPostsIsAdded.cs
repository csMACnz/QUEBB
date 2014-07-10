using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.Boundary;
using QUEBB.Core.Entities;

namespace QUEBB.Core.Tests.Boundary.CommonRepositoryTests.GivenAnEmptyRepository
{
    [TestClass]
    public abstract class WhenTwoPostsIsAdded
    {
        private IRepository _repository;
        private string _firstCreatedId;
        private const string CreatedTitle1 = "First Title";
        private const string CreatedTitle2 = "second Title";
        private string _secondCreatedId;

        protected abstract IRepository CreateRepository();

        [TestInitialize]
        public void Setup()
        {
            _repository = CreateRepository();
            _firstCreatedId = _repository.StorePost(new Post {Id = null, Title = CreatedTitle1});
            _secondCreatedId = _repository.StorePost(new Post {Id = null, Title = CreatedTitle2});
        }

        [TestMethod]
        public void ThenGetPostWithFirstCreatedIdReturnsFirstPost()
        {
            var retrievedPost = _repository.GetPost(_firstCreatedId);
            Assert.IsNotNull(retrievedPost);
            Assert.AreEqual(CreatedTitle1, retrievedPost.Title);
        }

        [TestMethod]
        public void ThenGetPostWithSecondCreatedIdReturnsSecondPost()
        {
            var retrievedPost = _repository.GetPost(_secondCreatedId);
            Assert.IsNotNull(retrievedPost);
            Assert.AreEqual(CreatedTitle2, retrievedPost.Title);
        }

        [TestMethod]
        public void ThenGetPostReturnsTwoResults()
        {
            var retrievedPosts = _repository.GetAllPosts();
            Assert.AreEqual(2, retrievedPosts.Count());
        }
    }
}