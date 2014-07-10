using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QUEBB.Core.AddPost;
using QUEBB.Core.Boundary;
using QUEBB.Core.Entities;

namespace QUEBB.Core.Tests.AddPost.GivenAnAddPostHandler
{
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
            _handler = AddPostHandlerTests.CreateHandler(_mockPersistance.Object);
            _newPost = AddPostHandlerTests.CreateValidPostForAdding();
            _response = _handler.Handle(new AddPostRequest(_newPost));
        }

        [TestMethod]
        public void ThenAPostIsPassedToRepository()
        {
            _mockPersistance.Verify(m => m.StorePost(It.IsAny<Post>()));
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
}