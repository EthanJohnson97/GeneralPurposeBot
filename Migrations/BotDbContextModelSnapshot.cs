﻿// <auto-generated />
using GeneralPurposeBot.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GeneralPurposeBot.Migrations
{
    [DbContext(typeof(BotDbContext))]
    partial class BotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GeneralPurposeBot.Models.ServerProperties", b =>
                {
                    b.Property<ulong>("ServerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("LogChannelId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("NsfwRoleId")
                        .HasColumnType("bigint unsigned");

                    b.Property<bool>("SimpleTempVc")
                        .HasColumnType("tinyint(1)");

                    b.Property<ulong>("SpamRoleId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("TempVoiceCategoryId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("TempVoiceCreateChannelId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("ServerId");

                    b.ToTable("ServerProperties");
                });
#pragma warning restore 612, 618
        }
    }
}
