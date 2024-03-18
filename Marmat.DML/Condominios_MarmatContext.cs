using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Marmat.DML
{
    public partial class Condominios_MarmatContext : DbContext
    {
        public Condominios_MarmatContext()
        {
        }

        public Condominios_MarmatContext(DbContextOptions<Condominios_MarmatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aviso> Avisos { get; set; } = null!;
        public virtual DbSet<Areacomun> Areacomuns { get; set; } = null!;
        public virtual DbSet<Bitacora> Bitacoras { get; set; } = null!;
        public virtual DbSet<Boletin> Boletins { get; set; } = null!;
        public virtual DbSet<Canton> Cantons { get; set; } = null!;
        public virtual DbSet<ComentarioTicket> ComentarioTickets { get; set; } = null!;
        public virtual DbSet<Condominio> Condominios { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Direccion> Direccions { get; set; } = null!;
        public virtual DbSet<Distrito> Distritos { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Provincium> Provincia { get; set; } = null!;
        public virtual DbSet<Reserva> Reservas { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("StringConection.IHidThisforSecurityInMyGitHub.");

               
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Areacomun>(entity =>
            {
                entity.HasKey(e => e.IdAreacomun)
                    .HasName("PK__AREACOMU__B4E2356CA9C89A46");

                entity.ToTable("AREACOMUN");

                entity.Property(e => e.IdAreacomun).HasColumnName("ID_AREACOMUN");

                entity.Property(e => e.NombreAreacomun)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_AREACOMUN");
            });
            modelBuilder.Entity<Aviso>(entity =>
            {
                entity.HasKey(e => e.IdAviso)
                    .HasName("PK__AVISO__F752B0CBB206AEFC");

                entity.ToTable("AVISO");

                entity.Property(e => e.IdAviso).HasColumnName("ID_AVISO");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("COMENTARIO");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Avisos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AVISO__ID_USUARI__02084FDA");
            });
            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.IdBitacora)
                    .HasName("PK__BITACORA__44E70BF3255F48F3");

                entity.ToTable("BITACORA");

                entity.Property(e => e.IdBitacora).HasColumnName("ID_BITACORA");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("FECHA");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Bitacoras)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BITACORA__ID_USU__32E0915F");
            });
            modelBuilder.Entity<Boletin>(entity =>
            {
                entity.HasKey(e => e.IdBoletin)
                    .HasName("PK__BOLETIN__E1B136C9527792AD");

                entity.ToTable("BOLETIN");

                entity.Property(e => e.IdBoletin).HasColumnName("ID_BOLETIN");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("COMENTARIO");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_FINAL");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_INICIO");
            });
            modelBuilder.Entity<Canton>(entity =>
            {
                entity.HasKey(e => e.IdCanton)
                    .HasName("PK__CANTON__6974547457B19D7B");

                entity.ToTable("CANTON");

                entity.Property(e => e.IdCanton).HasColumnName("ID_CANTON");

                entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");

                entity.Property(e => e.NombreCanton)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_CANTON");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Cantons)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CANTON__ID_PROVI__2A4B4B5E");
            });

            modelBuilder.Entity<ComentarioTicket>(entity =>
            {
                entity.HasKey(e => e.IdComentarioTicket)
                    .HasName("PK__COMENTAR__0242B9D2EA52B325");

                entity.ToTable("COMENTARIO_TICKET");

                entity.Property(e => e.IdComentarioTicket).HasColumnName("ID_COMENTARIO_TICKET");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("COMENTARIO");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("FECHA");

                entity.Property(e => e.IdTicket).HasColumnName("ID_TICKET");

                entity.HasOne(d => d.IdTicketNavigation)
                    .WithMany(p => p.ComentarioTickets)
                    .HasForeignKey(d => d.IdTicket)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMENTARI__ID_TI__440B1D61");
            });

            modelBuilder.Entity<Condominio>(entity =>
            {
                entity.HasKey(e => e.IdCondominio)
                    .HasName("PK__CONDOMIN__19233391DAFACCCB");

                entity.ToTable("CONDOMINIO");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.IdAreacomun).HasColumnName("ID_AREACOMUN");

                entity.Property(e => e.IdDireccion).HasColumnName("ID_DIRECCION");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEN");

                entity.Property(e => e.NombreCondominio)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_CONDOMINIO");

                entity.Property(e => e.Vacantes).HasColumnName("VACANTES");

                entity.HasOne(d => d.IdAreacomunNavigation)
                    .WithMany(p => p.Condominios)
                    .HasForeignKey(d => d.IdAreacomun)
                    .HasConstraintName("FK__CONDOMINI__ID_AR__0A9D95DB");

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.Condominios)
                    .HasForeignKey(d => d.IdDireccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CONDOMINI__ID_DI__70DDC3D8");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__DEPARTAM__52E77BE0EE0272F1");

                entity.ToTable("DEPARTAMENTO");

                entity.Property(e => e.IdDepartamento).HasColumnName("ID_DEPARTAMENTO");

                entity.Property(e => e.CantidadBanios).HasColumnName("CANTIDAD_BANIOS");

                entity.Property(e => e.CantidadCuartos).HasColumnName("CANTIDAD_CUARTOS");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEN");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DEPARTAME__ID_CO__3C69FB99");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__DEPARTAME__ID_US__3B75D760");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(e => e.IdDireccion)
                    .HasName("PK__DIRECCIO__FC7E9E8E21539195");

                entity.ToTable("DIRECCION");

                entity.Property(e => e.IdDireccion).HasColumnName("ID_DIRECCION");

                entity.Property(e => e.IdDistrito).HasColumnName("ID_DISTRITO");

                entity.Property(e => e.NombreDireccion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_DIRECCION");

                entity.HasOne(d => d.IdDistritoNavigation)
                    .WithMany(p => p.Direccions)
                    .HasForeignKey(d => d.IdDistrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIRECCION__ID_DI__35BCFE0A");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.IdDistrito)
                    .HasName("PK__DISTRITO__6F133D4979FF54BF");

                entity.ToTable("DISTRITO");

                entity.Property(e => e.IdDistrito).HasColumnName("ID_DISTRITO");

                entity.Property(e => e.IdCanton).HasColumnName("ID_CANTON");

                entity.Property(e => e.NombreDistrito)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_DISTRITO");

                entity.HasOne(d => d.IdCantonNavigation)
                    .WithMany(p => p.Distritos)
                    .HasForeignKey(d => d.IdCanton)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DISTRITO__ID_CAN__2D27B809");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__ESTADO__241E2E011ADDCAA3");

                entity.ToTable("ESTADO");

                entity.Property(e => e.IdEstado).HasColumnName("ID_ESTADO");

                entity.Property(e => e.NombreEstado)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_ESTADO");
            });

            modelBuilder.Entity<Provincium>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("PK__PROVINCI__4245DC521B79B463");

                entity.ToTable("PROVINCIA");

                entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");

                entity.Property(e => e.NombreProvincia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_PROVINCIA");
            });
            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__RESERVA__1ED54AE3A733E1EC");

                entity.ToTable("RESERVA");

                entity.Property(e => e.IdReserva).HasColumnName("ID_RESERVA");

                entity.Property(e => e.FechaReserva)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_RESERVA");

                entity.Property(e => e.IdAreacomun).HasColumnName("ID_AREACOMUN");

                entity.HasOne(d => d.IdAreacomunNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdAreacomun)
                    .HasConstraintName("FK__RESERVA__ID_AREA__09A971A2");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__ROL__203B0F68311D2554");

                entity.ToTable("ROL");

                entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_ROL");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.IdTicket)
                    .HasName("PK__TICKET__129B4F2251B41A06");

                entity.ToTable("TICKET");

                entity.Property(e => e.IdTicket).HasColumnName("ID_TICKET");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.IdDepartamento).HasColumnName("ID_DEPARTAMENTO");

                entity.Property(e => e.IdEstado).HasColumnName("ID_ESTADO");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TICKET__ID_DEPAR__412EB0B6");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TICKET__ID_ESTAD__3F466844");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TICKET__ID_USUAR__403A8C7D");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__91136B908D31EFE1");

                entity.ToTable("USUARIO");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_USUARIO");

                entity.Property(e => e.NumeroTel).HasColumnName("NUMERO_TEL");

                entity.Property(e => e.Pass)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASS");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRIMER_APELLIDO");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SEGUNDO_APELLIDO");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__ID_ROL__300424B4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
