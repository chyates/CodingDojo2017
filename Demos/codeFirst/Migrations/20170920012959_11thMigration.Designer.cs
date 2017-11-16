using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using codeFirst.Models;

namespace codeFirst.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20170920012959_11thMigration")]
    partial class _11thMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("codeFirst.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("codeFirst.Models.Membership", b =>
                {
                    b.Property<int>("MembershipId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GroupId");

                    b.Property<int>("UserId");

                    b.Property<long?>("UserId1");

                    b.HasKey("MembershipId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId1");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("codeFirst.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("Zip");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("codeFirst.Models.Membership", b =>
                {
                    b.HasOne("codeFirst.Models.Group", "Group")
                        .WithMany("Members")
                        .HasForeignKey("GroupId");

                    b.HasOne("codeFirst.Models.User", "User")
                        .WithMany("Memberships")
                        .HasForeignKey("UserId1");
                });
        }
    }
}
