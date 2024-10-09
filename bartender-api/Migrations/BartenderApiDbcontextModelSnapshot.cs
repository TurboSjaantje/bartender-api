﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bartender_api.Data;

#nullable disable

namespace bartender_api.Migrations
{
    [DbContext(typeof(BartenderApiDbcontext))]
    partial class BartenderApiDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("bartender_api.Models.Configuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Drink1Id")
                        .HasColumnType("int");

                    b.Property<int>("Drink2Id")
                        .HasColumnType("int");

                    b.Property<int>("Drink3Id")
                        .HasColumnType("int");

                    b.Property<int>("Drink4Id")
                        .HasColumnType("int");

                    b.Property<int>("Drink5Id")
                        .HasColumnType("int");

                    b.Property<int>("Drink6Id")
                        .HasColumnType("int");

                    b.Property<bool>("makingDrink")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Drink1Id");

                    b.HasIndex("Drink2Id");

                    b.HasIndex("Drink3Id");

                    b.HasIndex("Drink4Id");

                    b.HasIndex("Drink5Id");

                    b.HasIndex("Drink6Id");

                    b.ToTable("Configuration");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Drink1Id = 1,
                            Drink2Id = 2,
                            Drink3Id = 3,
                            Drink4Id = 4,
                            Drink5Id = 5,
                            Drink6Id = 6,
                            makingDrink = false
                        });
                });

            modelBuilder.Entity("bartender_api.Models.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Volume")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Drinks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Appelsap",
                            Volume = 250f
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sprite / 7Up",
                            Volume = 200f
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sinaasappelsap",
                            Volume = 250f
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cola",
                            Volume = 330f
                        },
                        new
                        {
                            Id = 5,
                            Name = "Fanta",
                            Volume = 250f
                        },
                        new
                        {
                            Id = 6,
                            Name = "Bruisend water",
                            Volume = 500f
                        },
                        new
                        {
                            Id = 7,
                            Name = "Ice tea perzik",
                            Volume = 330f
                        },
                        new
                        {
                            Id = 8,
                            Name = "Ginger ale",
                            Volume = 200f
                        });
                });

            modelBuilder.Entity("bartender_api.Models.DrinkWithPercentage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DrinkId")
                        .HasColumnType("int");

                    b.Property<int>("MocktailCombinationId")
                        .HasColumnType("int");

                    b.Property<float>("Percentage")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("DrinkId");

                    b.HasIndex("MocktailCombinationId");

                    b.ToTable("DrinkWithPercentages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DrinkId = 1,
                            MocktailCombinationId = 1,
                            Percentage = 60f
                        },
                        new
                        {
                            Id = 2,
                            DrinkId = 2,
                            MocktailCombinationId = 1,
                            Percentage = 40f
                        },
                        new
                        {
                            Id = 3,
                            DrinkId = 3,
                            MocktailCombinationId = 2,
                            Percentage = 50f
                        },
                        new
                        {
                            Id = 4,
                            DrinkId = 4,
                            MocktailCombinationId = 2,
                            Percentage = 50f
                        },
                        new
                        {
                            Id = 5,
                            DrinkId = 5,
                            MocktailCombinationId = 3,
                            Percentage = 70f
                        },
                        new
                        {
                            Id = 6,
                            DrinkId = 6,
                            MocktailCombinationId = 3,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 7,
                            DrinkId = 7,
                            MocktailCombinationId = 4,
                            Percentage = 60f
                        },
                        new
                        {
                            Id = 8,
                            DrinkId = 8,
                            MocktailCombinationId = 4,
                            Percentage = 40f
                        },
                        new
                        {
                            Id = 9,
                            DrinkId = 1,
                            MocktailCombinationId = 5,
                            Percentage = 50f
                        },
                        new
                        {
                            Id = 10,
                            DrinkId = 6,
                            MocktailCombinationId = 5,
                            Percentage = 50f
                        },
                        new
                        {
                            Id = 11,
                            DrinkId = 5,
                            MocktailCombinationId = 6,
                            Percentage = 40f
                        },
                        new
                        {
                            Id = 12,
                            DrinkId = 1,
                            MocktailCombinationId = 6,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 13,
                            DrinkId = 2,
                            MocktailCombinationId = 6,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 14,
                            DrinkId = 3,
                            MocktailCombinationId = 7,
                            Percentage = 40f
                        },
                        new
                        {
                            Id = 15,
                            DrinkId = 8,
                            MocktailCombinationId = 7,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 16,
                            DrinkId = 6,
                            MocktailCombinationId = 7,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 17,
                            DrinkId = 7,
                            MocktailCombinationId = 8,
                            Percentage = 40f
                        },
                        new
                        {
                            Id = 18,
                            DrinkId = 4,
                            MocktailCombinationId = 8,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 19,
                            DrinkId = 2,
                            MocktailCombinationId = 8,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 20,
                            DrinkId = 1,
                            MocktailCombinationId = 9,
                            Percentage = 40f
                        },
                        new
                        {
                            Id = 21,
                            DrinkId = 3,
                            MocktailCombinationId = 9,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 22,
                            DrinkId = 8,
                            MocktailCombinationId = 9,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 23,
                            DrinkId = 4,
                            MocktailCombinationId = 10,
                            Percentage = 50f
                        },
                        new
                        {
                            Id = 24,
                            DrinkId = 5,
                            MocktailCombinationId = 10,
                            Percentage = 50f
                        },
                        new
                        {
                            Id = 25,
                            DrinkId = 6,
                            MocktailCombinationId = 10,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 26,
                            DrinkId = 3,
                            MocktailCombinationId = 11,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 27,
                            DrinkId = 1,
                            MocktailCombinationId = 11,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 28,
                            DrinkId = 7,
                            MocktailCombinationId = 11,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 29,
                            DrinkId = 2,
                            MocktailCombinationId = 11,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 30,
                            DrinkId = 2,
                            MocktailCombinationId = 12,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 31,
                            DrinkId = 8,
                            MocktailCombinationId = 12,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 32,
                            DrinkId = 5,
                            MocktailCombinationId = 12,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 33,
                            DrinkId = 6,
                            MocktailCombinationId = 12,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 34,
                            DrinkId = 1,
                            MocktailCombinationId = 13,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 35,
                            DrinkId = 5,
                            MocktailCombinationId = 13,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 36,
                            DrinkId = 4,
                            MocktailCombinationId = 13,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 37,
                            DrinkId = 6,
                            MocktailCombinationId = 13,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 38,
                            DrinkId = 8,
                            MocktailCombinationId = 14,
                            Percentage = 40f
                        },
                        new
                        {
                            Id = 39,
                            DrinkId = 7,
                            MocktailCombinationId = 14,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 40,
                            DrinkId = 1,
                            MocktailCombinationId = 14,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 41,
                            DrinkId = 2,
                            MocktailCombinationId = 14,
                            Percentage = 10f
                        },
                        new
                        {
                            Id = 42,
                            DrinkId = 5,
                            MocktailCombinationId = 15,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 43,
                            DrinkId = 7,
                            MocktailCombinationId = 15,
                            Percentage = 30f
                        },
                        new
                        {
                            Id = 44,
                            DrinkId = 4,
                            MocktailCombinationId = 15,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 45,
                            DrinkId = 6,
                            MocktailCombinationId = 15,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 46,
                            DrinkId = 2,
                            MocktailCombinationId = 16,
                            Percentage = 25f
                        },
                        new
                        {
                            Id = 47,
                            DrinkId = 1,
                            MocktailCombinationId = 16,
                            Percentage = 25f
                        },
                        new
                        {
                            Id = 48,
                            DrinkId = 5,
                            MocktailCombinationId = 16,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 49,
                            DrinkId = 8,
                            MocktailCombinationId = 16,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 50,
                            DrinkId = 6,
                            MocktailCombinationId = 16,
                            Percentage = 10f
                        },
                        new
                        {
                            Id = 51,
                            DrinkId = 3,
                            MocktailCombinationId = 17,
                            Percentage = 25f
                        },
                        new
                        {
                            Id = 52,
                            DrinkId = 1,
                            MocktailCombinationId = 17,
                            Percentage = 25f
                        },
                        new
                        {
                            Id = 53,
                            DrinkId = 7,
                            MocktailCombinationId = 17,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 54,
                            DrinkId = 4,
                            MocktailCombinationId = 17,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 55,
                            DrinkId = 8,
                            MocktailCombinationId = 17,
                            Percentage = 10f
                        },
                        new
                        {
                            Id = 56,
                            DrinkId = 5,
                            MocktailCombinationId = 18,
                            Percentage = 25f
                        },
                        new
                        {
                            Id = 57,
                            DrinkId = 2,
                            MocktailCombinationId = 18,
                            Percentage = 25f
                        },
                        new
                        {
                            Id = 58,
                            DrinkId = 7,
                            MocktailCombinationId = 18,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 59,
                            DrinkId = 1,
                            MocktailCombinationId = 18,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 60,
                            DrinkId = 6,
                            MocktailCombinationId = 18,
                            Percentage = 10f
                        },
                        new
                        {
                            Id = 61,
                            DrinkId = 2,
                            MocktailCombinationId = 19,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 62,
                            DrinkId = 5,
                            MocktailCombinationId = 19,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 63,
                            DrinkId = 4,
                            MocktailCombinationId = 19,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 64,
                            DrinkId = 1,
                            MocktailCombinationId = 19,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 65,
                            DrinkId = 8,
                            MocktailCombinationId = 19,
                            Percentage = 10f
                        },
                        new
                        {
                            Id = 66,
                            DrinkId = 7,
                            MocktailCombinationId = 19,
                            Percentage = 10f
                        },
                        new
                        {
                            Id = 67,
                            DrinkId = 3,
                            MocktailCombinationId = 20,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 68,
                            DrinkId = 1,
                            MocktailCombinationId = 20,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 69,
                            DrinkId = 2,
                            MocktailCombinationId = 20,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 70,
                            DrinkId = 5,
                            MocktailCombinationId = 20,
                            Percentage = 20f
                        },
                        new
                        {
                            Id = 71,
                            DrinkId = 8,
                            MocktailCombinationId = 20,
                            Percentage = 10f
                        },
                        new
                        {
                            Id = 72,
                            DrinkId = 6,
                            MocktailCombinationId = 20,
                            Percentage = 10f
                        });
                });

            modelBuilder.Entity("bartender_api.Models.MocktailCombination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MocktailCombinations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Crisp Fizz"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Citrus Cola"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fruity Splash"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Peach Fizz"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Apple Fizz"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Tropical Fizz"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Citrus Delight"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Refreshing Berry"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Apple Citrus Sparkle"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Cola Fanta Mix"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Citrus Berry Splash"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Sparkling Citrus Punch"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Apple Fanta Delight"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Fruity Ginger Mix"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Tropical Twist"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Crisp Refreshment"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Citrus Punch"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Fruity Delight"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Sparkling Fruit Medley"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Citrus Melange"
                        });
                });

            modelBuilder.Entity("bartender_api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("bartender_api.Models.Configuration", b =>
                {
                    b.HasOne("bartender_api.Models.Drink", "Drink1")
                        .WithMany()
                        .HasForeignKey("Drink1Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("bartender_api.Models.Drink", "Drink2")
                        .WithMany()
                        .HasForeignKey("Drink2Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("bartender_api.Models.Drink", "Drink3")
                        .WithMany()
                        .HasForeignKey("Drink3Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("bartender_api.Models.Drink", "Drink4")
                        .WithMany()
                        .HasForeignKey("Drink4Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("bartender_api.Models.Drink", "Drink5")
                        .WithMany()
                        .HasForeignKey("Drink5Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("bartender_api.Models.Drink", "Drink6")
                        .WithMany()
                        .HasForeignKey("Drink6Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Drink1");

                    b.Navigation("Drink2");

                    b.Navigation("Drink3");

                    b.Navigation("Drink4");

                    b.Navigation("Drink5");

                    b.Navigation("Drink6");
                });

            modelBuilder.Entity("bartender_api.Models.DrinkWithPercentage", b =>
                {
                    b.HasOne("bartender_api.Models.Drink", "Drink")
                        .WithMany()
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bartender_api.Models.MocktailCombination", "MocktailCombination")
                        .WithMany("Drinks")
                        .HasForeignKey("MocktailCombinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("MocktailCombination");
                });

            modelBuilder.Entity("bartender_api.Models.MocktailCombination", b =>
                {
                    b.Navigation("Drinks");
                });
#pragma warning restore 612, 618
        }
    }
}
