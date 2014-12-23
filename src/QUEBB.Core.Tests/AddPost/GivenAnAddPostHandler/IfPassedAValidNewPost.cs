using Moq;
using QUEBB.Core.AddPost;
using QUEBB.Core.Boundary;
using QUEBB.Core.Entities;
using Xunit;

namespace QUEBB.Core.Tests.AddPost.GivenAnAddPostHandler
{
    public class IfPassedAValidNewPost
    {
        private readonly AddPostResponse _response;
        private readonly Mock<IRepository> _mockPersistance;
        private const string NewId = "myNewId";
        private Post _storedPost;

        public IfPassedAValidNewPost()
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

            AddPostHandler handler = AddPostHandlerTests.CreateHandler(_mockPersistance.Object);
            Post newPost = AddPostHandlerTests.CreateValidPostForAdding();
            _response = handler.Handle(new AddPostRequest(newPost));
        }

        [Fact]
        public void ThenAPostIsPassedToRepository()
        {
            _mockPersistance.Verify(m => m.StorePost(It.IsAny<Post>()));
        }

        [Fact]
        public void ThenTheCreatePostIsRetrievedFromRepository()
        {
            _mockPersistance.Verify(m => m.GetPost(It.IsAny<string>()));
        }

        [Fact]
        public void ThenReturnsSuccessfully()
        {
            Assert.NotNull(_response);
        }

        [Fact]
        public void ThenReturnsANewId()
        {
            Assert.NotNull(_response.Post.Id);
        }

        [Fact]
        public void ThenReturnsTheGeneratedId()
        {
            Assert.Equal(NewId, _response.Post.Id);
        }
    }
}