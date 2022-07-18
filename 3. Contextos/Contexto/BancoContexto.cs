using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Contexto
{
    public class BancoContexto : DbContext
    {
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<CuentaEntity> Cuentas { get; set; }
        public DbSet<TarjetaEntity> Tarjetas { get; set; }
        public DbSet<MovimientoEntity> Movimientos { get; set; }
        public DbSet<AuthEntity> Auths { get; set; }
        /*protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                //options.UseSqlServer("Server=PF364CTJ; Database=BancoRappi;User Id=sa; Password=1234Dipe");
                options.UseSqlServer("Server=tcp:arquitecturaorientadaalservicio.database.windows.net,1433;Initial Catalog=BD;Persist Security Info=False;User ID=arquitecturaorientadaalservicio;Password=1234Dipe##;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }*/
        public BancoContexto(DbContextOptions<BancoContexto> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioEntity>(usuario =>
            {
                usuario.ToTable("usuario");
                usuario.HasKey(p => p.UsuarioId);
                usuario.Property(p => p.Nombres).IsRequired().HasMaxLength(150);
                usuario.Property(p => p.Apellidos).IsRequired().HasMaxLength(150);
                usuario.Property(p => p.Edad).IsRequired();
                usuario.Property(p => p.ContraseñaWeb).IsRequired().HasMaxLength(150);
                usuario.HasMany(p => p.Cuentas).WithOne(p => p.Usuario).HasForeignKey(p => p.UsuarioId);
            });
            modelBuilder.Entity<CuentaEntity>(cuenta =>
            {
                cuenta.ToTable("cuenta");
                cuenta.HasKey(p => p.CuentaId);
                cuenta.HasOne(p => p.Usuario).WithMany(p => p.Cuentas).HasForeignKey(p => p.UsuarioId);
                cuenta.Property(p => p.NumeroCuenta).IsRequired().HasMaxLength(25);
                cuenta.Property(p => p.MonedaCuenta).IsRequired().HasMaxLength(150);
                cuenta.Property(p => p.TipoCuenta).IsRequired();
                cuenta.Property(p => p.Linea);
                cuenta.Property(p => p.Saldo);
            });
            modelBuilder.Entity<TarjetaEntity>(tarjeta =>
            {
                tarjeta.ToTable("tarjeta");
                tarjeta.HasKey(p => p.TarjetaId);
                tarjeta.HasOne(p => p.Cuenta).WithOne(p => p.Tarjeta);
                tarjeta.HasOne(p => p.Usuario).WithMany(p => p.Tarjetas).HasForeignKey(p => p.UsuarioId).OnDelete(DeleteBehavior.Restrict);
                tarjeta.Property(p => p.NumeroTarjeta).IsRequired().HasMaxLength(25);
                tarjeta.Property(p => p.Mes).IsRequired();
                tarjeta.Property(p => p.Año).IsRequired();
                tarjeta.Property(p => p.CVV).IsRequired().HasMaxLength(4);
                tarjeta.Property(p => p.PIN).IsRequired().HasMaxLength(4);
            });
            modelBuilder.Entity<MovimientoEntity>(movimiento =>
            {
                movimiento.ToTable("movimiento");
                movimiento.HasKey(p => p.MovimientoId);
                movimiento.HasOne(p => p.Cuenta).WithMany(p => p.Movimientos).HasForeignKey(p => p.CuentaId).OnDelete(DeleteBehavior.Restrict);
                movimiento.Property(p => p.Monto).IsRequired().HasMaxLength(150);
                movimiento.Property(p => p.Origen).IsRequired();
            });
            modelBuilder.Entity<AuthEntity>(auth =>
            {
                auth.ToTable("auth");
                auth.HasKey(p => p.AuthId);
                auth.Property(p => p.Usuario).IsRequired().HasMaxLength(150);
                auth.Property(p => p.Password).IsRequired().HasMaxLength(75);
            });
        }
    }
}