using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.Boundary;

namespace QUEBB.Core.Tests.Boundary.InMemoryRepositoryTests
{
    [TestClass]
    public class InMemoryRepositoryTests
    {
        public static InMemoryRepository CreateRepository()
        {
            return new InMemoryRepository();
        }

        [TestMethod]
        public void CanCreateInMemoryRepository()
        {
            var repository = CreateRepository();
            Assert.IsNotNull(repository);
        }
    }
}
