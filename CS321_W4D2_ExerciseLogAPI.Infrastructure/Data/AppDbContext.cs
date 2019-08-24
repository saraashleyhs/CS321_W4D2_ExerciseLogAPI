﻿using System;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<ActivityType> ActivityTypes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = ../CS321_W4D2_ExerciseLogAPI.Infrastructure/ExerciseLog.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityType>().HasData(
    new ActivityType { Id = 1, Name = "Running", RecordType = RecordType.DurationAndDistance },
    new ActivityType { Id = 2, Name = "Weights", RecordType = RecordType.DurationOnly },
    new ActivityType { Id = 3, Name = "Walking", RecordType = RecordType.DurationAndDistance }
);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Test User" }
            );

            // TODO: configure some seed data in the books table
            modelBuilder.Entity<Activity>().HasData(
                new Activity { Id = 1, UserId = 1, ActivityTypeId = 1, Date = new DateTime(2019, 6, 19), Distance = 3, Duration = 30, Notes = "Hot!!!!" }
            );

            //modelBuilder.Entity<ActivityType>().HasData(
            //    new ActivityType {Id = 0, Name = "Test Type-Running", RecordType = RecordType.DurationOnly });
        }
        }
    }

