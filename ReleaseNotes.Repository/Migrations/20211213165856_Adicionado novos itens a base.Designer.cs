﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ReleaseNotes.Repository.Context;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    [DbContext(typeof(NpgSqlContext))]
    [Migration("20211213165856_Adicionado novos itens a base")]
    partial class Adicionadonovositensabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerPDV.ModulePDV", b =>
                {
                    b.Property<long>("ModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ModuleId"));

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ReleaseId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ModuleId");

                    b.HasIndex("ReleaseId");

                    b.ToTable("ModulePDVs");

                    b.HasData(
                        new
                        {
                            ModuleId = 1L,
                            ModuleName = "Comercial",
                            Notes = "Criado novas funcionalidades",
                            ReleaseId = 1L,
                            Title = "Vendas por pedido"
                        },
                        new
                        {
                            ModuleId = 2L,
                            ModuleName = "Financeiro",
                            Notes = "Adicionado novos meios de pagamento",
                            ReleaseId = 1L,
                            Title = "Contas a pagar"
                        },
                        new
                        {
                            ModuleId = 3L,
                            ModuleName = "Integrações",
                            Notes = "Implementado",
                            ReleaseId = 1L,
                            Title = "Scanntech"
                        });
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerPDV.ReleasePDV", b =>
                {
                    b.Property<long>("ReleaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ReleaseId"));

                    b.Property<string>("VersionNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ReleaseId");

                    b.ToTable("ReleasePDVs");

                    b.HasData(
                        new
                        {
                            ReleaseId = 1L,
                            VersionNumber = "1.0"
                        });
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerServer.Module", b =>
                {
                    b.Property<long>("ModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ModuleId"));

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ReleaseId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ModuleId");

                    b.HasIndex("ReleaseId");

                    b.ToTable("Modules");

                    b.HasData(
                        new
                        {
                            ModuleId = 1L,
                            ModuleName = "Comercial",
                            Notes = "Criado novas funcionalidades",
                            ReleaseId = 1L,
                            Title = "Vendas por pedido"
                        },
                        new
                        {
                            ModuleId = 2L,
                            ModuleName = "Financeiro",
                            Notes = "Adicionado novos meios de pagamento",
                            ReleaseId = 1L,
                            Title = "Contas a pagar"
                        },
                        new
                        {
                            ModuleId = 3L,
                            ModuleName = "Integrações",
                            Notes = "Implementado",
                            ReleaseId = 1L,
                            Title = "Scanntech"
                        },
                        new
                        {
                            ModuleId = 4L,
                            ModuleName = "Fiscal",
                            Notes = "Correção na emissão",
                            ReleaseId = 2L,
                            Title = "NF Entrada"
                        },
                        new
                        {
                            ModuleId = 5L,
                            ModuleName = "Financeiro",
                            Notes = "Corrigido Bug",
                            ReleaseId = 2L,
                            Title = "Contas a receber"
                        });
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerServer.Release", b =>
                {
                    b.Property<long>("ReleaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ReleaseId"));

                    b.Property<string>("VersionNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ReleaseId");

                    b.ToTable("Releases");

                    b.HasData(
                        new
                        {
                            ReleaseId = 1L,
                            VersionNumber = "1.0"
                        },
                        new
                        {
                            ReleaseId = 2L,
                            VersionNumber = "2.0"
                        });
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerPDV.ModulePDV", b =>
                {
                    b.HasOne("ReleaseNotes.Entities.Model.ReleasesPowerPDV.ReleasePDV", "Release")
                        .WithMany("Modules")
                        .HasForeignKey("ReleaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Release");
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerServer.Module", b =>
                {
                    b.HasOne("ReleaseNotes.Entities.Model.ReleasesPowerServer.Release", "Release")
                        .WithMany("Modules")
                        .HasForeignKey("ReleaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Release");
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerPDV.ReleasePDV", b =>
                {
                    b.Navigation("Modules");
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerServer.Release", b =>
                {
                    b.Navigation("Modules");
                });
#pragma warning restore 612, 618
        }
    }
}
