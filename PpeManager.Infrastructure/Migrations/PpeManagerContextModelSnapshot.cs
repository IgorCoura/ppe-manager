﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PpeManager.Infrastructure;

#nullable disable

namespace PpeManager.Infrastructure.Migrations
{
    [DbContext(typeof(PpeManagerContext))]
    partial class PpeManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("companyseq", "ppemanager")
                .IncrementsBy(10);

            modelBuilder.HasSequence("ppeCertificationseq", "ppemanager")
                .IncrementsBy(10);

            modelBuilder.HasSequence("ppeseq", "ppemanager")
                .IncrementsBy(10);

            modelBuilder.HasSequence("workerseq", "ppemanager")
                .IncrementsBy(10);

            modelBuilder.Entity("Microsoft.eShopOnContainers.Services.Ordering.Infrastructure.Idempotency.ClientRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("requests", "ppemanager");
                });

            modelBuilder.Entity("PpeManager.Domain.AggregatesModel.AggregateCompany.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "companyseq", "ppemanager");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("companies", "ppemanager");
                });

            modelBuilder.Entity("PpeManager.Domain.AggregatesModel.AggregatePpe.Ppe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "ppeseq", "ppemanager");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ppes", "ppemanager");
                });

            modelBuilder.Entity("PpeManager.Domain.AggregatesModel.AggregatePpe.PpeCertification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "ppeCertificationseq", "ppemanager");

                    b.Property<string>("ApprovalCertificateNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Durability")
                        .HasColumnType("integer");

                    b.Property<int>("PpeId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("Validity")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("PpeId");

                    b.ToTable("ppeCertifications", "ppemanager");
                });

            modelBuilder.Entity("PpeManager.Domain.AggregatesModel.AggregateWorker.PpePossession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Confirmation")
                        .HasColumnType("boolean");

                    b.Property<DateOnly>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<int>("PpeCertificationId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("SupportingDocument")
                        .HasColumnType("text");

                    b.Property<DateOnly>("Validity")
                        .HasColumnType("date");

                    b.Property<int>("WorkerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PpeCertificationId");

                    b.HasIndex("WorkerId");

                    b.ToTable("ppePossession", "ppemanager");
                });

            modelBuilder.Entity("PpeManager.Domain.AggregatesModel.AggregateWorker.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "workerseq", "ppemanager");

                    b.Property<DateOnly>("AdmissionDate")
                        .HasColumnType("date");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsOpenPpePossessionProcess")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("workers", "ppemanager");
                });

            modelBuilder.Entity("PpeWorker", b =>
                {
                    b.Property<int>("PpesId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkersId")
                        .HasColumnType("integer");

                    b.HasKey("PpesId", "WorkersId");

                    b.HasIndex("WorkersId");

                    b.ToTable("PpeWorker", "ppemanager");
                });

            modelBuilder.Entity("PpeManager.Domain.AggregatesModel.AggregatePpe.PpeCertification", b =>
                {
                    b.HasOne("PpeManager.Domain.AggregatesModel.AggregatePpe.Ppe", "Ppe")
                        .WithMany("PpeCertifications")
                        .HasForeignKey("PpeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ppe");
                });

            modelBuilder.Entity("PpeManager.Domain.AggregatesModel.AggregateWorker.PpePossession", b =>
                {
                    b.HasOne("PpeManager.Domain.AggregatesModel.AggregatePpe.PpeCertification", "PpeCertification")
                        .WithMany()
                        .HasForeignKey("PpeCertificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PpeManager.Domain.AggregatesModel.AggregateWorker.Worker", "Worker")
                        .WithMany("PpePossessions")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PpeCertification");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("PpeManager.Domain.AggregatesModel.AggregateWorker.Worker", b =>
                {
                    b.HasOne("PpeManager.Domain.AggregatesModel.AggregateCompany.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("PpeWorker", b =>
                {
                    b.HasOne("PpeManager.Domain.AggregatesModel.AggregatePpe.Ppe", null)
                        .WithMany()
                        .HasForeignKey("PpesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PpeManager.Domain.AggregatesModel.AggregateWorker.Worker", null)
                        .WithMany()
                        .HasForeignKey("WorkersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PpeManager.Domain.AggregatesModel.AggregatePpe.Ppe", b =>
                {
                    b.Navigation("PpeCertifications");
                });

            modelBuilder.Entity("PpeManager.Domain.AggregatesModel.AggregateWorker.Worker", b =>
                {
                    b.Navigation("PpePossessions");
                });
#pragma warning restore 612, 618
        }
    }
}
