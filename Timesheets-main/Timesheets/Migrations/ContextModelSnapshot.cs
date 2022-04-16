﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Timesheets.DAL.Repository.DataBase;

namespace Timesheets.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Timesheets.DAL.Entities.ContractEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CustomerEntityId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("IsDeleteDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CustomerEntityId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Timesheets.DAL.Entities.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("IsDeleteDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Timesheets.DAL.Entities.EmployeeDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("IsDeleteDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Timesheets.DAL.Entities.InvoiceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("IsDeleteDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Sum")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Timesheets.DAL.Entities.TaskEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("EmployeeEntityId")
                        .HasColumnType("integer");

                    b.Property<int?>("InvoiceEntityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("IsDeleteDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDone")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("IsDoneDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsTaken")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("IsTakenDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeEntityId");

                    b.HasIndex("InvoiceEntityId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Timesheets.DAL.Entities.ContractEntity", b =>
                {
                    b.HasOne("Timesheets.DAL.Entities.CustomerEntity", null)
                        .WithMany("Contracts")
                        .HasForeignKey("CustomerEntityId");

                    b.HasOne("Timesheets.DAL.Entities.InvoiceEntity", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Timesheets.DAL.Entities.TaskEntity", b =>
                {
                    b.HasOne("Timesheets.DAL.Entities.EmployeeDto", null)
                        .WithMany("Tasks")
                        .HasForeignKey("EmployeeEntityId");

                    b.HasOne("Timesheets.DAL.Entities.InvoiceEntity", null)
                        .WithMany("Tasks")
                        .HasForeignKey("InvoiceEntityId");
                });

            modelBuilder.Entity("Timesheets.DAL.Entities.CustomerEntity", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("Timesheets.DAL.Entities.EmployeeDto", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Timesheets.DAL.Entities.InvoiceEntity", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
