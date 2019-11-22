using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GroupStack.Models;

namespace GroupStack.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cohort> Cohort { get; set; }
        public DbSet<Whitelist> Whitelist { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Preferences> Preferences { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<GroupAssignment> GroupAssignment { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Whitelist>().HasKey(c => new { c.CohortId, c.UserId });
            builder.Entity<Preferences>().HasKey(c => new { c.StudentId, c.CohortId });
            builder.Entity<GroupAssignment>().HasKey(c => new { c.GroupId, c.StudentId });
        }
    }
}
