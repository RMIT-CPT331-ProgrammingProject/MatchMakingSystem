using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupStack.Models
{
    public class Whitelist
    {
        [DisplayName("Cohort")]
        public int CohortId { get; set; }
        [DisplayName("Email")]
        public string UserId { get; set; }
        [DisplayName("Project Mentor?")]
        public bool IsMentor { get; set; }

        [ForeignKey("CohortId")]
        public virtual Cohort Cohort { get; set; }
    }
}
