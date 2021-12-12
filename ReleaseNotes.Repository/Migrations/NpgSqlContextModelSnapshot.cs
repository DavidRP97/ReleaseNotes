﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ReleaseNotes.Repository.Context;

#nullable disable

namespace ReleaseNotes.Repository.Migrations
{
    [DbContext(typeof(NpgSqlContext))]
    partial class NpgSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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
                        });
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

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerServer.Release", b =>
                {
                    b.Navigation("Modules");
                });
#pragma warning restore 612, 618
        }
    }
}
