using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerApp
{
    internal class Constants
    {
        public static string connectionString = "Data Source=dc1;Initial Catalog=TestServer;Persist Security Info=True;User ID=Victor;Password=256120Vik";
        public static string userFirstName, userLastName, userEmail, userCompany, userPassword;
        public static DateTime userAccountCreated;
        public static bool userAdmin;
    }
}
