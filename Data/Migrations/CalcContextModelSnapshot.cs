﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(CalcContext))]
    partial class CalcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Models.CalcHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("FirstNumber")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MathOperatorId")
                        .HasColumnType("int");

                    b.Property<decimal>("SecondNumber")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MathOperatorId");

                    b.ToTable("CalcHistory", (string)null);
                });

            modelBuilder.Entity("Data.Models.MathOperator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("OperationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MathOperator", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OperationName = "Scitani",
                            Symbol = "+"
                        },
                        new
                        {
                            Id = 2,
                            OperationName = "Odcitani",
                            Symbol = "-"
                        },
                        new
                        {
                            Id = 3,
                            OperationName = "Nasobeni",
                            Symbol = "*"
                        },
                        new
                        {
                            Id = 4,
                            OperationName = "Deleni",
                            Symbol = "/"
                        });
                });

            modelBuilder.Entity("Data.Models.CalcHistory", b =>
                {
                    b.HasOne("Data.Models.MathOperator", "MathOperator")
                        .WithMany()
                        .HasForeignKey("MathOperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MathOperator");
                });
#pragma warning restore 612, 618
        }
    }
}