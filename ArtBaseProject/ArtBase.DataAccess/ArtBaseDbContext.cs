using ArtBase.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ArtBase.DataAccess
{
    public class ArtBaseDbContext : DbContext
    {
        static ArtBaseDbContext()
        {
            Database.SetInitializer<ArtBaseDbContext>(null);
        }
        public ArtBaseDbContext() : base("ArtBaseConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Claps> Claps { get; set; }
        public DbSet<Bookmark> Bookmark { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Views> Views { get; set; }
        public DbSet<User> AspNetUsers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Add<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Claps>().ToTable("Claps");
            modelBuilder.Entity<Bookmark>().ToTable("Bookmark");
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<Views>().ToTable("Views");
            modelBuilder.Entity<User>().ToTable("AspNetUsers");

            modelBuilder.Entity<Bookmark>()
                .HasMany<Tag>(b => b.Tags)
                .WithMany(t => t.Bookmarks)
                .Map(bt =>
                {
                    bt.MapLeftKey("Bookmark_Id");
                    bt.MapRightKey("Tag_Id");
                    bt.ToTable("Bookmarks_Tags");
                });

            modelBuilder.Entity<Bookmark>()
                .HasRequired<Category>(b => b.Category)
                .WithMany(c => c.Bookmark)
                .HasForeignKey<int>(b => b.Category_Id);

            modelBuilder.Entity<Bookmark>()
               .HasRequired<User>(b => b.User)
               .WithMany(u => u.Bookmark)
               .HasForeignKey<string>(b => b.User_Id);

            modelBuilder.Entity<Claps>()
                .HasRequired<Bookmark>(c => c.Bookmark)
                .WithMany(b => b.Claps)
                .HasForeignKey(c => c.Bookmark_Id);

            modelBuilder.Entity<Claps>()
                .HasRequired<User>(c => c.User)
                .WithMany(u => u.Claps)
                .HasForeignKey(c => c.User_Id);

            modelBuilder.Entity<Views>()
                .HasRequired<Bookmark>(v => v.Bookmark)
                .WithMany(b => b.Views)
                .HasForeignKey(v => v.Bookmark_Id);

            modelBuilder.Entity<Views>()
                .HasRequired<User>(v => v.User)
                .WithMany(u => u.Views)
                .HasForeignKey(v => v.User_Id);
        }
    }
}
