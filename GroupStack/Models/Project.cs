using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupStack.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public int CohortId { get; set; }
        public string MentorId { get; set; }

        public int MinSize { get; set; } /* Minimum size of groups assigned to this project. */
        public int MaxSize { get; set; } /* Maximum size of groups assigned to this project. */
        public int MaxGroups { get; set; } /* Maximum number of groups that can be assigned to this project. */
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }
        public string Description { get; set; }

        [ForeignKey("CohortId")]
        public virtual Cohort Cohort { get; set; }
        [ForeignKey("MentorId")]
        public virtual IdentityUser Mentor { get; set; }
    }
}
