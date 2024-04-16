﻿// <auto-generated />
using System;
using BTH_BUOI1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTH_BUOI1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240416051130_AddInstall")]
    partial class AddInstall
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BTH_BUOI1.Models.Authors", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ID"));

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            FullName = "Paulo Coelho"
                        },
                        new
                        {
                            ID = 2,
                            FullName = "J.K. Rowling"
                        },
                        new
                        {
                            ID = 3,
                            FullName = "Jeff Kinney"
                        },
                        new
                        {
                            ID = 4,
                            FullName = "Harper Lee"
                        },
                        new
                        {
                            ID = 5,
                            FullName = "J.D. Salinger"
                        });
                });

            modelBuilder.Entity("BTH_BUOI1.Models.Book_Author", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ID"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("Book_Authors");
                });

            modelBuilder.Entity("BTH_BUOI1.Models.Domain.Books", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ID"));

                    b.Property<string>("CoverUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Genre")
                        .HasColumnType("int");

                    b.Property<bool?>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            ID = 201,
                            CoverUrl = "https://www.tailieuielts.com/wp-content/uploads/2022/01/The-Alchemist-676x1024.jpg",
                            DateAdded = new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRead = new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Alchemist is about a shepherd named Santiago who embarks on a journey to fulfill his dreams and find the true meaning of life.",
                            Genre = 1,
                            IsRead = false,
                            PublisherId = 101,
                            Rate = 5,
                            Title = "The Alchemist"
                        },
                        new
                        {
                            ID = 202,
                            CoverUrl = "https://www.tailieuielts.com/wp-content/uploads/2022/01/Harry-Potter.jpg",
                            DateAdded = new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRead = new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Harry Potter series follows the adventures of a young wizard at Hogwarts School of Witchcraft and Wizardry.",
                            Genre = 2,
                            IsRead = false,
                            PublisherId = 102,
                            Rate = 4,
                            Title = "Harry Potter"
                        },
                        new
                        {
                            ID = 203,
                            CoverUrl = "https://www.tailieuielts.com/wp-content/uploads/2022/01/diary-of-a-wimpy-kid.jpg",
                            DateAdded = new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRead = new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Diary of a Wimpy Kid series humorously documents the ups and downs of middle school life through the diary entries of protagonist Greg Heffley.",
                            Genre = 3,
                            IsRead = false,
                            PublisherId = 103,
                            Rate = 3,
                            Title = "Diary of a Wimpy Kid"
                        },
                        new
                        {
                            ID = 204,
                            CoverUrl = "https://www.tailieuielts.com/wp-content/uploads/2022/01/to-kill-a-mockingbird.jpg",
                            DateAdded = new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRead = new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "To Kill a Mockingbird is a classic novel that explores themes of racial injustice and moral growth through the eyes of young Scout Finch in the American South of the 1930s.",
                            Genre = 4,
                            IsRead = false,
                            PublisherId = 104,
                            Rate = 2,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            ID = 205,
                            CoverUrl = "https://www.tailieuielts.com/wp-content/uploads/2022/01/the-catcher-in-the-rye.jpg",
                            DateAdded = new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRead = new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Catcher in the Rye is a classic novel that explores teenage angst and rebellion against societal phoniness.",
                            Genre = 5,
                            IsRead = false,
                            PublisherId = 105,
                            Rate = 1,
                            Title = "The Catcher in the Rye"
                        });
                });

            modelBuilder.Entity("BTH_BUOI1.Models.Publishers", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            ID = 101,
                            Name = "HarperCollins"
                        },
                        new
                        {
                            ID = 102,
                            Name = "Bloomsbury (UK), Scholastic (US)"
                        },
                        new
                        {
                            ID = 103,
                            Name = "Amulet Books (US), Puffin Books (UK)"
                        },
                        new
                        {
                            ID = 104,
                            Name = "J.B. Lippincott & Co."
                        },
                        new
                        {
                            ID = 105,
                            Name = "Little, Brown and Company"
                        });
                });

            modelBuilder.Entity("BTH_BUOI1.Models.Book_Author", b =>
                {
                    b.HasOne("BTH_BUOI1.Models.Authors", "Author")
                        .WithMany("Book_Authors")
                        .HasForeignKey("AuthorId");

                    b.HasOne("BTH_BUOI1.Models.Domain.Books", "Book")
                        .WithMany("Book_Authors")
                        .HasForeignKey("BookId");

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BTH_BUOI1.Models.Domain.Books", b =>
                {
                    b.HasOne("BTH_BUOI1.Models.Publishers", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BTH_BUOI1.Models.Authors", b =>
                {
                    b.Navigation("Book_Authors");
                });

            modelBuilder.Entity("BTH_BUOI1.Models.Domain.Books", b =>
                {
                    b.Navigation("Book_Authors");
                });

            modelBuilder.Entity("BTH_BUOI1.Models.Publishers", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
