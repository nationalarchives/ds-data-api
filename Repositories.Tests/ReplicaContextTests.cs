using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Repositories.Replica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TNA.DataDefinitionObjects;
using TNA.RepositoryLibraries.MongoDB;

namespace Repositories.Tests
{
    [TestClass]
    public class ReplicaContextTests
    {
        private IRepository<Repl> _replicaRepo;

        private Repl _testReplica = new Repl { RID = "1", Orig = Origination.BornDigital };

        [TestInitialize]
        public void Init()
        {
            _replicaRepo = Substitute.For<IRepository<Repl>>();
        }

        [TestMethod]
        public void GetReplica_WithOutAnyParameter_ReturnsReplicaList()
        {
            //Arrange
            var replicaContext = new ReplicaContext(_replicaRepo);
            _replicaRepo.FindAll(Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(new List<Repl>());
            //Act
            var result = replicaContext.Get();
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void UpsertReplica_WithValidReplica_ReturnsTrue()
        {
            //Arrange
            _replicaRepo.ReplaceAsync(r => r.RID == Arg.Compat.Any<string>(), _testReplica, Arg.Any<UpdateOptions>()).ReturnsForAnyArgs(true);
            //Act
            var replicaContext = new ReplicaContext(_replicaRepo);
            var result = replicaContext.UpsertAsync(_testReplica);
            //Assert
            Assert.IsTrue(result.Result);
        }

        [TestMethod]
        public async Task UpsertReplica_WithNull_RaiseError()
        {
            //Arrange
            _replicaRepo.ReplaceAsync(Arg.Any<Expression<Func<Repl, bool>>>(),
                Arg.Is<Repl>(r => r == null),
                Arg.Any<UpdateOptions>()).Throws(new ArgumentNullException());

            //Act
            var replicaContext = new ReplicaContext(_replicaRepo);
            //Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => replicaContext.UpsertAsync(null));
        }

        [TestMethod]
        public void GetReplica_WithValidIaid_ReturnsReplica()
        {
            //Arrange
            _replicaRepo.FilterDefinition.Returns(new FilterDefinitionBuilder<Repl>());
            _replicaRepo.FirstAsync(Arg.Any<FilterDefinition<Repl>>(), Arg.Any<FindOptions<Repl>>()).ReturnsForAnyArgs(_testReplica);
            //Act
            var replicaContext = new ReplicaContext(_replicaRepo);
            var result = replicaContext.GetAsync("1");
            //Assert
            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public void DeleteReplica_WithValidIaid_ReturnsTrue()
        {
            //Arrange
            _replicaRepo.DeleteAsync(r => r.RID == Arg.Compat.Any<string>()).ReturnsForAnyArgs(true);
            //Act
            var replicaContext = new ReplicaContext(_replicaRepo);
            var result = replicaContext.DeleteAsync("1");
            //Assert
            Assert.IsTrue(result.Result);
        }
    }
}