using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ShahJe.Sql.Dapper.Extensions.Tests
{
    public abstract class TestBase
    {
        protected const string ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=UnitTest;Integrated Security=SSPI;AttachDBFilename={0}UnitTest.mdf";

        private static readonly string _dbDirectory;

        protected string Path => _dbDirectory;

        static TestBase()
        {
            var source = AppContext.BaseDirectory;
            var tempDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "DapperExtensionsTests");
            Directory.CreateDirectory(tempDir);

            DetachDatabase();

            File.Copy(
                System.IO.Path.Combine(source, "UnitTest.mdf"),
                System.IO.Path.Combine(tempDir, "UnitTest.mdf"),
                overwrite: true);
            File.Copy(
                System.IO.Path.Combine(source, "UnitTest_log.ldf"),
                System.IO.Path.Combine(tempDir, "UnitTest_log.ldf"),
                overwrite: true);

            _dbDirectory = tempDir + System.IO.Path.DirectorySeparatorChar;
        }

        public static void ClassSetup(TestContext context)
        {
        }

        private static void DetachDatabase()
        {
            try
            {
                using var conn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Integrated Security=SSPI");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    IF EXISTS (SELECT name FROM sys.databases WHERE name = 'UnitTest')
                    BEGIN
                        ALTER DATABASE [UnitTest] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                        EXEC sp_detach_db 'UnitTest', 'true';
                    END";
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
        }
    }
}
