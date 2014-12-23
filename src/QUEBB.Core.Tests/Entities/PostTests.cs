using System;
using QUEBB.Core.Entities;
using Xunit;

namespace QUEBB.Core.Tests.Entities
{
    public class PostTests
    {
        [Fact]
        public void CloningANullPostThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Post.Clone(null));
        }

        public class WhenAPostIsCloned
        {
            private readonly Post _clonedPost;
            private const string ExpectedId = "ExpectedId";
            private const string ExpectedTitle = "The Expected Title";

            public WhenAPostIsCloned()
            {
                var newPost = new Post
                {
                    Title = ExpectedTitle,
                    Id = ExpectedId
                };
                _clonedPost =Post.Clone(newPost);
            }

            [Fact]
            public void ThenDoesNotReturnNull()
            {
                Assert.NotNull(_clonedPost);
            }

            [Fact]
            public void ThenTitleMatchesExpectedTitle()
            {
                Assert.Equal(ExpectedTitle, _clonedPost.Title);
            }

            [Fact]
            public void ThenIdMatchesExpectedId()
            {
                Assert.Equal(ExpectedId, _clonedPost.Id);
            }
        }
    }
}