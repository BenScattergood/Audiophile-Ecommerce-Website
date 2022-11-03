﻿// <auto-generated />
using System;
using AudiophileEcommerceWebsite.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AudiophileEcommerceWebsite.Migrations
{
    [DbContext(typeof(AudiophileDbContext))]
    partial class AudiophileDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AccessoryProduct", b =>
                {
                    b.Property<int>("AccessoriesAccessoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.HasKey("AccessoriesAccessoryId", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("AccessoryProduct");
                });

            modelBuilder.Entity("AudiophileEcommerceWebsite.Entities.Accessory", b =>
                {
                    b.Property<int>("AccessoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccessoryId"), 1L, 1);

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("AccessoryId");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("AudiophileEcommerceWebsite.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AudiophileEcommerceWebsite.Entities.Gallery", b =>
                {
                    b.Property<int>("GalleryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GalleryId"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("GalleryId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Gallery");
                });

            modelBuilder.Entity("AudiophileEcommerceWebsite.Entities.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"), 1L, 1);

                    b.Property<int?>("CategoryProductId")
                        .HasColumnType("int");

                    b.Property<string>("Desktop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductImageId")
                        .HasColumnType("int");

                    b.Property<string>("Tablet")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageId");

                    b.HasIndex("CategoryProductId")
                        .IsUnique()
                        .HasFilter("[CategoryProductId] IS NOT NULL");

                    b.HasIndex("ProductImageId")
                        .IsUnique()
                        .HasFilter("[ProductImageId] IS NOT NULL");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("AudiophileEcommerceWebsite.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Features")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isNew")
                        .HasColumnType("bit");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AudiophileEcommerceWebsite.Entities.RelatedData", b =>
                {
                    b.Property<int>("RelatedDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RelatedDataId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RelatedDataId");

                    b.ToTable("RelatedData");
                });

            modelBuilder.Entity("GalleryImage", b =>
                {
                    b.Property<int>("FirstGalleriesGalleryId")
                        .HasColumnType("int");

                    b.Property<int>("FirstImageId")
                        .HasColumnType("int");

                    b.HasKey("FirstGalleriesGalleryId", "FirstImageId");

                    b.HasIndex("FirstImageId");

                    b.ToTable("GalleryFirstImage", (string)null);
                });

            modelBuilder.Entity("GalleryImage1", b =>
                {
                    b.Property<int>("SecondGalleriesGalleryId")
                        .HasColumnType("int");

                    b.Property<int>("SecondImageId")
                        .HasColumnType("int");

                    b.HasKey("SecondGalleriesGalleryId", "SecondImageId");

                    b.HasIndex("SecondImageId");

                    b.ToTable("GallerySecondImage", (string)null);
                });

            modelBuilder.Entity("GalleryImage2", b =>
                {
                    b.Property<int>("ThirdGalleriesGalleryId")
                        .HasColumnType("int");

                    b.Property<int>("ThirdImageId")
                        .HasColumnType("int");

                    b.HasKey("ThirdGalleriesGalleryId", "ThirdImageId");

                    b.HasIndex("ThirdImageId");

                    b.ToTable("GalleryThirdImage", (string)null);
                });

            modelBuilder.Entity("ImageRelatedData", b =>
                {
                    b.Property<int>("ImagesImageId")
                        .HasColumnType("int");

                    b.Property<int>("RelatedDataId")
                        .HasColumnType("int");

                    b.HasKey("ImagesImageId", "RelatedDataId");

                    b.HasIndex("RelatedDataId");

                    b.ToTable("ImageRelatedData");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProductRelatedData", b =>
                {
                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.Property<int>("RelatedDataId")
                        .HasColumnType("int");

                    b.HasKey("ProductsProductId", "RelatedDataId");

                    b.HasIndex("RelatedDataId");

                    b.ToTable("ProductRelatedData");
                });

            modelBuilder.Entity("AccessoryProduct", b =>
                {
                    b.HasOne("AudiophileEcommerceWebsite.Entities.Accessory", null)
                        .WithMany()
                        .HasForeignKey("AccessoriesAccessoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AudiophileEcommerceWebsite.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AudiophileEcommerceWebsite.Entities.Gallery", b =>
                {
                    b.HasOne("AudiophileEcommerceWebsite.Entities.Product", "Product")
                        .WithOne("Gallery")
                        .HasForeignKey("AudiophileEcommerceWebsite.Entities.Gallery", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AudiophileEcommerceWebsite.Entities.Image", b =>
                {
                    b.HasOne("AudiophileEcommerceWebsite.Entities.Product", "CategoryProduct")
                        .WithOne("CategoryImages")
                        .HasForeignKey("AudiophileEcommerceWebsite.Entities.Image", "CategoryProductId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("AudiophileEcommerceWebsite.Entities.Product", "Product")
                        .WithOne("Image")
                        .HasForeignKey("AudiophileEcommerceWebsite.Entities.Image", "ProductImageId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CategoryProduct");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AudiophileEcommerceWebsite.Entities.Product", b =>
                {
                    b.HasOne("AudiophileEcommerceWebsite.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GalleryImage", b =>
                {
                    b.HasOne("AudiophileEcommerceWebsite.Entities.Gallery", null)
                        .WithMany()
                        .HasForeignKey("FirstGalleriesGalleryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AudiophileEcommerceWebsite.Entities.Image", null)
                        .WithMany()
                        .HasForeignKey("FirstImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GalleryImage1", b =>
                {
                    b.HasOne("AudiophileEcommerceWebsite.Entities.Gallery", null)
                        .WithMany()
                        .HasForeignKey("SecondGalleriesGalleryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AudiophileEcommerceWebsite.Entities.Image", null)
                        .WithMany()
                        .HasForeignKey("SecondImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GalleryImage2", b =>
                {
                    b.HasOne("AudiophileEcommerceWebsite.Entities.Gallery", null)
                        .WithMany()
                        .HasForeignKey("ThirdGalleriesGalleryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AudiophileEcommerceWebsite.Entities.Image", null)
                        .WithMany()
                        .HasForeignKey("ThirdImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ImageRelatedData", b =>
                {
                    b.HasOne("AudiophileEcommerceWebsite.Entities.Image", null)
                        .WithMany()
                        .HasForeignKey("ImagesImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AudiophileEcommerceWebsite.Entities.RelatedData", null)
                        .WithMany()
                        .HasForeignKey("RelatedDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductRelatedData", b =>
                {
                    b.HasOne("AudiophileEcommerceWebsite.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AudiophileEcommerceWebsite.Entities.RelatedData", null)
                        .WithMany()
                        .HasForeignKey("RelatedDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AudiophileEcommerceWebsite.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("AudiophileEcommerceWebsite.Entities.Product", b =>
                {
                    b.Navigation("CategoryImages")
                        .IsRequired();

                    b.Navigation("Gallery");

                    b.Navigation("Image")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
