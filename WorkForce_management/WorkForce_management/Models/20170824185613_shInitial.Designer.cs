using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WorkForce_management.Models;

namespace WorkForce_management.Migrations
{
    [DbContext(typeof(WorkForce_managementContext))]
    [Migration("20170824185613_shInitial")]
    partial class shInitial
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

                    b.Property<string>("EmployeeName");

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

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("WorkForce_management.Models.TrainingProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StrateDate");

                    b.Property<string>("TraingingProgramName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("TrainingProgram");
                });
        }
    }
}
