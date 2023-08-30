﻿// <auto-generated />
using Image.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Image.Migrations
{
    [DbContext(typeof(EmployeDbContext))]
    partial class EmployeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployModelHobbyModel", b =>
                {
                    b.Property<int>("EmployModelId")
                        .HasColumnType("int");

                    b.Property<int>("HobbiesID")
                        .HasColumnType("int");

                    b.HasKey("EmployModelId", "HobbiesID");

                    b.HasIndex("HobbiesID");

                    b.ToTable("EmployeeHobbies", (string)null);
                });

            modelBuilder.Entity("Image.Models.EmployModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employes");
                });

            modelBuilder.Entity("Image.Models.HobbyModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Hobbies");
                });

            modelBuilder.Entity("EmployModelHobbyModel", b =>
                {
                    b.HasOne("Image.Models.EmployModel", null)
                        .WithMany()
                        .HasForeignKey("EmployModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Image.Models.HobbyModel", null)
                        .WithMany()
                        .HasForeignKey("HobbiesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
