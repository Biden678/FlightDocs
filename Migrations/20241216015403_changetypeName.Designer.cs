﻿// <auto-generated />
using System;
using FlightDocs.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightDocs.Migrations
{
    [DbContext(typeof(DB))]
    [Migration("20241216015403_changetypeName")]
    partial class changetypeName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FlightDocs.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("groupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("groupId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("FlightDocs.Models.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("flightNo")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.HasIndex("flightNo");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("FlightDocs.Models.DocumentDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("documentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("updatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("updatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("documentId");

                    b.ToTable("DocumentDetail");
                });

            modelBuilder.Entity("FlightDocs.Models.DocumentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("FlightDocs.Models.DocumentTypePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DocumentTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("PermissionId");

                    b.ToTable("TypePermissions");
                });

            modelBuilder.Entity("FlightDocs.Models.Flight", b =>
                {
                    b.Property<string>("flightNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("DocumentDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("departureDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pointOfLoading")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pointOfUnloading")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("flightNo");

                    b.HasIndex("DocumentDetailId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("FlightDocs.Models.FlightAssignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("accountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("flightNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("groupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("accountId");

                    b.HasIndex("flightNo");

                    b.ToTable("FlightAssignment");
                });

            modelBuilder.Entity("FlightDocs.Models.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nameGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("FlightDocs.Models.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("function")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("GroupPermission", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("GroupPermission");
                });

            modelBuilder.Entity("FlightDocs.Models.Account", b =>
                {
                    b.HasOne("FlightDocs.Models.Group", "Group")
                        .WithMany("Accounts")
                        .HasForeignKey("groupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("FlightDocs.Models.Document", b =>
                {
                    b.HasOne("FlightDocs.Models.DocumentType", "Type")
                        .WithMany("Document")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightDocs.Models.Flight", "Flight")
                        .WithMany("Document")
                        .HasForeignKey("flightNo");

                    b.Navigation("Flight");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("FlightDocs.Models.DocumentDetail", b =>
                {
                    b.HasOne("FlightDocs.Models.Document", "Document")
                        .WithMany("Detail")
                        .HasForeignKey("documentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("FlightDocs.Models.DocumentTypePermission", b =>
                {
                    b.HasOne("FlightDocs.Models.DocumentType", "DocumentType")
                        .WithMany("DocumentTypePermission")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightDocs.Models.Permission", "Permission")
                        .WithMany("DocumentTypePermission")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("FlightDocs.Models.Flight", b =>
                {
                    b.HasOne("FlightDocs.Models.DocumentDetail", null)
                        .WithMany("Flight")
                        .HasForeignKey("DocumentDetailId");
                });

            modelBuilder.Entity("FlightDocs.Models.FlightAssignment", b =>
                {
                    b.HasOne("FlightDocs.Models.Account", "Account")
                        .WithMany("FlightAssignment")
                        .HasForeignKey("accountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightDocs.Models.Flight", "Flight")
                        .WithMany("FlightAssignment")
                        .HasForeignKey("flightNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("GroupPermission", b =>
                {
                    b.HasOne("FlightDocs.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightDocs.Models.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlightDocs.Models.Account", b =>
                {
                    b.Navigation("FlightAssignment");
                });

            modelBuilder.Entity("FlightDocs.Models.Document", b =>
                {
                    b.Navigation("Detail");
                });

            modelBuilder.Entity("FlightDocs.Models.DocumentDetail", b =>
                {
                    b.Navigation("Flight");
                });

            modelBuilder.Entity("FlightDocs.Models.DocumentType", b =>
                {
                    b.Navigation("Document");

                    b.Navigation("DocumentTypePermission");
                });

            modelBuilder.Entity("FlightDocs.Models.Flight", b =>
                {
                    b.Navigation("Document");

                    b.Navigation("FlightAssignment");
                });

            modelBuilder.Entity("FlightDocs.Models.Group", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("FlightDocs.Models.Permission", b =>
                {
                    b.Navigation("DocumentTypePermission");
                });
#pragma warning restore 612, 618
        }
    }
}
