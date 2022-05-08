﻿// <auto-generated />
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfCore.CodeFirst.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220508124040_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfCore.CodeFirst.DAL.BasePerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("EfCore.CodeFirst.DAL.Employee", b =>
                {
                    b.HasBaseType("EfCore.CodeFirst.DAL.BasePerson");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EfCore.CodeFirst.DAL.Manager", b =>
                {
                    b.HasBaseType("EfCore.CodeFirst.DAL.BasePerson");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("EfCore.CodeFirst.DAL.Employee", b =>
                {
                    b.HasOne("EfCore.CodeFirst.DAL.BasePerson", null)
                        .WithOne()
                        .HasForeignKey("EfCore.CodeFirst.DAL.Employee", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCore.CodeFirst.DAL.Manager", b =>
                {
                    b.HasOne("EfCore.CodeFirst.DAL.BasePerson", null)
                        .WithOne()
                        .HasForeignKey("EfCore.CodeFirst.DAL.Manager", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}