using QUEBB.Core.Boundary;
using Xunit;

namespace QUEBB.Core.Tests.Boundary.InMemoryRepositoryTests
{
    public class InMemoryRepositoryTests
    {
        public static InMemoryRepository CreateRepository()
        {
            return new InMemoryRepository();
        }

        [Fact]
        public void CanCreateInMemoryRepository()
        {
            var repository = CreateRepository();
            Assert.NotNull(repository);
        }
    }
}
