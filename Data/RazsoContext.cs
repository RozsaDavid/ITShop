using ITShop.Model;
using Microsoft.EntityFrameworkCore;

namespace ITShop.Data;

public partial class RazsoContext :DbContext {
    public RazsoContext() {
    }

    public RazsoContext(DbContextOptions<RazsoContext> options)
        : base(options) {
    }

    public virtual DbSet<ItKategoriak> ItKategoriaks { get; set; }

    public virtual DbSet<ItTermekek> ItTermekeks { get; set; }

    public virtual DbSet<Naplo> Naplos { get; set; }

    public virtual DbSet<Rendele> Rendeles { get; set; }

    public virtual DbSet<RendelesTetelei> RendelesTeteleis { get; set; }

    public virtual DbSet<Userek> Usereks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=195.199.230.210;user=Razso;pwd=Razso;database=Razso");

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<ItKategoriak>(entity => {
            entity.HasKey(e => e.IdKategoria).HasName("PRIMARY");

            entity.ToTable("IT_kategoriak");

            entity.HasIndex(e => e.Kategoria, "KATEGORIA").IsUnique();

            entity.Property(e => e.IdKategoria)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID_KATEGORIA");
            entity.Property(e => e.Kategoria)
                .HasDefaultValueSql("''''''")
                .HasColumnName("KATEGORIA");
        });

        modelBuilder.Entity<ItTermekek>(entity => {
            entity.HasKey(e => e.IdTermek).HasName("PRIMARY");

            entity.ToTable("IT_termekek");

            entity.HasIndex(e => e.IdKategoria, "IT_kategoria_termek");

            entity.HasIndex(e => e.Leiras, "LEIRAS");

            entity.Property(e => e.IdTermek)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID_TERMEK");
            entity.Property(e => e.Aktiv)
                .HasDefaultValueSql("'''Y'''")
                .HasComment("forgalmazott termék?")
                .HasColumnType("enum('N','Y')")
                .HasColumnName("AKTIV");
            entity.Property(e => e.Ar)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("AR");
            entity.Property(e => e.Azon)
                .HasMaxLength(45)
                .HasDefaultValueSql("''''''")
                .HasColumnName("AZON");
            entity.Property(e => e.Datumido)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp")
                .HasColumnName("DATUMIDO");
            entity.Property(e => e.Fotolink)
                .HasMaxLength(255)
                .HasDefaultValueSql("''''''")
                .HasColumnName("FOTOLINK");
            entity.Property(e => e.IdKategoria)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID_KATEGORIA");
            entity.Property(e => e.Leiras)
                .HasDefaultValueSql("'NULL'")
                .HasComment("Megjegyzés")
                .HasColumnType("text")
                .HasColumnName("LEIRAS");
            entity.Property(e => e.Meegys)
                .HasMaxLength(45)
                .HasDefaultValueSql("'''db'''")
                .HasColumnName("MEEGYS");
            entity.Property(e => e.Mennyiseg)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("MENNYISEG");
            entity.Property(e => e.Nev)
                .HasMaxLength(255)
                .HasDefaultValueSql("''''''")
                .HasColumnName("NEV");
            entity.Property(e => e.Termeklink)
                .HasMaxLength(255)
                .HasDefaultValueSql("''''''")
                .HasColumnName("TERMEKLINK");

            entity.HasOne(d => d.IdKategoriaNavigation).WithMany(p => p.ItTermekeks)
                .HasForeignKey(d => d.IdKategoria)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("IT_kategoria_termek");
        });

        modelBuilder.Entity<Naplo>(entity => {
            entity.HasKey(e => e.IdNaplo).HasName("PRIMARY");

            entity.ToTable("naplo");

            entity.Property(e => e.IdNaplo)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("ID_NAPLO");
            entity.Property(e => e.Datumido)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp")
                .HasColumnName("DATUMIDO");
            entity.Property(e => e.Sqlx)
                .HasMaxLength(1024)
                .HasDefaultValueSql("''''''")
                .HasColumnName("SQLX");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .HasDefaultValueSql("''''''")
                .HasColumnName("URL");
            entity.Property(e => e.User)
                .HasMaxLength(100)
                .HasDefaultValueSql("''''''")
                .HasColumnName("USER");
        });

