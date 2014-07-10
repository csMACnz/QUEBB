using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.Boundary;

namespace QUEBB.Core.Tests.Boundary.InMemoryQueryableRepositoryTests.GivenAnEmptyRepository
{
    [TestClass]
    public class WhenTwoPostsIsAdded :
        CommonRepositoryTests.GivenAnEmptyRepository.WhenTwoPostsIsAdded
    {
        protected override IRepository CreateRepository()
        {
            return InMemoryQueryableRepositoryTests.CreateRepository();
        }
    }
}