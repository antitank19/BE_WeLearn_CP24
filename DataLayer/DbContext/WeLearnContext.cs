using DataLayer.DBObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataLayer.DbContext
{
    public class WeLearnContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public WeLearnContext(DbContextOptions<WeLearnContext> options) : base(options)
        { }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupMember> GroupMembers { get; set; }
        public virtual DbSet<Invite> Invites { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<GroupSubject> GroupSubjects { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScheduleSubject> ScheduleSubjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Account>()
            //    .HasIndex(a => a.Username).IsUnique();
            //modelBuilder.Entity<Account>()
            //    .HasIndex(a => a.Email).IsUnique();
            modelBuilder.Entity<GroupMember>()
                .HasIndex(gm => new { gm.AccountId, gm.GroupId }).IsUnique();
            //
            //modelBuilder.Entity<ReviewDetail>()
            //    .HasOne(r => r.Reviewer)
            //    .WithMany()
            //  
        }
    }
}
