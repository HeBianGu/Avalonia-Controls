﻿// <auto-generated />
using System;
using Avalonia.Modules.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Avalonia.Modules.Identity.Migrations
{
    [DbContext(typeof(IdentifyDataContext))]
    [Migration("20240526134225_init")]
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

            modelBuilder.Entity("Avalonia.Modules.Identity.hi_dd_author", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("AuthorCode")
                        .HasColumnType("TEXT")
                        .HasColumnName("author_code")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("CDATE")
                        .HasColumnType("TEXT");

                    b.Property<int>("ISENBLED")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("author_name")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("UDATE")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("hi_dd_authors");

                    b.HasData(
                        new
                        {
                            ID = "{63860D6B-BD59-4620-919D-0DE51877676F}",
                            CDATE = new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8762),
                            ISENBLED = 1,
                            Name = "用户管理",
                            UDATE = new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8762)
                        },
                        new
                        {
                            ID = "{DE3B4992-A5BF-4AD2-80D8-2C9654C47A34}",
                            CDATE = new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8775),
                            ISENBLED = 1,
                            Name = "角色管理",
                            UDATE = new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8775)
                        });
                });

            modelBuilder.Entity("Avalonia.Modules.Identity.hi_dd_role", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CDATE")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT")
                        .HasColumnName("role_code")
                        .HasColumnOrder(2);

                    b.Property<int>("ISENBLED")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("role_name")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("UDATE")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("hi_dd_roles");

                    b.HasData(
                        new
                        {
                            ID = "{4360CE12-E5F4-4EA6-937C-9FDEA4DF06F6}",
                            CDATE = new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8790),
                            Code = "01",
                            ISENBLED = 1,
                            Name = "管理员",
                            UDATE = new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8790)
                        },
                        new
                        {
                            ID = "{0E465AF1-4C5B-417B-B496-E74E8A0D7E5C}",
                            CDATE = new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8794),
                            Code = "02",
                            ISENBLED = 1,
                            Name = "普通用户",
                            UDATE = new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8794)
                        });
                });

            modelBuilder.Entity("Avalonia.Modules.Identity.hi_dd_user", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("account")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("CDATE")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT")
                        .HasColumnName("display")
                        .HasColumnOrder(4);

                    b.Property<bool>("Enable")
                        .HasColumnType("INTEGER")
                        .HasColumnName("enable")
                        .HasColumnOrder(4);

                    b.Property<int>("ISENBLED")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastLoginTime")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_login_time")
                        .HasColumnOrder(6);

                    b.Property<DateTime>("LicenseDeadline")
                        .HasColumnType("TEXT")
                        .HasColumnName("license_deadline")
                        .HasColumnOrder(7);

                    b.Property<string>("Mail")
                        .HasColumnType("TEXT")
                        .HasColumnName("mail")
                        .HasColumnOrder(5);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("user_name")
                        .HasColumnOrder(1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("password")
                        .HasColumnOrder(3);

                    b.Property<string>("RoleID")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("role_id")
                        .HasColumnOrder(8);

                    b.Property<DateTime>("UDATE")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("hi_dd_users");

                    b.HasData(
                        new
                        {
                            ID = "{E12E19D6-FDD9-4DCE-B211-55E58FAFC207}",
                            Account = "admin",
                            CDATE = new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8797),
                            Enable = false,
                            ISENBLED = 1,
                            LastLoginTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LicenseDeadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "超级用户",
                            Password = "123456",
                            RoleID = "{4360CE12-E5F4-4EA6-937C-9FDEA4DF06F6}",
                            UDATE = new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8797)
                        },
                        new
                        {
                            ID = "{A8EE1331-0DA7-42F1-80E2-CD2A20D62BC9}",
                            Account = "user",
                            CDATE = new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8804),
                            Enable = false,
                            ISENBLED = 1,
                            LastLoginTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LicenseDeadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "HeBianGu",
                            Password = "123456",
                            RoleID = "{0E465AF1-4C5B-417B-B496-E74E8A0D7E5C}",
                            UDATE = new DateTime(2024, 5, 26, 21, 42, 24, 995, DateTimeKind.Local).AddTicks(8804)
                        });
                });

            modelBuilder.Entity("hi_dd_authorhi_dd_role", b =>
                {
                    b.Property<string>("AuthorsID")
                        .HasColumnType("TEXT");

                    b.Property<string>("RolesID")
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorsID", "RolesID");

                    b.HasIndex("RolesID");

                    b.ToTable("hi_dd_authorhi_dd_role");
                });

            modelBuilder.Entity("Avalonia.Modules.Identity.hi_dd_user", b =>
                {
                    b.HasOne("Avalonia.Modules.Identity.hi_dd_role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("hi_dd_authorhi_dd_role", b =>
                {
                    b.HasOne("Avalonia.Modules.Identity.hi_dd_author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Avalonia.Modules.Identity.hi_dd_role", null)
                        .WithMany()
                        .HasForeignKey("RolesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Avalonia.Modules.Identity.hi_dd_role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
