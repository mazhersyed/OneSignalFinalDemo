using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MyOneSignalDemo.Helpers
{
    public static class WebHelpers
    {
        public static readonly string contentType = "application/json";

        public static readonly string adminEmail = "admin@mysite.com";

        public static readonly string adminPassword = "A@12345678";

        public static readonly string userEmail = "user@mysite.com";

        public static readonly string userPassword = "U@12345678";

        public const string adminRole = "Admin";
        public const string userRole = "DataEntry";



        public static string ReadConfig(string keyName)
        {
            return ConfigurationManager.AppSettings[keyName] != null ? ConfigurationManager.AppSettings[keyName].ToString() : string.Empty;
        }
    }


}