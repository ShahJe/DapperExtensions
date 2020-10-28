using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ShahJe.Sql.Dapper.Extensions.Tests
{
    public abstract class TestBase
    {
        protected const string ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=UnitTest;Integrated Security=SSPI;AttachDBFilename={0}\UnitTest.mdf";

        protected string Path => AppDomain.CurrentDomain.GetData("DataDirectory") as string;

        public static void ClassSetup(TestContext context)
        {
            AppDomain.CurrentDomain.SetData(
            "DataDirectory",
            context.TestDeploymentDir);
        }        
    }
}