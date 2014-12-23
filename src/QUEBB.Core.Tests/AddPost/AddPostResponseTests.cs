using System;
using QUEBB.Core.AddPost;
using Xunit;

namespace QUEBB.Core.Tests.AddPost
{
    public class AddPostResponseTests
    {
        [Fact]
        public void IfPassedANullPostThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new AddPostResponse(null));
        }
    }
}