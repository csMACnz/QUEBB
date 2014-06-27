using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.AddPost;

namespace QUEBB.Core.Tests.AddPost
{
    [TestClass]
    public class AddPostResponseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfPassedANullPostThrowsArgumentNullException()
        {
            new AddPostResponse(null);
        }
    }
}