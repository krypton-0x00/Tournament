﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tournament.Data;

#nullable disable

namespace Tournament.Data.Migrations
{
    [DbContext(typeof(TournamentDbContext))]
    partial class TournamentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tournament.Core.Entities.PlayersEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<string>("GameId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Tournament.Core.Entities.PrizeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PrizeAmount")
                        .HasColumnType("int");

                    b.Property<Guid?>("TournamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TournamentId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("postion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.HasIndex("TournamentId1");

                    b.ToTable("Prizes");
                });

            modelBuilder.Entity("Tournament.Core.Entities.TeamEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TournamentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Tournament.Core.Entities.TournamentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BannerLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationCloseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RegistrationFee")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationOpenDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalPrize")
                        .HasColumnType("int");

                    b.Property<int>("current_teams_count")
                        .HasColumnType("int");

                    b.Property<int>("max_teams")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("visibility")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("Tournament.Core.Entities.PlayersEntity", b =>
                {
                    b.HasOne("Tournament.Core.Entities.TeamEntity", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Tournament.Core.Entities.PrizeEntity", b =>
                {
                    b.HasOne("Tournament.Core.Entities.TournamentEntity", null)
                        .WithMany("PrizePools")
                        .HasForeignKey("TournamentId");

                    b.HasOne("Tournament.Core.Entities.TournamentEntity", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentId1");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Tournament.Core.Entities.TeamEntity", b =>
                {
                    b.HasOne("Tournament.Core.Entities.TournamentEntity", "Tournament")
                        .WithMany("Teams")
                        .HasForeignKey("TournamentId");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Tournament.Core.Entities.TeamEntity", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("Tournament.Core.Entities.TournamentEntity", b =>
                {
                    b.Navigation("PrizePools");

                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
