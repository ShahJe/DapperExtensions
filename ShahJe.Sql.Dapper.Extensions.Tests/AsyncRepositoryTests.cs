using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShahJe.Sql.Dapper.Extensions.Tests.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShahJe.Sql.Dapper.Extensions.Tests
{
    [TestClass]
    public class AsyncRepositoryTests : TestBase
    {
        private IAsyncRepository Repository { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestBase.ClassSetup(context);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Repository = new AsyncRepository(string.Format(ConnectionString, Path));
        }

        [TestMethod]
        public async Task GetOneAsync()
        {
            var result = await Repository.GetOneAsync<RandomStuff>("SELECT * FROM dbo.RandomStuff", System.Data.CommandType.Text);
            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result.Name));
        }

        [TestMethod]
        public async Task GetManyAsync()
        {
            var result = await Repository.GetManyAsync<RandomStuff>("SELECT * FROM dbo.RandomStuff", System.Data.CommandType.Text);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task GetScalarIntAsync()
        {
            var result = await Repository.GetScalarAsync("SELECT COUNT(*) FROM dbo.RandomStuff", System.Data.CommandType.Text);
            Assert.IsNotNull(result);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public async Task GetScalarDateTimeAsync()
        {
            var result = await Repository.GetScalarDateAsync("SELECT MAX(CreatedAt) FROM dbo.RandomStuff", System.Data.CommandType.Text);
            Assert.IsNotNull(result);
            Assert.IsTrue(result > default(DateTime));
        }

        [TestMethod]
        public async Task GetScalarBoolAsync()
        {
            var result = await Repository.GetScalarBoolAsync("SELECT COUNT(*) FROM dbo.RandomStuff", System.Data.CommandType.Text);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }
    }
}