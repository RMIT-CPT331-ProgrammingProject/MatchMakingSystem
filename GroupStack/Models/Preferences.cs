using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupStack.Models
{
    public class Preferences
    {
        [DisplayName("Student")]
        public string StudentId { get; set; }
        [DisplayName("Cohort")]
        public int CohortId { get; set; }

        [DisplayName("First Choice")]
        public int? ProjectIdFirst { get; set; }
        [DisplayName("Second Choice")]
        public int? ProjectIdSecond { get; set; }
        [DisplayName("Third Choice")]
        public int? ProjectIdThird { get; set; }

        [DisplayName("Available Times")]
        public string TimesJSON { get; set; }

        public virtual IdentityUser Student { get; set; }
        public virtual Cohort Cohort { get; set; }

        [ForeignKey("ProjectIdFirst")]
        public virtual Project ProjectFirst { get; set; }
        [ForeignKey("ProjectIdSecond")]
        public virtual Project ProjectSecond { get; set; }
        [ForeignKey("ProjectIdThird")]
        public virtual Project ProjectThird { get; set; }
    }
}
