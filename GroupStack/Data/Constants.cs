using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupStack.Data
{
    public static class Constants
    {
        public const string CoordinatorRole = "Coordinator";
        public const string MentorRole = "Mentor";
        public const string StudentRole = "Student";
        public const string AdministratorRole = "Administrator";

        public static string[] roles = new string[] {AdministratorRole, CoordinatorRole, MentorRole, StudentRole};
    }
}
