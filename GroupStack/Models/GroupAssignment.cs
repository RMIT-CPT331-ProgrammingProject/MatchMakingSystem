using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupStack.Models
{
    public class GroupAssignment
    {
        public int GroupId { get; set; }
        public string StudentId { get; set; }
        public string Role { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
        [ForeignKey("StudentId")]
        public virtual IdentityUser Student { get; set; }

        public GroupAssignment() {}

        public GroupAssignment(Group group, IdentityUser student)
        {
            this.GroupId = group.GroupId;
            this.StudentId = student.Id;
            this.Role = "Team Member";
        }
    }
}
