﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using wedding_planner.Models;

namespace wedding_planner.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20170921193751_test8")]
    partial class test8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("wedding_planner.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created_At");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<DateTime>("Updated_At");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("wedding_planner.Models.Wedding", b =>
                {
                    b.Property<long>("WeddingId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bride");

                    b.Property<DateTime>("Created_At");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Groom");

                    b.Property<DateTime>("Updated_At");

                    b.HasKey("WeddingId");

                    b.ToTable("Weddings");
                });
#pragma warning restore 612, 618
        }
    }
}
