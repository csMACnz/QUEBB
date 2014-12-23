using System;
using QUEBB.Core.AddPost;
using Xunit;

namespace QUEBB.Core.Tests.AddPost
{
    public class AddPostRequestTests
    {
        [Fact]
        public void IfPassedAnNullNewPostThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new AddPostRequest(null));
        }
    }
}
