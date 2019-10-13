﻿// <auto-generated />
using GameStoreData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameStoreData.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20191013053322_start")]
    partial class start
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameStoreModel.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Mario should kill Thanos at each level to advance to the next.",
                            Name = "Super Mario",
                            Rating = 4f
                        },
                        new
                        {
                            Id = 2,
                            Description = "Choose either to be a terrorist or a counter Terrorist and fight against the other group by choosing any arena.",
                            Name = "Counter Strike",
                            Rating = 5f
                        },
                        new
                        {
                            Id = 3,
                            Description = "Choose a team to play the amazing FIFA Football 2019.",
                            Name = "FIFA 19",
                            Rating = 5f
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
