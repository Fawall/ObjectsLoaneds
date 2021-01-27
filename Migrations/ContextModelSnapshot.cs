﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ObjectsLoaneds.Data;

namespace ObjectsLoaneds.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ObjectsLoaneds.Models.ObjectsLoanedsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateLoanedObject")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LimitDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameObjectLoaned")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamePeopleLoaned")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ObjectsLoaneds");
                });
#pragma warning restore 612, 618
        }
    }
}
