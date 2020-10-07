using System.Data.SqlClient;
using Jouribe.Tools.MassInserts.Library.Make.Connection;
using Jouribe.Tools.MassInserts.Library.Models;
using Microsoft.Extensions.Configuration;

namespace Jouribe.Tools.MassInserts.Framework.SQL
{
    /// <summary>
    /// Create a connection class.
    /// </summary>
    public class Connection
    {
        #region Private Properties

        private readonly ConnectionProperty _properties;
        private readonly IConfigurationRoot _configuration;

        #endregion

        #region Constructor

        /// <summary>
        /// Connection constructor.
        /// </summary>
        /// <param name="properties"></param>
        public Connection(ConnectionProperty properties)
        {
            _configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            
            _properties = properties;
        }

        #endregion
        
        #region Private Methods

        /// <summary>
        /// Create a connection string given connection properties.
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        private static string GetConnectionString(ConnectionProperty properties)
        {
            return new SqlString(properties).Get();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Open a connection.
        /// </summary>
        /// <returns></returns>
        public SQLHelperDB.HelperClasses.Connection Open()
        {
            return new SQLHelperDB.HelperClasses.Connection(
                _configuration, SqlClientFactory.Instance, GetConnectionString(_properties));
        }

        #endregion
    }
}