using Jouribe.Tools.MassInserts.Library.Models;

namespace Jouribe.Tools.MassInserts.Library.Make.Connection
{
    /// <summary>
    /// Make SQL connection string class.
    /// </summary>
    public class SqlString
    {
        /// <summary>
        /// Connection Property.
        /// </summary>
        private readonly ConnectionProperty _property;

        /// <summary>
        /// Make SQL connection string constructor.
        /// </summary>
        /// <param name="property"></param>
        public SqlString(ConnectionProperty property)
        {
            _property = property;
        }

        /// <summary>
        /// Get the SQL Server connection string
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            return $"{DataSource()}{Instance()}; {InitialCatalog()}; {IntegratedSecurity()};";
        }

        /// <summary>
        /// Get string to SQL Server instance
        /// </summary>
        /// <returns></returns>
        private string Instance()
        {
            return !string.IsNullOrEmpty(_property.Instance)
                ? $@"\{_property.Instance}"
                : null;
        }

        /// <summary>
        /// Get string to SQL Server data source.
        /// </summary>
        /// <returns></returns>
        private string DataSource()
        {
            return $"Data Source={_property.Server}";
        }

        /// <summary>
        /// Get string to SQL Server initial catalog.
        /// </summary>
        /// <returns></returns>
        private string InitialCatalog()
        {
            return $"Initial Catalog={_property.Database}";
        }

        /// <summary>
        /// Get string to SQL Server integrated security or user and password connection.
        /// </summary>
        /// <returns></returns>
        private string IntegratedSecurity()
        {
            return _property.IntegratedSecurity
                ? "Integrated Security=true"
                : $"User ID={_property.User}; Password={_property.Password}";
        }
    }
}