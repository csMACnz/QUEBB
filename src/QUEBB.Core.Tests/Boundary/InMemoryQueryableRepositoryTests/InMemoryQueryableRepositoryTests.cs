using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.Boundary;

namespace QUEBB.Core.Tests.Boundary.InMemoryQueryableRepositoryTests
{
    [TestClass]
    public class InMemoryQueryableRepositoryTests
    {
        public static InMemoryQueryableRepository CreateRepository()
        {
            return new InMemoryQueryableRepository();
        }

        [TestMethod]
        public void CanCreateInMemoryQueryableRepository()
        {
            var repository = CreateRepository();
            Assert.IsNotNull(repository);
        }
    }
}
