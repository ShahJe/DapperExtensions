using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShahJe.Sql.Dapper.Extensions.Tests.Models;
using System;
using System.Linq;

namespace ShahJe.Sql.Dapper.Extensions.Tests
{
    [TestClass]
    public class RepositoryTests : TestBase
    {
        private IRepository Repository { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestBase.ClassSetup(context);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Repository = new Repository(string.Format(ConnectionString, Path));
        }

        [TestMethod]
        public void GetOne()
        {
            var result = Repository.GetOne<RandomStuff>("SELECT * FROM dbo.RandomStuff", System.Data.CommandType.Text);
            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result.Name));
        }

        [TestMethod]
        public void GetMany()
        {
            var result = Repository.GetMany<RandomStuff>("SELECT * FROM dbo.RandomStuff", System.Data.CommandType.Text);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetScalarInt()
        {
            var result = Repository.GetScalar("SELECT COUNT(*) FROM dbo.RandomStuff", System.Data.CommandType.Text);
            Assert.IsNotNull(result);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void GetScalarDateTime()
        {
            var result = Repository.GetScalarDate("SELECT MAX(CreatedAt) FROM dbo.RandomStuff", System.Data.CommandType.Text);
            Assert.IsNotNull(result);
            Assert.IsTrue(result > default(DateTime));
        }

        [TestMethod]
        public void GetScalarBool()
        {
            var result = Repository.GetScalarBool("SELECT COUNT(*) FROM dbo.RandomStuff", System.Data.CommandType.Text);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }
    }
}