using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.LibraryDbContext
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BaseCategory> BasicCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MembershipDetails> MembershipDetails { get; set; }
        public DbSet<BorrowDetails> BorrowDetails { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
    }
}
