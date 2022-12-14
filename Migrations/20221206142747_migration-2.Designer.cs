// <auto-generated />
using System;
using LeBonCoin_Toulouse.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LeBonCoinToulouse.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20221206142747_migration-2")]
    partial class migration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LeBonCoin_Toulouse.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("add_date");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<bool>("StatusArticle")
                        .HasColumnType("bit")
                        .HasColumnName("statut_article");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("article");
                });

            modelBuilder.Entity("LeBonCoin_Toulouse.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("LeBonCoin_Toulouse.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArticleId")
                        .HasColumnType("int")
                        .HasColumnName("article_id");

                    b.Property<string>("StatusCom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status_com");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("text");

                    b.Property<int>("UserAppId")
                        .HasColumnType("int")
                        .HasColumnName("user_app_id");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserAppId");

                    b.ToTable("comment");
                });

            modelBuilder.Entity("LeBonCoin_Toulouse.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("int")
                        .HasColumnName("article_id");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("image");
                });

            modelBuilder.Entity("LeBonCoin_Toulouse.Models.RoleApp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("role_app");
                });

            modelBuilder.Entity("LeBonCoin_Toulouse.Models.UserApp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<int>("RoleAppId")
                        .HasColumnType("int")
                        .HasColumnName("role_app_id");

                    b.Property<bool>("StatusUser")
                        .HasColumnType("bit")
                        .HasColumnName("status_user");

                    b.HasKey("Id");

                    b.HasIndex("RoleAppId");

                    b.ToTable("user_app");
                });

            modelBuilder.Entity("LeBonCoin_Toulouse.Models.Article", b =>
                {
                    b.HasOne("LeBonCoin_Toulouse.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeBonCoin_Toulouse.Models.UserApp", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LeBonCoin_Toulouse.Models.Comment", b =>
                {
                    b.HasOne("LeBonCoin_Toulouse.Models.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId");

                    b.HasOne("LeBonCoin_Toulouse.Models.UserApp", "UserApp")
                        .WithMany()
                        .HasForeignKey("UserAppId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("UserApp");
                });

            modelBuilder.Entity("LeBonCoin_Toulouse.Models.Image", b =>
                {
                    b.HasOne("LeBonCoin_Toulouse.Models.Article", "Article")
                        .WithMany("Images")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("LeBonCoin_Toulouse.Models.UserApp", b =>
                {
                    b.HasOne("LeBonCoin_Toulouse.Models.RoleApp", "RoleApp")
                        .WithMany()
                        .HasForeignKey("RoleAppId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleApp");
                });

            modelBuilder.Entity("LeBonCoin_Toulouse.Models.Article", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
