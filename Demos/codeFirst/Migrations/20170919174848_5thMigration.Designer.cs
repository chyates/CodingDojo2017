using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using codeFirst.Models;

namespace codeFirst.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20170919174848_5thMigration")]
    partial class _5thMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("codeFirst.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.Property<long?>("UserId1");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("codeFirst.Models.Membership", b =>
                {
                    b.Property<int>("MembershipId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.Property<long?>("MemberId");

                    b.Property<int>("UserId");

                    b.HasKey("MembershipId");

                    b.HasIndex("GroupId");

                    b.HasIndex("MemberId");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("codeFirst.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("codeFirst.Models.Group", b =>
                {
                    b.HasOne("codeFirst.Models.User", "User")
                        .WithMany("Affiliations")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("codeFirst.Models.Membership", b =>
                {
                    b.HasOne("codeFirst.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("codeFirst.Models.User", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");
                });
        }
    }
}
