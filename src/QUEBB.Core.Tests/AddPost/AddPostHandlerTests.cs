using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QUEBB.Core.AddPost;
using QUEBB.Core.Boundary;
using QUEBB.Core.Entities;

namespace QUEBB.Core.Tests.AddPost
{
    [TestClass]
    public class AddPostHandlerTests
    {
        [TestMethod]
        public void CanCreateAddPostHandler()
        {
            var handler = CreateHandler();
            Assert.IsNotNull(handler);
        }

        private static AddPostHandler CreateHandler()
        {
            return new AddPostHandler(new InMemoryRepository());
        }

        private static AddPostHandler CreateHandler(IRepository repository)
        {
            return new AddPostHandler(repository);
        }

        public class GivenAnAddPostHandler
        {
            [TestClass]
            public class IfNotPassedARepository
            {
                [TestMethod]
                [ExpectedException(typeof(ArgumentNullException))]
                public void ThrowsArgumentNullException()
                {
                    CreateHandler(null);
                }
            }

            [TestClass]
            public class IfPassedAnEmptyRequest
            {
                private AddPostHandler _handler;

                [TestInitialize]
                public void Setup()
                {
                    _handler = CreateHandler();
                }

                [TestMethod]
                [ExpectedException(typeof(ArgumentNullException))]
                public void ThrowsArgumentNullException()
                {
                    _handler.Handle(null);
                }
            }

            [TestClass]
            public class IfPassedANewPost
            {
                private AddPostResponse _response;
                private AddPostHandler _handler;
                private Post _newPost;
                private Mock<IRepository> _mockPersistance;
                private const string NewId = "myNewId";

                [TestInitialize]
                public void Setup()
                {
                    _mockPersistance = new Mock<IRepository>();
                    _mockPersistance
                        .Setup(m => m.StorePost(It.IsAny<Post>()))
                        .Returns(NewId);
                    _mockPersistance
                        .Setup(m => m.GetPost(It.IsAny<string>()))
                        .Returns(new Post {Id = NewId});
                    _handler = CreateHandler(_mockPersistance.Object);
                    _newPost = new Post();
                    _response = _handler.Handle(new AddPostRequest(_newPost));
                }

                [TestMethod]
                public void ThenAPostIsPassedToRepository()
                {
                    _mockPersistance.Verify(m=>m.StorePost(It.IsAny<Post>()));
                }

                [TestMethod]
                public void ThenTheCreatePostIsRetrievedFromRepository()
                {
                    _mockPersistance.Verify(m => m.GetPost(It.IsAny<string>()));
                }

                [TestMethod]
                public void ThenReturnsSuccessfully()
                {
                    Assert.IsNotNull(_response);
                }

                [TestMethod]
                public void ThenReturnsANewId()
                {
                    Assert.IsTrue(_response.Post.Id != null);
                }
            }

            [TestClass]
            public class IfPassedANewPostWithATitle
            {
                private const string Title = "My Post Title";

                private AddPostResponse _response;
                private AddPostHandler _handler;
                private Post _newPost;

                [TestInitialize]
                public void Setup()
                {
                    _handler = CreateHandler();
                    _newPost = new Post {Title = Title};
                    _response = _handler.Handle(new AddPostRequest(_newPost));
                }

                [TestMethod]
                public void ThenReturnsAPostThatHasTheSameTitle()
                {
                    Assert.AreEqual(_newPost.Title, _response.Post.Title);
                }
            }
        }
    }
}