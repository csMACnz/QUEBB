using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.Boundary;
using QUEBB.Core.Entities;

namespace QUEBB.Core.Tests.Boundary.CommonRepositoryTests.GivenAnEmptyRepository
{
    [TestClass]
    public abstract class WhenGetAllPostsIsCalled
    {
        private IEnumerable<Post> _result;

        protected abstract IRepository CreateRepository();

        [TestInitialize]
        public void Setup()
        {
            var repository = CreateRepository();
            _result = repository.GetAllPosts();
        }

        [TestMethod]
        public void ThenResultIsNotNull()
        {
            Assert.IsNotNull(_result);
        }

        [TestMethod]
        public void ThenResultEvaluatesToEmpty()
        {
            Assert.AreEqual(0, _result.Count());
        }
    }
}