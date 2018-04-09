﻿// <auto-generated />
using ClassroomSailor.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ClassroomSailor.Repositories.Migrations
{
    [DbContext(typeof(ClassroomSailorDbContext))]
    [Migration("20180409163910_Fourth")]
    partial class Fourth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClassroomSailor.Entities.Student.StudentEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AdmissionDate");

                    b.Property<string>("AdmissionNumber")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(16);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<short>("Grade");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ClassroomSailor.Entities.Subject.SubjectEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<long?>("StudentEntityId");

                    b.Property<long?>("TeacherEntityId");

                    b.HasKey("Id");

                    b.HasIndex("StudentEntityId");

                    b.HasIndex("TeacherEntityId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ClassroomSailor.Entities.Teacher.TeacherEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(16);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("JoiningDate");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ClassroomSailor.Entities.Subject.SubjectEntity", b =>
                {
                    b.HasOne("ClassroomSailor.Entities.Student.StudentEntity")
                        .WithMany("Subjects")
                        .HasForeignKey("StudentEntityId");

                    b.HasOne("ClassroomSailor.Entities.Teacher.TeacherEntity")
                        .WithMany("Subjects")
                        .HasForeignKey("TeacherEntityId");
                });
#pragma warning restore 612, 618
        }
    }
}
