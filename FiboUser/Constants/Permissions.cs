using System;
using System.Collections.Generic;
using System.Text;

namespace FiboUser.Constants
{
    public class Permissions
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Premissions.{module}.Create",
                $"Premissions.{module}.Delete",
                $"Premissions.{module}.Update",
                $"Premissions.{module}.View",
                $"Premissions.{module}.Index",
            };
        }
        public static class ApplicationPermission
        {
            //Account Register
            public const string AccountView = "Permissions.Account.View";
            public const string AccountRegister = "Permissions.Account.Register";
            public const string AccountIndex = "Permissions.Account.Index";
            public const string Delete = "Permissions.Products.Delete";

          }
    }
}
