﻿// <auto-generated />
using System;
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
    [Migration("20220104131731_Remove fields from email sender")]
    partial class Removefieldsfromemailsender
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.Calls.Call", b =>
                {
                    b.Property<long>("CallId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("CallId"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("FeedbackId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsUrgent")
                        .HasColumnType("boolean");

                    b.Property<int>("PriorityDegree")
                        .HasColumnType("integer");

                    b.Property<int>("Software")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CallId");

                    b.HasIndex("FeedbackId");

                    b.ToTable("Calls");

                    b.HasData(
                        new
                        {
                            CallId = 1L,
                            Date = "terça-feira, 4 de janeiro de 2022",
                            Detail = "Isso é um teste",
                            Email = "desenvolvimento04@supercontrole.com",
                            IsUrgent = true,
                            PriorityDegree = 1,
                            Software = 1,
                            Status = 2,
                            Subject = "TESTE",
                            UserName = "David Paulino"
                        });
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.Email.Receiver", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("ReceiverId")
                        .HasColumnType("bigint");

                    b.Property<long>("SenderEmailConfigId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderEmailConfigId");

                    b.ToTable("Receivers");
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.Email.Sender", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("SenderEmailConfigId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SenderEmailConfigId");

                    b.ToTable("Senders");
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.Email.SenderEmailConfig", b =>
                {
                    b.Property<long>("SenderConfigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("SenderConfigId"));

                    b.Property<long>("ReceiverId")
                        .HasColumnType("bigint");

                    b.Property<long>("SenderId")
                        .HasColumnType("bigint");

                    b.HasKey("SenderConfigId");

                    b.HasIndex("SenderId");

                    b.ToTable("SenderEmailConfig");
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.Feedback.ReleasesFeedback", b =>
                {
                    b.Property<long>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("FeedbackId"));

                    b.Property<long?>("CallId")
                        .HasColumnType("bigint");

                    b.Property<string>("Details")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FeedbackDate")
                        .HasColumnType("text");

                    b.Property<int>("FeedbackFrom")
                        .HasColumnType("integer");

                    b.Property<bool>("FeedbackPositive")
                        .HasColumnType("boolean");

                    b.Property<long?>("ModulePdvId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ModulePowerServerId")
                        .HasColumnType("bigint");

                    b.Property<bool>("OpenCall")
                        .HasColumnType("boolean");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("FeedbackId");

                    b.HasIndex("CallId");

                    b.HasIndex("ModulePdvId");

                    b.HasIndex("ModulePowerServerId");

                    b.ToTable("Feedbacks");
                });

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

                    b.Property<string>("VersionDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VersionNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ReleaseId");

                    b.ToTable("ReleasePDVs");

                    b.HasData(
                        new
                        {
                            ReleaseId = 1L,
                            VersionDate = "04/01/2022",
                            VersionNumber = "1.0"
                        });
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerServer.ModulePowerServer", b =>
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

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerServer.ReleasePowerServer", b =>
                {
                    b.Property<long>("ReleaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ReleaseId"));

                    b.Property<string>("VersionDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VersionNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ReleaseId");

                    b.ToTable("Releases");

                    b.HasData(
                        new
                        {
                            ReleaseId = 1L,
                            VersionDate = "04/01/2022",
                            VersionNumber = "1.0"
                        },
                        new
                        {
                            ReleaseId = 2L,
                            VersionDate = "04/01/2022",
                            VersionNumber = "2.0"
                        });
                });

            modelBuilder.Entity("ReleaseNotes.Repository.Context.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("FirstAccess")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ReleaseNotes.Repository.Context.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ReleaseNotes.Repository.Context.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReleaseNotes.Repository.Context.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ReleaseNotes.Repository.Context.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.Calls.Call", b =>
                {
                    b.HasOne("ReleaseNotes.Entities.Model.Feedback.ReleasesFeedback", "Feedback")
                        .WithMany()
                        .HasForeignKey("FeedbackId");

                    b.Navigation("Feedback");
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.Email.Receiver", b =>
                {
                    b.HasOne("ReleaseNotes.Entities.Model.Email.SenderEmailConfig", null)
                        .WithMany("Receivers")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("ReleaseNotes.Entities.Model.Email.SenderEmailConfig", "SenderEmailConfig")
                        .WithMany()
                        .HasForeignKey("SenderEmailConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SenderEmailConfig");
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.Email.Sender", b =>
                {
                    b.HasOne("ReleaseNotes.Entities.Model.Email.SenderEmailConfig", "SenderEmailConfig")
                        .WithMany()
                        .HasForeignKey("SenderEmailConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SenderEmailConfig");
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.Email.SenderEmailConfig", b =>
                {
                    b.HasOne("ReleaseNotes.Entities.Model.Email.Sender", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.Feedback.ReleasesFeedback", b =>
                {
                    b.HasOne("ReleaseNotes.Entities.Model.Calls.Call", "Call")
                        .WithMany()
                        .HasForeignKey("CallId");

                    b.HasOne("ReleaseNotes.Entities.Model.ReleasesPowerPDV.ModulePDV", "ModulePDV")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ModulePdvId");

                    b.HasOne("ReleaseNotes.Entities.Model.ReleasesPowerServer.ModulePowerServer", "ModulePowerServer")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ModulePowerServerId");

                    b.Navigation("Call");

                    b.Navigation("ModulePDV");

                    b.Navigation("ModulePowerServer");
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

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerServer.ModulePowerServer", b =>
                {
                    b.HasOne("ReleaseNotes.Entities.Model.ReleasesPowerServer.ReleasePowerServer", "Release")
                        .WithMany("Modules")
                        .HasForeignKey("ReleaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Release");
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.Email.SenderEmailConfig", b =>
                {
                    b.Navigation("Receivers");
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerPDV.ModulePDV", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerPDV.ReleasePDV", b =>
                {
                    b.Navigation("Modules");
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerServer.ModulePowerServer", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("ReleaseNotes.Entities.Model.ReleasesPowerServer.ReleasePowerServer", b =>
                {
                    b.Navigation("Modules");
                });
#pragma warning restore 612, 618
        }
    }
}
