using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupStack.Models
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }

        public bool Administrator { get; set; }
        public bool Coordinator { get; set; }
        public bool Mentor { get; set; }
        public bool Student { get; set; }
    }
}
