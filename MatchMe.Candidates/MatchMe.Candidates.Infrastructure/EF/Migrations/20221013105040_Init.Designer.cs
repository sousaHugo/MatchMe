﻿// <auto-generated />
using System;
using MatchMe.Candidates.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MatchMe.Candidates.Infrastructure.EF.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    [Migration("20221013105040_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("candidates")
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MatchMe.Candidates.Infrastructure.EF.Models.CandidateEducationReadModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("CandidateId1")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Organization")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId1");

                    b.ToTable("CandidateEducation", "candidates");
                });

            modelBuilder.Entity("MatchMe.Candidates.Infrastructure.EF.Models.CandidateExperienceReadModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("CandidateId1")
                        .HasColumnType("bigint");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Responsibilities")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId1");

                    b.ToTable("CandidateExperience", "candidates");
                });

            modelBuilder.Entity("MatchMe.Candidates.Infrastructure.EF.Models.CandidateReadModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

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
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MaritalStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("text");

                    b.Property<string>("Nationality")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Candidate", "candidates");
                });

            modelBuilder.Entity("MatchMe.Candidates.Infrastructure.EF.Models.CandidateSkillReadModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CandidateId1")
                        .HasColumnType("bigint");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId1");

                    b.ToTable("CandidateSkill", "candidates");
                });

            modelBuilder.Entity("MatchMe.Candidates.Infrastructure.EF.Models.CandidateEducationReadModel", b =>
                {
                    b.HasOne("MatchMe.Candidates.Infrastructure.EF.Models.CandidateReadModel", "Candidate")
                        .WithMany("Educations")
                        .HasForeignKey("CandidateId1");

                    b.OwnsOne("MatchMe.Candidates.Infrastructure.EF.Models.AddressReadModel", "Address", b1 =>
                        {
                            b1.Property<long>("CandidateEducationReadModelId")
                                .HasColumnType("bigint");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Country");

                            b1.Property<string>("PostCode")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PostCode");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Street");

                            b1.HasKey("CandidateEducationReadModelId");

                            b1.ToTable("CandidateEducation", "candidates");

                            b1.WithOwner()
                                .HasForeignKey("CandidateEducationReadModelId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("MatchMe.Candidates.Infrastructure.EF.Models.CandidateExperienceReadModel", b =>
                {
                    b.HasOne("MatchMe.Candidates.Infrastructure.EF.Models.CandidateReadModel", "Candidate")
                        .WithMany("Experiencies")
                        .HasForeignKey("CandidateId1");

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("MatchMe.Candidates.Infrastructure.EF.Models.CandidateReadModel", b =>
                {
                    b.OwnsOne("MatchMe.Candidates.Infrastructure.EF.Models.AddressReadModel", "Address", b1 =>
                        {
                            b1.Property<long>("CandidateReadModelId")
                                .HasColumnType("bigint");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Country");

                            b1.Property<string>("PostCode")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PostCode");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Street");

                            b1.HasKey("CandidateReadModelId");

                            b1.ToTable("Candidate", "candidates");

                            b1.WithOwner()
                                .HasForeignKey("CandidateReadModelId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("MatchMe.Candidates.Infrastructure.EF.Models.CandidateSkillReadModel", b =>
                {
                    b.HasOne("MatchMe.Candidates.Infrastructure.EF.Models.CandidateReadModel", "Candidate")
                        .WithMany("Skills")
                        .HasForeignKey("CandidateId1");

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("MatchMe.Candidates.Infrastructure.EF.Models.CandidateReadModel", b =>
                {
                    b.Navigation("Educations");

                    b.Navigation("Experiencies");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}