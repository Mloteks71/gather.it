﻿// <auto-generated />
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(GatherItDbContext))]
    [Migration("20250326155429_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CityJobAd", b =>
                {
                    b.Property<int>("CitiesId")
                        .HasColumnType("integer");

                    b.Property<int>("JobAdsId")
                        .HasColumnType("integer");

                    b.HasKey("CitiesId", "JobAdsId");

                    b.HasIndex("JobAdsId");

                    b.ToTable("CityJobAd");
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Citys");
                });

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Domain.Entities.CompanyName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyNames");
                });

            modelBuilder.Entity("Domain.Entities.JobAd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CompanyNameId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("RemotePercent")
                        .HasColumnType("integer");

                    b.Property<int>("RemoteType")
                        .HasColumnType("integer");

                    b.Property<string>("Slug")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyNameId");

                    b.ToTable("JobAds");
                });

            modelBuilder.Entity("Domain.Entities.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContractType")
                        .HasColumnType("integer");

                    b.Property<int>("JobAdId")
                        .HasColumnType("integer");

                    b.Property<int>("SalaryMax")
                        .HasColumnType("integer");

                    b.Property<int>("SalaryMin")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("JobAdId");

                    b.ToTable("Salarys");
                });

            modelBuilder.Entity("Domain.Entities.Search", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Query")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SiteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Searchs");
                });

            modelBuilder.Entity("Domain.Entities.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("CityJobAd", b =>
                {
                    b.HasOne("Domain.Entities.City", null)
                        .WithMany()
                        .HasForeignKey("CitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.JobAd", null)
                        .WithMany()
                        .HasForeignKey("JobAdsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.CompanyName", b =>
                {
                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany("Names")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Entities.JobAd", b =>
                {
                    b.HasOne("Domain.Entities.CompanyName", "CompanyName")
                        .WithMany()
                        .HasForeignKey("CompanyNameId");

                    b.Navigation("CompanyName");
                });

            modelBuilder.Entity("Domain.Entities.Salary", b =>
                {
                    b.HasOne("Domain.Entities.JobAd", "JobAd")
                        .WithMany("Salaries")
                        .HasForeignKey("JobAdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobAd");
                });

            modelBuilder.Entity("Domain.Entities.Search", b =>
                {
                    b.HasOne("Domain.Entities.Site", "Site")
                        .WithMany("Searchs")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.Navigation("Names");
                });

            modelBuilder.Entity("Domain.Entities.JobAd", b =>
                {
                    b.Navigation("Salaries");
                });

            modelBuilder.Entity("Domain.Entities.Site", b =>
                {
                    b.Navigation("Searchs");
                });
#pragma warning restore 612, 618
        }
    }
}
