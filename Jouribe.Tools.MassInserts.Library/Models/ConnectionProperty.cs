using System;

namespace Jouribe.Tools.MassInserts.Library.Models
{
    public class ConnectionProperty
    {
        public string Server { get; set; } = "localhost";
        public string Instance { get; set; } = null;
        public string Database { get; set; }
        public string User { get; set; } = null;
        public string Password { get; set; } = null;
        public bool IntegratedSecurity { get; set; } = true;
    }
}