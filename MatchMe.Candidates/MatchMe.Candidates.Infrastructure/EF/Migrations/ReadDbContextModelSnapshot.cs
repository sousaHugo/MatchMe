﻿// <auto-generated />
using System;
using MatchMe.Candidates.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MatchMe.Candidates.Infrastructure.EF.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    partial class ReadDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("candidates")
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MatchMe.Candidates.Infrastructure.EF.Models.CandidateReadModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("CitizenCardNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("FiscalNumber")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MaritalStatus")
                        .HasColumnType("text");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("text");

                    b.Property<string>("Nationality")
                        .HasColumnType("text");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Candidate", "candidates");
                });

            modelBuilder.Entity("MatchMe.Candidates.Infrastructure.EF.Models.CandidateSkillReadModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CandidateId")
                        .HasColumnType("bigint");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("CandidateSkill", "candidates");
                });

            modelBuilder.Entity("MatchMe.Candidates.Infrastructure.EF.Models.CandidateSkillReadModel", b =>
                {
                    b.HasOne("MatchMe.Candidates.Infrastructure.EF.Models.CandidateReadModel", "Candidate")
                        .WithMany("Skills")
                        .HasForeignKey("CandidateId");

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("MatchMe.Candidates.Infrastructure.EF.Models.CandidateReadModel", b =>
                {
                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
