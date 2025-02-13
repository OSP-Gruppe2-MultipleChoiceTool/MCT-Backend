﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultipleChoiceTool.Infrastructure.Databases;

#nullable disable

namespace MultipleChoiceTool.Infrastructure.Migrations.Sqlite
{
    [DbContext(typeof(SqliteDbContext))]
    partial class SqliteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("MultipleChoiceTool.Infrastructure.Entities.QuestionaireEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Questionaires");
                });

            modelBuilder.Entity("MultipleChoiceTool.Infrastructure.Entities.QuestionaireLinkEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("QuestionaireId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("QuestionaireId");

                    b.ToTable("QuestionaireLinks");
                });

            modelBuilder.Entity("MultipleChoiceTool.Infrastructure.Entities.StatementEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Statement")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StatementSetId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StatementSetId");

                    b.ToTable("Statements");
                });

            modelBuilder.Entity("MultipleChoiceTool.Infrastructure.Entities.StatementSetEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Explaination")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("QuestionaireId")
                        .HasColumnType("TEXT");

                    b.Property<string>("StatementImage")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("StatementTypeId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("QuestionaireId");

                    b.HasIndex("StatementTypeId");

                    b.ToTable("StatementSets");
                });

            modelBuilder.Entity("MultipleChoiceTool.Infrastructure.Entities.StatementTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StatementTypes");
                });

            modelBuilder.Entity("MultipleChoiceTool.Infrastructure.Entities.QuestionaireLinkEntity", b =>
                {
                    b.HasOne("MultipleChoiceTool.Infrastructure.Entities.QuestionaireEntity", "Questionaire")
                        .WithMany("QuestionaireLinks")
                        .HasForeignKey("QuestionaireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Questionaire");
                });

            modelBuilder.Entity("MultipleChoiceTool.Infrastructure.Entities.StatementEntity", b =>
                {
                    b.HasOne("MultipleChoiceTool.Infrastructure.Entities.StatementSetEntity", "StatementSet")
                        .WithMany("Statements")
                        .HasForeignKey("StatementSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatementSet");
                });

            modelBuilder.Entity("MultipleChoiceTool.Infrastructure.Entities.StatementSetEntity", b =>
                {
                    b.HasOne("MultipleChoiceTool.Infrastructure.Entities.QuestionaireEntity", "Questionaire")
                        .WithMany("StatementSets")
                        .HasForeignKey("QuestionaireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultipleChoiceTool.Infrastructure.Entities.StatementTypeEntity", "StatementType")
                        .WithMany("StatementSets")
                        .HasForeignKey("StatementTypeId");

                    b.Navigation("Questionaire");

                    b.Navigation("StatementType");
                });

            modelBuilder.Entity("MultipleChoiceTool.Infrastructure.Entities.QuestionaireEntity", b =>
                {
                    b.Navigation("QuestionaireLinks");

                    b.Navigation("StatementSets");
                });

            modelBuilder.Entity("MultipleChoiceTool.Infrastructure.Entities.StatementSetEntity", b =>
                {
                    b.Navigation("Statements");
                });

            modelBuilder.Entity("MultipleChoiceTool.Infrastructure.Entities.StatementTypeEntity", b =>
                {
                    b.Navigation("StatementSets");
                });
#pragma warning restore 612, 618
        }
    }
}
