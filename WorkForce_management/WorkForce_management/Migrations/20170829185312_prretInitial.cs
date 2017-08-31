﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkForce_management.Migrations
{
    public partial class prretInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TrainingProgram",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxNumber",
                table: "TrainingProgram",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TrainingProgram");

            migrationBuilder.DropColumn(
                name: "MaxNumber",
                table: "TrainingProgram");
        }
    }
}
