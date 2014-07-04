using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.Boundary;
using QUEBB.Core.Entities;

namespace QUEBB.Core.Tests.Boundary
{
    [TestClass]
    public class InMemoryRepositoryTests
    {
        [TestMethod]
        public void CanCreateInMemoryRepository()
        {
            var repository = new InMemoryRepository();
            Assert.IsNotNull(repository);
        }

        public class GivenAnEmptyRepository
        {
            [TestClass]
            public class WhenAPostIsAdded
            {
                private InMemoryRepository _repository;
                private string _createdId;
                private const string CreatedTitle = "The Title";

                [TestInitialize]
                public void Setup()
                {
                    _repository = new InMemoryRepository();
                    _createdId = _repository.StorePost(new Post { Id = null, Title = CreatedTitle });
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
            }

            [TestClass]
            public class WhenTwoPostsIsAdded
            {
                private InMemoryRepository _repository;
                private string _firstCreatedId;
                private const string CreatedTitle1 = "First Title";
                private const string CreatedTitle2 = "second Title";
                private string _secondCreatedId;

                [TestInitialize]
                public void Setup()
                {
                    _repository = new InMemoryRepository();
                    _firstCreatedId = _repository.StorePost(new Post {Id = null, Title = CreatedTitle1});
                    _secondCreatedId = _repository.StorePost(new Post { Id = null, Title = CreatedTitle2 });
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
            }
        }
    }
}
