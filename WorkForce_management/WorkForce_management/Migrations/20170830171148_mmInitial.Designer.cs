using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WorkForce_management.Models;

namespace WorkForce_management.Migrations
{
    [DbContext(typeof(WorkForce_managementContext))]
    [Migration("20170830171148_mmInitial")]
    partial class mmInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorkForce_management.Models.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComputerMake")
                        .IsRequired();

                    b.Property<string>("ComputerManufacturer");

                    b.Property<DateTime>("PurchaseDate");

                    b.HasKey("Id");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("WorkForce_management.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentName");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("WorkForce_management.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("WorkForce_management.Models.EmployeeComputer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ComputerId");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeComputer");
                });

            modelBuilder.Entity("WorkForce_management.Models.TrainingProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("MaxNumber");

                    b.Property<DateTime>("StrateDate");

                    b.Property<string>("TraingingProgramName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("TrainingProgram");
                });

            modelBuilder.Entity("WorkForce_management.Models.TrainingProgramEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<int>("TrainingId");

                    b.Property<int?>("TrainingProgramId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TrainingProgramId");

                    b.ToTable("TrainingProgramEmployee");
                });

            modelBuilder.Entity("WorkForce_management.Models.Employee", b =>
                {
                    b.HasOne("WorkForce_management.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorkForce_management.Models.EmployeeComputer", b =>
                {
                    b.HasOne("WorkForce_management.Models.Computer", "Computer")
                        .WithMany("EmployeeComputers")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorkForce_management.Models.Employee", "Employee")
                        .WithMany("EmployeeComputers")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorkForce_management.Models.TrainingProgramEmployee", b =>
                {
                    b.HasOne("WorkForce_management.Models.Employee", "Employee")
                        .WithMany("TrainingProgramEmployee")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorkForce_management.Models.TrainingProgram", "TrainingProgram")
                        .WithMany("TrainingProgramEmployee")
                        .HasForeignKey("TrainingProgramId");
                });
        }
    }
}
