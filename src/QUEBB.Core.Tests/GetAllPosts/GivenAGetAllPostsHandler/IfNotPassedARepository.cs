using System;
using Xunit;

namespace QUEBB.Core.Tests.GetAllPosts.GivenAGetAllPostsHandler
{
    public class IfNotPassedARepository
    {
        [Fact]
        public void ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GetAllPostsHandlerTests.CreateHandler(null));
        }
    }
}