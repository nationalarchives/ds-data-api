using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using NSubstitute;
using Repositories.PreparedFile;
using System.Threading.Tasks;
using TNA.DataDefinitionObjects;
using TNA.RepositoryLibraries.MongoDB;

namespace Repositories.Tests
{
    [TestClass]
    public class PreparedFileContextTests
    {
        private IRepository<PrepFile> _prepFileRepo = null;
        private static string iaid = "01XX";
        private PrepFile testPrepFile = new PrepFile() { IAID = iaid, PercentCompleted = 100 };

        [TestInitialize]
        public void Init()
        {
            _prepFileRepo = Substitute.For<IRepository<PrepFile>>();
        }

        [TestMethod]
        public async Task DeletePreparedFile_WithValidIaid_ReturnsTrue()
        {
            //Arrange
            _prepFileRepo.DeleteAsync(r => r.IAID == iaid).ReturnsForAnyArgs(true);
            //Act
            var preparedFileContext = new PreparedFileContext(_prepFileRepo);
            var result = await preparedFileContext.DeleteAsync(iaid);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task GetPreparedFile_WithValidIaid_ReturnsPreparedFileWithTheSameIaid()
        {
            //Arrange
            _prepFileRepo.FilterDefinition.Returns(new FilterDefinitionBuilder<PrepFile>());
            _prepFileRepo.FirstAsync(Arg.Any<FilterDefinition<PrepFile>>(), Arg.Any<FindOptions<PrepFile>>()).ReturnsForAnyArgs(testPrepFile);
            var preparedFileContext = new PreparedFileContext(_prepFileRepo);
            //Act
            var result = await preparedFileContext.GetAsync(iaid);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(iaid, result.IAID);
        }

        [TestMethod]
        public async Task UpsertPreparedFile_WithPreparedFile_ReturnsTrue()
        {
            //Arrange
            _prepFileRepo.ReplaceAsync(r => r.IAID == Arg.Compat.Any<string>(), testPrepFile, Arg.Any<UpdateOptions>()).ReturnsForAnyArgs(true);
            //Act
            var preparedFileContext = new PreparedFileContext(_prepFileRepo);
            var result = await preparedFileContext.UpsertAsync(testPrepFile);
            //Assert
            Assert.IsTrue(result);
        }
    }
}
