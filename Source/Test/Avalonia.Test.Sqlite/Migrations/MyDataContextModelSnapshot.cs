﻿// <auto-generated />
using System;
using Avalonia.Test.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Avalonia.Test.Sqlite.Migrations
{
    [DbContext(typeof(MyDataContext))]
    partial class MyDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("Avalonia.Test.Sqlite.mbc_dv_image", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("AreaType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ArticulationType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Aspect")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CDATE")
                        .HasColumnType("TEXT");

                    b.Property<string>("CaseType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ExtendType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FromType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ISENBLED")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MediaType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderNum")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayCount")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Resoluction")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Score")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TagTypes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UDATE")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VipType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("mbc_dv_images");
                });
#pragma warning restore 612, 618
        }
    }
}