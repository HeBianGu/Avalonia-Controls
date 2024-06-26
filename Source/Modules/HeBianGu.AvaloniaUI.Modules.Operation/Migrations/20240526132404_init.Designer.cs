﻿// <auto-generated />
using HeBianGu.AvaloniaUI.Modules.Operation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

#nullable disable

namespace HeBianGu.AvaloniaUI.Modules.Operation.Migrations
{
    [DbContext(typeof(OperationDataContext))]
    [Migration("20240526132404_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("HeBianGu.AvaloniaUI.Modules.Operation.hi_dd_operation", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CDATE")
                        .HasColumnType("TEXT");

                    b.Property<int>("ISENBLED")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<string>("Method")
                        .HasColumnType("TEXT");

                    b.Property<int>("OperationType")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Result")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UDATE")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserID")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("hi_dd_operations");
                });
#pragma warning restore 612, 618
        }
    }
}
