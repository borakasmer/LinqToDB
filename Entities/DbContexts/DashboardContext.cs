using System;
using System.Collections.Generic;
using LinqToDBBlog.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinqToDBBlog.Entities.DbContexts;

public partial class DashboardContext : DbContext
{
    public DashboardContext()
    {
    }

    public DashboardContext(DbContextOptions<DashboardContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AbAbone> AbAbone { get; set; }

    public virtual DbSet<AbAboneGrubu> AbAboneGrubu { get; set; }

    public virtual DbSet<AbAboneTipi> AbAboneTipi { get; set; }

    public virtual DbSet<CompaniesInfo> CompaniesInfo { get; set; }

    public virtual DbSet<DbMenu> DbMenu { get; set; }

    public virtual DbSet<DbRole> DbRole { get; set; }

    public virtual DbSet<DbRoleMenu> DbRoleMenu { get; set; }

    public virtual DbSet<DbSecurityAction> DbSecurityAction { get; set; }

    public virtual DbSet<DbSecurityController> DbSecurityController { get; set; }

    public virtual DbSet<DbSecurityRole> DbSecurityRole { get; set; }

    public virtual DbSet<DbSecurityUserAction> DbSecurityUserAction { get; set; }

    public virtual DbSet<DbSecurityUserRole> DbSecurityUserRole { get; set; }

    public virtual DbSet<DbUser> DbUser { get; set; }

    public virtual DbSet<DbUser2> DbUser2 { get; set; }

    public virtual DbSet<DbUser2017> DbUser2017 { get; set; }

    public virtual DbSet<DbUser2018> DbUser2018 { get; set; }

    public virtual DbSet<DbUser2019> DbUser2019 { get; set; }

    public virtual DbSet<DbUserMenu> DbUserMenu { get; set; }

    public virtual DbSet<GnBolge> GnBolge { get; set; }

    public virtual DbSet<GnSozlesmeTipi> GnSozlesmeTipi { get; set; }

    public virtual DbSet<RoleGroups> RoleGroups { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<SwaggerService> SwaggerService { get; set; }

    public virtual DbSet<UserRoles> UserRoles { get; set; }

    public virtual DbSet<UserSwagger> UserSwagger { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<ViewAbone> ViewAbone { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=192.168.50.173;Initial Catalog=ABYS_PROD;Persist Security Info=True;User ID=sa;Password=**yourPassword**;pooling=True;min pool size=0;max pool size=100;MultipleActiveResultSets=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AbAbone>(entity =>
        {
            entity.HasKey(e => e.IdAbone);

            entity.ToTable("AB_ABONE");

            entity.Property(e => e.IdAbone)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)");
            entity.Property(e => e.AboneAdi).HasMaxLength(250);
            entity.Property(e => e.AboneNo).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.AboneSoyadi).HasMaxLength(250);
            entity.Property(e => e.AcikAdres).HasMaxLength(500);
            entity.Property(e => e.KimlikNo).HasMaxLength(50);
            entity.Property(e => e.SozlesmeNo).HasColumnType("numeric(18, 0)");

            entity.HasOne(d => d.IdAboneTipiNavigation).WithMany(p => p.AbAbone)
                .HasForeignKey(d => d.IdAboneTipi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AB_ABONE_TIPI_IdAboneTipi");

            entity.HasOne(d => d.IdBolgeNavigation).WithMany(p => p.AbAbone)
                .HasForeignKey(d => d.IdBolge)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GN_BOLGE_IdBolge");

            entity.HasOne(d => d.IdSozlesmeTipiNavigation).WithMany(p => p.AbAbone)
                .HasForeignKey(d => d.IdSozlesmeTipi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GN_SOZLESME_TIPI_IdSozlesmeTipi");
        });

        modelBuilder.Entity<AbAboneGrubu>(entity =>
        {
            entity.HasKey(e => e.IdAboneGrubu);

            entity.ToTable("AB_ABONE_GRUBU");

            entity.Property(e => e.AboneGrubuAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<AbAboneTipi>(entity =>
        {
            entity.HasKey(e => e.IdAboneTipi);

            entity.ToTable("AB_ABONE_TIPI");

            entity.Property(e => e.AboneTipiAdi).HasMaxLength(100);
            entity.Property(e => e.SabitAl).HasMaxLength(50);
        });

        modelBuilder.Entity<CompaniesInfo>(entity =>
        {
            entity.ToTable("Companies_Info");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .HasColumnName("Company_Name");
            entity.Property(e => e.CompanyNumber).HasColumnName("Company_Number");
            entity.Property(e => e.ConnName)
                .HasMaxLength(500)
                .HasColumnName("Conn_Name");
            entity.Property(e => e.ConnStr)
                .HasMaxLength(500)
                .HasColumnName("Conn_Str");
        });

        modelBuilder.Entity<DbMenu>(entity =>
        {
            entity.HasKey(e => e.IdMenu);

            entity.ToTable("DB_MENU");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageClass).HasMaxLength(75);
            entity.Property(e => e.MenuName).HasMaxLength(150);
            entity.Property(e => e.ModDate).HasColumnType("datetime");
            entity.Property(e => e.RoutingPath).HasMaxLength(255);
        });

        modelBuilder.Entity<DbRole>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.ToTable("DB_ROLE");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModDate).HasColumnType("datetime");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<DbRoleMenu>(entity =>
        {
            entity.HasKey(e => e.IdRoleMenu);

            entity.ToTable("DB_ROLE_MENU");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate).HasColumnType("datetime");
            entity.Property(e => e.ModDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DbSecurityAction>(entity =>
        {
            entity.HasKey(e => e.IdSecurityAction);

            entity.ToTable("DB_SECURITY_ACTION");

            entity.Property(e => e.ActionName).HasMaxLength(100);
            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.ModDate).HasColumnType("datetime");
            entity.Property(e => e.OpenStatus).HasDefaultValue(true);

            entity.HasOne(d => d.IdSecurityControllerNavigation).WithMany(p => p.DbSecurityAction)
                .HasForeignKey(d => d.IdSecurityController)
                .HasConstraintName("FK_DB_SECURITY_ACTION_DB_SECURITY_CONTROLLER");
        });

        modelBuilder.Entity<DbSecurityController>(entity =>
        {
            entity.HasKey(e => e.IdSecurityController);

            entity.ToTable("DB_SECURITY_CONTROLLER");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.ControllerName).HasMaxLength(100);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.ModDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DbSecurityRole>(entity =>
        {
            entity.HasKey(e => e.IdSecurityRole);

            entity.ToTable("DB_SECURITY_ROLE");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModDate).HasColumnType("datetime");
            entity.Property(e => e.SecurityRoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<DbSecurityUserAction>(entity =>
        {
            entity.HasKey(e => e.IdSecurityUserAction);

            entity.ToTable("DB_SECURITY_USER_ACTION");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Deleted).HasDefaultValue(false);
            entity.Property(e => e.ModDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdSecurityControllerNavigation).WithMany(p => p.DbSecurityUserAction)
                .HasForeignKey(d => d.IdSecurityController)
                .HasConstraintName("FK_DB_SECURITY_USER_ACTION_DB_SECURITY_CONTROLLER");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.DbSecurityUserAction)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_DB_SECURITY_USER_ACTION_DB_USER");
        });

        modelBuilder.Entity<DbSecurityUserRole>(entity =>
        {
            entity.HasKey(e => e.IdSecurityUserRole);

            entity.ToTable("DB_SECURITY_USER_ROLE");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Deleted).HasDefaultValue(false);
            entity.Property(e => e.ModDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdSecurityControllerNavigation).WithMany(p => p.DbSecurityUserRole)
                .HasForeignKey(d => d.IdSecurityController)
                .HasConstraintName("FK_DB_SECURITY_USER_ROLE_DB_SECURITY_CONTROLLER");

            entity.HasOne(d => d.IdSecurityRoleNavigation).WithMany(p => p.DbSecurityUserRole)
                .HasForeignKey(d => d.IdSecurityRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DB_SECURITY_USER_ROLE_DB_SECURITY_ROLE");
        });

        modelBuilder.Entity<DbUser>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("DB_USER");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gsm)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasDefaultValue(false);
            entity.Property(e => e.IsRoleLock).HasDefaultValue(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSecurityRoleNavigation).WithMany(p => p.DbUser)
                .HasForeignKey(d => d.IdSecurityRole)
                .HasConstraintName("FK_DB_USER_DB_SECURITY_ROLE");
        });

        modelBuilder.Entity<DbUser2>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("DB_USER2");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gsm)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasDefaultValue(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSecurityRoleNavigation).WithMany(p => p.DbUser2)
                .HasForeignKey(d => d.IdSecurityRole)
                .HasConstraintName("FK_DB_USER2_DB_SECURITY_ROLE");
        });

        modelBuilder.Entity<DbUser2017>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("DB_USER2017");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gsm)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasDefaultValue(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSecurityRoleNavigation).WithMany(p => p.DbUser2017)
                .HasForeignKey(d => d.IdSecurityRole)
                .HasConstraintName("FK_DB_USER2017_DB_SECURITY_ROLE");
        });

        modelBuilder.Entity<DbUser2018>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("DB_USER2018");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gsm)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasDefaultValue(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSecurityRoleNavigation).WithMany(p => p.DbUser2018)
                .HasForeignKey(d => d.IdSecurityRole)
                .HasConstraintName("FK_DB_USER2018_DB_SECURITY_ROLE");
        });

        modelBuilder.Entity<DbUser2019>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("DB_USER2019");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gsm)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasDefaultValue(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSecurityRoleNavigation).WithMany(p => p.DbUser2019)
                .HasForeignKey(d => d.IdSecurityRole)
                .HasConstraintName("FK_DB_USER2019_DB_SECURITY_ROLE");
        });

        modelBuilder.Entity<DbUserMenu>(entity =>
        {
            entity.HasKey(e => e.IdUserMenu);

            entity.ToTable("DB_USER_MENU");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GnBolge>(entity =>
        {
            entity.HasKey(e => e.IdBolge);

            entity.ToTable("GN_BOLGE");

            entity.Property(e => e.BolgeAdi).HasMaxLength(250);
            entity.Property(e => e.BolgeKodu).HasMaxLength(10);
            entity.Property(e => e.EfaturaIban).HasMaxLength(50);
            entity.Property(e => e.FirmaAdi).HasMaxLength(250);
            entity.Property(e => e.FirmaKisaAdi).HasMaxLength(50);
            entity.Property(e => e.Vkn).HasMaxLength(10);
        });

        modelBuilder.Entity<GnSozlesmeTipi>(entity =>
        {
            entity.HasKey(e => e.IdSozlesmeTipi);

            entity.ToTable("GN_SOZLESME_TIPI");

            entity.Property(e => e.SozlesmeTipiAdi).HasMaxLength(250);
            entity.Property(e => e.SozlesmeTipiKodu).HasMaxLength(2);
        });

        modelBuilder.Entity<RoleGroups>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Group).WithMany(p => p.Roles)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_Roles_RoleGroups");
        });

        modelBuilder.Entity<SwaggerService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SwaggerService");

            entity.ToTable("SWAGGER_SERVICE");

            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ServiceKey).HasMaxLength(500);
        });

        modelBuilder.Entity<UserRoles>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RoleGroupId).HasColumnName("RoleGroupID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.RoleGroup).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleGroupId)
                .HasConstraintName("FK_UserRoles_RoleGroups");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserRoles_Users");
        });

        modelBuilder.Entity<UserSwagger>(entity =>
        {
            entity.ToTable("USER_SWAGGER");

            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdSwaggerNavigation).WithMany(p => p.UserSwagger)
                .HasForeignKey(d => d.IdSwagger)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_SWAGGER_SWAGGER_SERVICE");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserSwagger)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_SWAGGER_DB_USER");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gsm)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasDefaultValue(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ViewAbone>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_ABONE");

            entity.Property(e => e.AboneNo).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.FirmaKisaAdi).HasMaxLength(50);
            entity.Property(e => e.SozlesmeNo).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.SozlesmeTipiAdi).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
