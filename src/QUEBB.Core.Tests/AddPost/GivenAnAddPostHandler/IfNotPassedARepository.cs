using System;
using Xunit;

namespace QUEBB.Core.Tests.AddPost.GivenAnAddPostHandler
{
    public class IfNotPassedARepository
    {
        [Fact]
        public void ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(()=>AddPostHandlerTests.CreateHandler(null));
        }
    }
}