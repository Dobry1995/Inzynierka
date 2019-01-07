using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend.Models
{
    public partial class TotalizatorContext : DbContext
    {
        public TotalizatorContext()
        {
        }

        public TotalizatorContext(DbContextOptions<TotalizatorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dzokej> Dzokej { get; set; }
        public virtual DbSet<Gonitwa> Gonitwa { get; set; }
        public virtual DbSet<Gracz> Gracz { get; set; }
        public virtual DbSet<ListaStartowa> ListaStartowa { get; set; }
        public virtual DbSet<RodzajZakladu> RodzajZakladu { get; set; }
        public virtual DbSet<Szczegoly> Szczegoly { get; set; }
        public virtual DbSet<Wierzchowiec> Wierzchowiec { get; set; }
        public virtual DbSet<Zaklad> Zaklad { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-29E1B2H;Database=Totalizator;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dzokej>(entity =>
            {
                entity.HasKey(e => e.NrDzokej);

                entity.Property(e => e.NrDzokej).HasColumnName("Nr dzokej");

                entity.Property(e => e.Biografia).HasMaxLength(1000);

                entity.Property(e => e.Imie).HasMaxLength(40);

                entity.Property(e => e.Nazwisko).HasMaxLength(100);
            });

            modelBuilder.Entity<Gonitwa>(entity =>
            {
                entity.HasKey(e => e.NrGonitwyWSezonie);

                entity.Property(e => e.NrGonitwyWSezonie).HasColumnName("Nr gonitwy w sezonie");

                entity.Property(e => e.NrGonitwyWDniu).HasColumnName("Nr gonitwy w dniu");

                entity.Property(e => e.NrSzczegoly).HasColumnName("Nr szczegoly");

                entity.HasOne(d => d.NrSzczegolyNavigation)
                    .WithMany(p => p.Gonitwa)
                    .HasForeignKey(d => d.NrSzczegoly)
                    .HasConstraintName("fk_szczegoly");
            });

            modelBuilder.Entity<Gracz>(entity =>
            {
                entity.HasKey(e => e.IdGracza);

                entity.Property(e => e.IdGracza).HasColumnName("Id gracza");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(40);

                entity.Property(e => e.Imie).HasMaxLength(100);

                entity.Property(e => e.Login).HasMaxLength(100);

                entity.Property(e => e.Nazwisko).HasMaxLength(100);

                entity.Property(e => e.Rola)
                    .HasColumnName("rola")
                    .HasMaxLength(100);

                entity.Property(e => e.Wiek).HasColumnName("wiek");

                entity.Property(e => e.Wyksztalcenie)
                    .HasColumnName("wyksztalcenie")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ListaStartowa>(entity =>
            {
                entity.HasKey(e => new { e.NrGonitwyWSezonie, e.NrWierzchowca, e.NrDzokeja });

                entity.ToTable("Lista startowa");

                entity.Property(e => e.NrGonitwyWSezonie).HasColumnName("Nr gonitwy w sezonie");

                entity.Property(e => e.NrWierzchowca).HasColumnName("Nr wierzchowca");

                entity.Property(e => e.NrDzokeja).HasColumnName("Nr dzokeja");

                entity.Property(e => e.IdListy)
                    .HasColumnName("Id listy")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.NrDzokejaNavigation)
                    .WithMany(p => p.ListaStartowa)
                    .HasForeignKey(d => d.NrDzokeja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dzok");

                entity.HasOne(d => d.NrGonitwyWSezonieNavigation)
                    .WithMany(p => p.ListaStartowa)
                    .HasForeignKey(d => d.NrGonitwyWSezonie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_list");

                entity.HasOne(d => d.NrWierzchowcaNavigation)
                    .WithMany(p => p.ListaStartowa)
                    .HasForeignKey(d => d.NrWierzchowca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_wierzch");
            });

            modelBuilder.Entity<RodzajZakladu>(entity =>
            {
                entity.ToTable("Rodzaj zakladu");

                entity.Property(e => e.NazwaZakladu)
                    .HasColumnName("Nazwa zakladu")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Szczegoly>(entity =>
            {
                entity.HasKey(e => e.IdSzczegoly);

                entity.Property(e => e.IdSzczegoly).HasColumnName("Id szczegoly");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.GodzinaRozpoczecia).HasColumnName("Godzina rozpoczecia");

                entity.Property(e => e.NagrodaZaIMiejsce).HasColumnName("Nagroda za I miejsce");

                entity.Property(e => e.NagrodaZaIiMiejsce).HasColumnName("Nagroda za II miejsce");

                entity.Property(e => e.NagrodaZaIiiMiejsce).HasColumnName("Nagroda za III miejsce");

                entity.Property(e => e.NagrodaZaIvMiejsce).HasColumnName("Nagroda za IV miejsce");

                entity.Property(e => e.NagrodaZaVMiejsce).HasColumnName("Nagroda za V miejsce");

                entity.Property(e => e.NazwaNagrody)
                    .HasColumnName("Nazwa nagrody")
                    .HasMaxLength(500);

                entity.Property(e => e.WarunkiGonitwy)
                    .HasColumnName("Warunki gonitwy")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Wierzchowiec>(entity =>
            {
                entity.HasKey(e => e.NrWierzchowca);

                entity.Property(e => e.NrWierzchowca).HasColumnName("Nr wierzchowca");

                entity.Property(e => e.NazwaWierzchowca)
                    .HasColumnName("Nazwa wierzchowca")
                    .HasMaxLength(50);

                entity.Property(e => e.Plec).HasMaxLength(50);

                entity.Property(e => e.Rasa).HasMaxLength(50);

                entity.Property(e => e.Umaszczenie).HasMaxLength(50);

                entity.Property(e => e.Wlasciciel).HasMaxLength(100);

                entity.Property(e => e.ZnakiSzczegolne)
                    .HasColumnName("Znaki szczegolne")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Zaklad>(entity =>
            {
                entity.HasKey(e => e.IdZakladu);

                entity.Property(e => e.IdZakladu).HasColumnName("Id zakladu");

                entity.Property(e => e.IdGonitwy).HasColumnName("Id gonitwy");

                entity.Property(e => e.IdGracza).HasColumnName("Id gracza");

                entity.Property(e => e.RodzajZakladu).HasColumnName("Rodzaj zakladu");

                entity.HasOne(d => d.IdGonitwyNavigation)
                    .WithMany(p => p.Zaklad)
                    .HasForeignKey(d => d.IdGonitwy)
                    .HasConstraintName("fk_gonitwy");

                entity.HasOne(d => d.IdGraczaNavigation)
                    .WithMany(p => p.Zaklad)
                    .HasForeignKey(d => d.IdGracza)
                    .HasConstraintName("fk_gracz");

                entity.HasOne(d => d.RodzajZakladuNavigation)
                    .WithMany(p => p.Zaklad)
                    .HasForeignKey(d => d.RodzajZakladu)
                    .HasConstraintName("fk_rzakl");
            });
        }
    }
}
