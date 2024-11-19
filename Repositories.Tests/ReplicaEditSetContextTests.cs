using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using NSubstitute;
using Repositories.ReplicaEditSet;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNA.DataDefinitionObjects;
using TNA.RepositoryLibraries.MongoDB;

namespace Repositories.Tests
{
    [TestClass]
    public class ReplicaEditSetContextTests
    {
        private IRepository<ReplEditSet> _repEditSetRepo = null;

        [TestInitialize]
        public void Init()
        {
            _repEditSetRepo = Substitute.For<IRepository<ReplEditSet>>();
        }

        [TestMethod]
        public async Task GetReplicaEditSet_WithValidIaid_ReturnsReplicaEditSet()
        {
            //Arrange
            _repEditSetRepo.FirstAsync(Arg.Any<FilterDefinition<ReplEditSet>>(), null).Returns(Task.FromResult(new ReplEditSet()));
            //Act
            var resContext = new ReplicaEditSetContext(_repEditSetRepo);
            var result = await resContext.GetAsync("1");
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetReplicaEditSets_WithValidPageSizeAndPageNumber_ReturnReplicaEditSets()
        {
            //Arrange
            _repEditSetRepo.FindOptions.Returns(new FindOptions<ReplEditSet>());
            _repEditSetRepo.FindAsync(Arg.Any<FilterDefinition<ReplEditSet>>(), Arg.Any<FindOptions<ReplEditSet>>()).Returns(new List<ReplEditSet>());
            //Act
            var resContext = new ReplicaEditSetContext(_repEditSetRepo);
            var result = await resContext.GetAsync(1, 2);
            //Assert
            Assert.IsTrue(result.Count() == 0);
        }

        [TestMethod]
        public async Task DeleteReplicaEditSet_WithValidIaid_ReturnsTrue()
        {
            //Arrange
            _repEditSetRepo.DeleteAsync(x => x.Sub == null && x.IAID == Arg.Compat.Any<string>()).ReturnsForAnyArgs(true);
            //Act
            var resContext = new ReplicaEditSetContext(_repEditSetRepo);
            var result = await resContext.DeleteAsync("1");
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task UpsertReplicaEditSet_WithValidReplicaEditSet_ReturnsTrue()
        {
            //Arrange
            var testReplicaEditSet = new ReplEditSet { IAID = "1", RID = "2", Usr = "testUser" };
            _repEditSetRepo.ReplaceAsync(r => r.IAID == Arg.Compat.Any<string>(), testReplicaEditSet, Arg.Any<UpdateOptions>()).ReturnsForAnyArgs(true);
            //Act
            var resContext = new ReplicaEditSetContext(_repEditSetRepo);
            var result = await resContext.UpsertAsync(testReplicaEditSet);
            //Assert
            Assert.IsTrue(result);
        }
    }
}