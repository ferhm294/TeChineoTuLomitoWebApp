using Microsoft.EntityFrameworkCore;
using API_TeChineoTuLomito.Models;

namespace API_TeChineoTuLomito
{
    public class DBContexto : DbContext
    {
        public DBContexto(DbContextOptions<DBContexto> options) : base(options)
        {
        }

        // DbSets para cada tabla
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Procedimiento> Procedimientos { get; set; }
        public DbSet<ProcedimientoAplicado> ProcedimientosAplicados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapear cada entidad al esquema correcto
            modelBuilder.Entity<Persona>().ToTable("Persona", "API_TeChineoTuLomito");
            modelBuilder.Entity<Cliente>().ToTable("Cliente", "API_TeChineoTuLomito");
            modelBuilder.Entity<Empleado>().ToTable("Empleado", "API_TeChineoTuLomito");
            modelBuilder.Entity<Mascota>().ToTable("Mascota", "API_TeChineoTuLomito");
            modelBuilder.Entity<Procedimiento>().ToTable("Procedimiento", "API_TeChineoTuLomito");
            modelBuilder.Entity<ProcedimientoAplicado>().ToTable("ProcedimientoAplicado", "API_TeChineoTuLomito");

            // Tipos numéricos
            modelBuilder.Entity<Procedimiento>()
                .Property(p => p.precio)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Empleado>()
                .Property(e => e.salarioXDia)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ProcedimientoAplicado>()
                .Property(pa => pa.precioProcedimientoConImpuesto)
                .HasColumnType("decimal(18,2)");

            // -------------------------------
            // Relaciones
            // -------------------------------

            // Cliente - Mascota (1:N)
            // Usa la columna real 'identificacionDueno' como FK
            modelBuilder.Entity<Mascota>()
                .HasOne(m => m.Cliente)
                .WithMany(c => c.Mascotas)
                .HasForeignKey(m => m.identificacionDueño) // corregido: sin ñ
                .IsRequired();

            // ProcedimientoAplicado - Mascota (N:1)
            // Usa la columna real 'idMascota' como FK
            modelBuilder.Entity<ProcedimientoAplicado>()
                .HasOne(pa => pa.Mascota)
                .WithMany(m => m.ProcedimientosAplicados)
                .HasForeignKey(pa => pa.idMascota);

            // ProcedimientoAplicado - Procedimiento (N:1)
            // Usa la columna real 'idProcedimiento' como FK
            modelBuilder.Entity<ProcedimientoAplicado>()
                .HasOne(pa => pa.Procedimiento)
                .WithMany(p => p.ProcedimientosAplicados)
                .HasForeignKey(pa => pa.idProcedimiento);
        }
    }
}
