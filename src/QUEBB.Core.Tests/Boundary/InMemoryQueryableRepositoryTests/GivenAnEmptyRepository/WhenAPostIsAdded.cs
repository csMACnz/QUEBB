using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.Boundary;

namespace QUEBB.Core.Tests.Boundary.InMemoryQueryableRepositoryTests.GivenAnEmptyRepository
{
    [TestClass]
    public class WhenAPostIsAdded :
        CommonRepositoryTests.GivenAnEmptyRepository.WhenAPostIsAdded
    {
        protected override IRepository CreateRepository()
        {
            return InMemoryQueryableRepositoryTests.CreateRepository();
        }
    }
}