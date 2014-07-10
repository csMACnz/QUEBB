using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.Boundary;

namespace QUEBB.Core.Tests.Boundary.InMemoryRepositoryTests.GivenAnEmptyRepository
{
    [TestClass]
    public class WhenGetAllPostsIsCalled :
        CommonRepositoryTests.GivenAnEmptyRepository.WhenGetAllPostsIsCalled
    {
        protected override IRepository CreateRepository()
        {
            return InMemoryRepositoryTests.CreateRepository();
        }
    }
}