        modelBuilder.Entity<Rendele>(entity => {
            entity.HasKey(e => e.IdRendeles).HasName("PRIMARY");

            entity.ToTable("rendeles");

            entity.HasIndex(e => e.Idsession, "IDSESSION");

            entity.HasIndex(e => e.IdUser, "ID_USER");

            entity.Property(e => e.IdRendeles)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("ID_RENDELES");
            entity.Property(e => e.Allapot)
                .HasDefaultValueSql("'''folyamatban'''")
                .HasColumnType("enum('folyamatban','lezárva','várakozik')")
                .HasColumnName("ALLAPOT");
            entity.Property(e => e.Datumido)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp")
                .HasColumnName("DATUMIDO");
            entity.Property(e => e.Fizmod)
                .HasDefaultValueSql("'''készpénz'''")
                .HasColumnType("enum('készpénz','átutalás','csekk')")
                .HasColumnName("FIZMOD");
            entity.Property(e => e.IdUser)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("ID_USER");
            entity.Property(e => e.Idsession)
                .HasMaxLength(100)
                .HasDefaultValueSql("''''''")
                .HasColumnName("IDSESSION");
            entity.Property(e => e.Megjegyzes)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("MEGJEGYZES");
            entity.Property(e => e.Szallmod)
                .HasMaxLength(100)
                .HasDefaultValueSql("'''posta'''")
                .HasColumnName("SZALLMOD");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Rendeles)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("u_r");
        });

        modelBuilder.Entity<RendelesTetelei>(entity => {
            entity.HasKey(e => e.IdRendtetel).HasName("PRIMARY");

            entity.ToTable("rendeles_tetelei");

            entity.HasIndex(e => e.IdRendeles, "ID_RENDELES");

            entity.HasIndex(e => new { e.IdRendeles, e.IdTermek }, "ID_RENDELES_2").IsUnique();

            entity.HasIndex(e => e.IdTermek, "ID_TERMEK");

            entity.Property(e => e.IdRendtetel)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("ID_RENDTETEL");
            entity.Property(e => e.Ar)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("AR");
            entity.Property(e => e.IdRendeles)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("ID_RENDELES");
            entity.Property(e => e.IdTermek)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("ID_TERMEK");
            entity.Property(e => e.Mennyiseg)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)")
                .HasColumnName("MENNYISEG");

            entity.HasOne(d => d.IdRendelesNavigation).WithMany(p => p.RendelesTeteleis)
                .HasForeignKey(d => d.IdRendeles)
                .HasConstraintName("kt_k");

            entity.HasOne(d => d.IdTermekNavigation).WithMany(p => p.RendelesTeteleis)
                .HasForeignKey(d => d.IdTermek)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("kt_t");
        });

        modelBuilder.Entity<Userek>(entity => {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("userek");

            entity.HasIndex(e => e.Email, "EMAIL").IsUnique();

            entity.Property(e => e.IdUser)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("ID_USER");
            entity.Property(e => e.Cim)
                .HasMaxLength(100)
                .HasDefaultValueSql("''''''")
                .HasColumnName("CIM");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasDefaultValueSql("''''''")
                .HasColumnName("EMAIL");
            entity.Property(e => e.Funkcio)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("FUNKCIO");
            entity.Property(e => e.Nev)
                .HasMaxLength(100)
                .HasDefaultValueSql("''''''")
                .HasColumnName("NEV");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasDefaultValueSql("''''''")
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Telefon)
                .HasMaxLength(100)
                .HasDefaultValueSql("''''''")
                .HasColumnName("TELEFON");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
