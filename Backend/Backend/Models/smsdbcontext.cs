﻿using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class smsdbcontext : DbContext 

    {
        public smsdbcontext(DbContextOptions<smsdbcontext> options)
             : base(options) //passing two things  from here db provider , conn string 
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassLecture> ClassLectures { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.ClassLecture)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.ClassLectureId);
        }

    }
}
