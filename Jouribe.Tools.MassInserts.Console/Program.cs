using System;
using Jouribe.Tools.MassInserts.Framework.SQL;
using Jouribe.Tools.MassInserts.Library.Models;

namespace Jouribe.Tools.MassInserts.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Console.WriteLine("=================================================");
            System.Console.WriteLine("\tSQL Server Connection Application");
            System.Console.WriteLine("=================================================");
            System.Console.Write("Server: ");
            string server = System.Console.ReadLine();
            
            System.Console.Write("Database: ");
            string database = System.Console.ReadLine();
            
            System.Console.Write("Security Integrated: ");
            bool security = Convert.ToBoolean(System.Console.ReadLine());
            
            System.Console.Write("User: ");
            string user = System.Console.ReadLine();
            
            System.Console.Write("Password: ");
            string password = System.Console.ReadLine();
            
            ConnectionProperty properties = new ConnectionProperty
            {
                Server = server,
                Database = database,
                IntegratedSecurity = security,
                User = user,
                Password = password
            };

            SQLHelperDB.HelperClasses.Connection conenction = new Connection(properties).Open();
        }
    }
}
