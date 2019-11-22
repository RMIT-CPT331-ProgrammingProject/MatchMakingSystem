using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GroupStack.Models
{
    public class Cohort
    {
        public int CohortId { get; set; }
        [DisplayName("Coordinator")]
        public string CoordinatorId { get; set; }
        [DisplayName("Cohort Name")]
        public string CohortName { get; set; } /* User-readable identifier e.g. "Programming Project 2019 Period 2" */

        [DisplayName("University")]
        public string UniName { get; set; }
        [DisplayName("Min")]
        public int MinSize { get; set; } /* Minimum size of groups assigned to this project. */
        [DisplayName("Max")]
        public int MaxSize { get; set; } /* Maximum size of groups assigned to this project. */
        [DisplayName("Preferences Deadline")]
        public DateTime PreferencesDeadline { get; set; } /* Time by which preferences must be selected. */
        [DisplayName("Allow Late Preferences?")]
        public bool HardDeadline { get; set; } /* Whether to accept preferences changes after deadline but before group assignment. */

        public virtual List<Whitelist> Whitelist { get; set; }
        public virtual List<Project> Projects { get; set; }
        public virtual List<Group> Groups { get; set; }

        public Cohort()
        {
            this.Groups = new List<Group>();
        }
    }
}
