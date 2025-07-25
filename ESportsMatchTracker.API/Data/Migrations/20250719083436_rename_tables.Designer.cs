﻿// <auto-generated />
using System;
using ESportsMatchTracker.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ESportsMatchTracker.API.Data.Migrations
{
    [DbContext(typeof(ESportsDbContext))]
    [Migration("20250719083436_rename_tables")]
    partial class rename_tables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrentMap")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("current_map");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("format");

                    b.Property<string>("Game")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("game");

                    b.Property<string>("MapPoolJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("map_pool_json");

                    b.Property<string>("MapScoresJson")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("map_scores_json");

                    b.Property<string>("ScoreJson")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("overall_score_json");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("stage");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("start_time");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status");

                    b.Property<string>("StreamUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("stream_url");

                    b.Property<string>("TeamsJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("teams_json");

                    b.Property<string>("Tournament")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tournament_name");

                    b.Property<string>("Winner")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("winner_team_name");

                    b.HasKey("Id");

                    b.ToTable("Match", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
