using System.Data.SqlClient;
using Jouribe.Tools.MassInserts.Framework.SQL;
using Jouribe.Tools.MassInserts.Library.Models;
using Xunit;

namespace Jouribe.Tools.MassInserts.Framework.Tests
{
    public class ConnectionTests
    {
        [Fact]
        public void Initialization()
        {
            ConnectionProperty properties = new ConnectionProperty
            {
                Database = "Database"
            };
            
            SQLHelperDB.HelperClasses.Connection connection = new Connection(properties).Open();
            
            Assert.Equal(30, connection.CommandTimeout);
            Assert.Equal(@"Data Source=localhost; Initial Catalog=Database; Integrated Security=true;", connection.ConnectionString);
            Assert.Equal("Database", connection.DatabaseName);
            Assert.Same(SqlClientFactory.Instance, connection.Factory);
            Assert.Equal("@", connection.ParameterPrefix);
            Assert.Equal(0, connection.Retries);
        }
    }
}