﻿// <auto-generated />
using System;
using CS321_W4D2_ExerciseLogAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190824205313_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("CS321_W4D2_ExerciseLogAPI.Core.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityTypeId");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Distance");

                    b.Property<double>("Duration");

                    b.Property<string>("Notes");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ActivityTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActivityTypeId = 1,
                            Date = new DateTime(2019, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Distance = 3.0,
                            Duration = 30.0,
                            Notes = "Hot!!!!",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("CS321_W4D2_ExerciseLogAPI.Core.Models.ActivityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("RecordType");

                    b.HasKey("Id");

                    b.ToTable("ActivityTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Running",
                            RecordType = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Weights",
                            RecordType = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Walking",
                            RecordType = 1
                        });
                });

            modelBuilder.Entity("CS321_W4D2_ExerciseLogAPI.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Test User"
                        });
                });

            modelBuilder.Entity("CS321_W4D2_ExerciseLogAPI.Core.Models.Activity", b =>
                {
                    b.HasOne("CS321_W4D2_ExerciseLogAPI.Core.Models.ActivityType", "ActivityType")
                        .WithMany()
                        .HasForeignKey("ActivityTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CS321_W4D2_ExerciseLogAPI.Core.Models.User", "User")
                        .WithMany("Activities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}