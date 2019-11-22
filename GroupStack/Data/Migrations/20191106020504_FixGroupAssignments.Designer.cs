﻿// <auto-generated />
using System;
using GroupStack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GroupStack.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191106020504_FixGroupAssignments")]
    partial class FixGroupAssignments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroupStack.Models.Cohort", b =>
                {
                    b.Property<int>("CohortId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CohortName");

                    b.Property<string>("CoordinatorId");

                    b.Property<bool>("HardDeadline");

                    b.Property<int>("MaxSize");

                    b.Property<int>("MinSize");

                    b.Property<DateTime>("PreferencesDeadline");

                    b.Property<string>("UniName");

                    b.HasKey("CohortId");

                    b.ToTable("Cohort");
                });

            modelBuilder.Entity("GroupStack.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CohortId");

                    b.Property<string>("GroupName");

                    b.Property<int>("ProjectId");

                    b.Property<string>("TimesJSON");

                    b.HasKey("GroupId");

                    b.HasIndex("CohortId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("GroupStack.Models.GroupAssignment", b =>
                {
                    b.Property<int>("GroupId");

                    b.Property<string>("StudentId");

                    b.Property<string>("Role");

                    b.HasKey("GroupId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("GroupAssignment");
                });

            modelBuilder.Entity("GroupStack.Models.Preferences", b =>
                {
                    b.Property<string>("StudentId");

                    b.Property<int>("CohortId");

                    b.Property<int?>("ProjectIdFirst");

                    b.Property<int?>("ProjectIdSecond");

                    b.Property<int?>("ProjectIdThird");

                    b.Property<string>("TimesJSON");

                    b.HasKey("StudentId", "CohortId");

                    b.HasIndex("CohortId");

                    b.HasIndex("ProjectIdFirst");

                    b.HasIndex("ProjectIdSecond");

                    b.HasIndex("ProjectIdThird");

                    b.ToTable("Preferences");
                });

            modelBuilder.Entity("GroupStack.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CohortId");

                    b.Property<string>("Description");

                    b.Property<int>("MaxGroups");

                    b.Property<int>("MaxSize");

                    b.Property<string>("MentorId");

                    b.Property<int>("MinSize");

                    b.Property<string>("ProjectName");

                    b.HasKey("ProjectId");

                    b.HasIndex("CohortId");

                    b.HasIndex("MentorId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("GroupStack.Models.Whitelist", b =>
                {
                    b.Property<int>("CohortId");

                    b.Property<string>("UserId");

                    b.Property<bool>("IsMentor");

                    b.HasKey("CohortId", "UserId");

                    b.ToTable("Whitelist");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GroupStack.Models.Group", b =>
                {
                    b.HasOne("GroupStack.Models.Cohort")
                        .WithMany("Groups")
                        .HasForeignKey("CohortId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GroupStack.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GroupStack.Models.GroupAssignment", b =>
                {
                    b.HasOne("GroupStack.Models.Group", "Group")
                        .WithMany("GroupAssignments")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GroupStack.Models.Preferences", b =>
                {
                    b.HasOne("GroupStack.Models.Cohort", "Cohort")
                        .WithMany()
                        .HasForeignKey("CohortId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GroupStack.Models.Project", "ProjectFirst")
                        .WithMany()
                        .HasForeignKey("ProjectIdFirst");

                    b.HasOne("GroupStack.Models.Project", "ProjectSecond")
                        .WithMany()
                        .HasForeignKey("ProjectIdSecond");

                    b.HasOne("GroupStack.Models.Project", "ProjectThird")
                        .WithMany()
                        .HasForeignKey("ProjectIdThird");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GroupStack.Models.Project", b =>
                {
                    b.HasOne("GroupStack.Models.Cohort", "Cohort")
                        .WithMany("Projects")
                        .HasForeignKey("CohortId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Mentor")
                        .WithMany()
                        .HasForeignKey("MentorId");
                });

            modelBuilder.Entity("GroupStack.Models.Whitelist", b =>
                {
                    b.HasOne("GroupStack.Models.Cohort", "Cohort")
                        .WithMany("Whitelist")
                        .HasForeignKey("CohortId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
