using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QUEBB.Core.AddPost;
using QUEBB.Core.Boundary;
using QUEBB.Core.Entities;
using QUEBB.Core.Infrastructure;

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

        private static Post CreateValidPostForAdding()
        {
            return new Post
            {
                Id = null,
                Title="Valid Post Title"
            };
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
            public class IfPassedAValidNewPost
            {
                private AddPostResponse _response;
                private AddPostHandler _handler;
                private Post _newPost;
                private Mock<IRepository> _mockPersistance;
                private const string NewId = "myNewId";
                private Post _storedPost;
                [TestInitialize]
                public void Setup()
                {
                    _mockPersistance = new Mock<IRepository>();
                    _mockPersistance
                        .Setup(m => m.StorePost(It.IsAny<Post>()))
                        .Returns<Post>(p =>
                        {
                            var storedPost = Post.Clone(p);
                            storedPost.Id = NewId;
                            _storedPost = storedPost;
                            return _storedPost.Id;
                        });
                    _mockPersistance
                        .Setup(m => m.GetPost(NewId))
                        .Returns(() => _storedPost);
                    _handler = CreateHandler(_mockPersistance.Object);
                    _newPost = CreateValidPostForAdding();
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
                    Assert.IsNotNull(_response.Post.Id);
                }

                [TestMethod]
                public void ThenReturnsTheGeneratedId()
                {
                    Assert.AreEqual(NewId, _response.Post.Id);
                }
            }

            [TestClass]
            public class IfPassedANewPostWithAnId
            {
                private AddPostHandler _handler;
                private Post _newPost;

                [TestInitialize]
                public void Setup()
                {
                    _handler = CreateHandler();
                    _newPost = CreateValidPostForAdding();
                    _newPost.Id= "ShouldNotHaveOne";       
                }

                [TestMethod]
                [ExpectedException(typeof(ValidationException))]
                public void ThenReturnsAPostThatHasTheSameTitle()
                {
                    _handler.Handle(new AddPostRequest(_newPost));
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
                    _newPost = CreateValidPostForAdding();
                    _newPost.Title = Title;
                    _response = _handler.Handle(new AddPostRequest(_newPost));
                }

                [TestMethod]
                public void ThenReturnsAPostThatHasTheSameTitle()
                {
                    Assert.AreEqual(_newPost.Title, _response.Post.Title);
                }
            }

            [TestClass]
            public class IfPassedANewPostWithANullTitle
            {
                private AddPostHandler _handler;
                private Post _newPost;

                [TestInitialize]
                public void Setup()
                {
                    _handler = CreateHandler();
                    _newPost = CreateValidPostForAdding();
                    _newPost.Title = null;

                }

                [TestMethod]
                [ExpectedException(typeof(ValidationException))]
                public void ThenThrowsAValidationException()
                {
                    _handler.Handle(new AddPostRequest(_newPost));
                }
            }
        }
    }
}