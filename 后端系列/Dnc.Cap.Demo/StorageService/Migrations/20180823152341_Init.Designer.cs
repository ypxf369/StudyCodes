﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StorageService.Models.Databases;

namespace StorageService.Migrations
{
    [DbContext(typeof(StorageDbContext))]
    [Migration("20180823152341_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StorageService.Models.Entities.Storage", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StorageID");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnName("CreatedTime");

                    b.Property<int>("StorageNumber")
                        .HasColumnName("StorageNumber");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnName("UpdatedTime");

                    b.HasKey("ID");

                    b.ToTable("Storages");
                });
#pragma warning restore 612, 618
        }
    }
}
