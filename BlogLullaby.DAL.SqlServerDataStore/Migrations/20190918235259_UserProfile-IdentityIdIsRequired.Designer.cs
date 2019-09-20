﻿// <auto-generated />
using System;
using BlogLullaby.DAL.SqlServerDataStore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogLullaby.BlogLullaby.DAL.SqlServerDataStore.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    [Migration("20190918235259_UserProfile-IdentityIdIsRequired")]
    partial class UserProfileIdentityIdIsRequired
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogLullaby.DAL.DataStore.Entities.Dialog", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DialogName")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Dialogs");
                });

            modelBuilder.Entity("BlogLullaby.DAL.DataStore.Entities.DialogMember", b =>
                {
                    b.Property<string>("FirstKey")
                        .HasColumnName("DialogId");

                    b.Property<int>("SecondKey")
                        .HasColumnName("UserProfileId");

                    b.HasKey("FirstKey", "SecondKey");

                    b.HasIndex("SecondKey");

                    b.ToTable("DialogMembers");
                });

            modelBuilder.Entity("BlogLullaby.DAL.DataStore.Entities.Message", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 9, 19, 2, 52, 57, 354, DateTimeKind.Local).AddTicks(4844));

                    b.Property<string>("DialogId");

                    b.Property<int?>("UserProfileId");

                    b.HasKey("Id");

                    b.HasIndex("DialogId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("BlogLullaby.DAL.DataStore.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 9, 19, 2, 52, 57, 340, DateTimeKind.Local).AddTicks(6735));

                    b.Property<string>("MainImageUrl");

                    b.Property<string>("Title")
                        .HasMaxLength(500);

                    b.Property<int?>("UserProfileId");

                    b.Property<int>("Visits")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BlogLullaby.DAL.DataStore.Entities.PostBodyBlock", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlockType");

                    b.Property<string>("Content");

                    b.Property<int>("Position");

                    b.Property<int?>("PostId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostBodyBlocks");
                });

            modelBuilder.Entity("BlogLullaby.DAL.DataStore.Entities.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarUrl");

                    b.Property<string>("City")
                        .HasMaxLength(30);

                    b.Property<string>("Description");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30);

                    b.Property<string>("IdentityUserId")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("LastName")
                        .HasMaxLength(30);

                    b.Property<DateTime>("LastVisit")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 9, 19, 2, 52, 57, 175, DateTimeKind.Local).AddTicks(2857));

                    b.Property<string>("PhotoUrl");

                    b.Property<string>("Specialization")
                        .HasMaxLength(50);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("BlogLullaby.DAL.DataStore.Entities.DialogMember", b =>
                {
                    b.HasOne("BlogLullaby.DAL.DataStore.Entities.Dialog", "Dialog")
                        .WithMany("DialogMembers")
                        .HasForeignKey("FirstKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlogLullaby.DAL.DataStore.Entities.UserProfile", "UserProfile")
                        .WithMany("DialogMembers")
                        .HasForeignKey("SecondKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlogLullaby.DAL.DataStore.Entities.Message", b =>
                {
                    b.HasOne("BlogLullaby.DAL.DataStore.Entities.Dialog", "Dialog")
                        .WithMany("Messages")
                        .HasForeignKey("DialogId");

                    b.HasOne("BlogLullaby.DAL.DataStore.Entities.UserProfile", "UserProfile")
                        .WithMany("Messages")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("BlogLullaby.DAL.DataStore.Entities.Post", b =>
                {
                    b.HasOne("BlogLullaby.DAL.DataStore.Entities.UserProfile", "UserProfile")
                        .WithMany("Posts")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("BlogLullaby.DAL.DataStore.Entities.PostBodyBlock", b =>
                {
                    b.HasOne("BlogLullaby.DAL.DataStore.Entities.Post", "Post")
                        .WithMany("BodyBlocks")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
