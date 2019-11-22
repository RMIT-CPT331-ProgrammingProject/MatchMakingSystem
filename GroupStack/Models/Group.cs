using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupStack.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public int ProjectId { get; set; }
        public int CohortId { get; set; } /* Kluge for database error.*/

        [DisplayName("Group Name")]
        public string GroupName { get; set; }

        [DisplayName("Available Times")]
        public string TimesJSON { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
        public virtual List<GroupAssignment> GroupAssignments { get; set; }

        public Group()
        {
            this.GroupAssignments = new List<GroupAssignment>();
        }

        public Group(Project project, int cohortId)
        {
            this.ProjectId = project.ProjectId;
            this.CohortId = cohortId;
            this.GroupName = project.ProjectName;
            this.GroupAssignments = new List<GroupAssignment>();
        }
    }
}
