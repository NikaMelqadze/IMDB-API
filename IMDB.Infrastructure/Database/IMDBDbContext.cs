using IMDB.Core.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Infrastructure.Database
{
    public partial class IMDBDbContext : DbContext, IMDB.Core.Applications.Common.Interfaces.IApplicationDbContext
    {
        public IMDBDbContext()
        {
        }

        public IMDBDbContext(DbContextOptions<IMDBDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OfferHistory> OfferHistories { get; set; }
        public virtual DbSet<WatchList> WatchLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<WatchList>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(r => r.UserId).HasColumnType("int").IsRequired();
                entity.Property(r => r.Watched).HasColumnType("bit").IsRequired();
                entity.Property(r => r.FilmId).HasColumnType("nvarchar(50)").IsRequired();
                entity.Property(r => r.FilmTitle).HasColumnType("nvarchar(MAX)").IsRequired();
                entity.Property(r => r.FilmDescription).HasColumnType("nvarchar(MAX)").IsRequired();
                entity.Property(r => r.FilmRating).HasColumnType("decimal(27, 2)").IsRequired();
                entity.Property(r => r.FilmPoster).HasColumnType("nvarchar(500)");
                
                entity.HasMany(e => e.OfferHistories).WithOne(o => o.WatchList).HasForeignKey(x=>x.WatchListId);
                entity.ToTable("WatchLists", "dbo");
            });

            modelBuilder.Entity<OfferHistory>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(r => r.WatchListId).HasColumnType("int").IsRequired();
                entity.Property(r => r.OfferDate).HasColumnType("date)").IsRequired();
                //entity.HasOne(e => e.WatchList).WithMany(o => o.OfferHistories).HasForeignKey(e => e.WatchListId);

                entity.ToTable("OfferHistories", "dbo");
            });
       
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
