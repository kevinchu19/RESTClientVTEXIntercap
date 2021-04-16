using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RESTClientIntercapVTEX.Entities;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class ApiIntercapContext : DbContext
    {
        public ApiIntercapContext()
        {
        }

        public ApiIntercapContext(DbContextOptions<ApiIntercapContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Stmpdh> Stmpdh { get; set; }
        public virtual DbSet<Usr_Pratri> Usr_Pratri { get; set; }
        public virtual DbSet<Usr_Sttcas> Usr_Sttcas { get; set; }
        public virtual DbSet<Usr_Sttcaa> Usr_Sttcaa { get; set; }
        public virtual DbSet<Usr_Sttcah> Usr_Sttcah { get; set; }
        public virtual DbSet<Usr_Sttcai> Usr_Sttcai { get; set; }
        public virtual DbSet<Usr_Stmpph> Usr_Stmpph { get; set; }
        public virtual DbSet<Usr_Stmpph_Real> Usr_Stmpph_Real { get; set; }
        public virtual DbSet<Usr_Sttcax> Usr_Sttcax { get; set; }
        public virtual DbSet<Usr_Sttcay> Usr_Sttcay { get; set; }
        public virtual DbSet<Usr_Sttgsh> Usr_Sttgsh { get; set; }
        public virtual DbSet<Usr_Sttmah> Usr_Sttmah { get; set; }

        public virtual DbSet<Usr_Sttgsh_Real> Usr_Sttgsh_Real { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Stmpdh>(entity =>
            {
                entity.HasKey(e => new { e.RowId });

                entity.ToTable("STMPDHlog");

                entity.Property(e => e.Stmpdh_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Descrp)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DESCRP");

                entity.Property(e => e.Stmpdh_Indcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_INDCOD");

                entity.Property(e => e.Stmpdh_Fecalt)
                                    .HasColumnType("datetime")
                                    .HasColumnName("STMPDH_FECALT");

                entity.Property(e => e.Stmpdh_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("STMPDH_FECMOD");

                entity.Property(e => e.Stmpdh_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_OALIAS");

                entity.Property(e => e.Stmpdh_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_ULTOPR")
                    .IsFixedLength(true);
                entity.Property(e => e.Stmpdh_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_USERID");


                entity.Property(e => e.Usr_Stmpdh_Catego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_CATEGO");

                entity.Property(e => e.Usr_Stmpdh_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_DEPTOS");


                entity.Property(e => e.Usr_Stmpdh_Father)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_FATHER");

                entity.Property(e => e.Usr_Stmpdh_Intnet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_INTNET")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpdh_Marcas).HasColumnName("USR_STMPDH_MARCAS");

                entity.Property(e => e.Usr_Stmpdh_Subcat)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_SUBCAT");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Stmpdh_Real>(entity =>
            {
                entity.HasKey(e => new { e.RowId });

                entity.ToTable("STMPDHlog");

                entity.Property(e => e.Stmpdh_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Descrp)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DESCRP");

                entity.Property(e => e.Stmpdh_Indcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_INDCOD");

                entity.Property(e => e.Stmpdh_Fecalt)
                                    .HasColumnType("datetime")
                                    .HasColumnName("STMPDH_FECALT");

                entity.Property(e => e.Stmpdh_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("STMPDH_FECMOD");

                entity.Property(e => e.Stmpdh_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_OALIAS");

                entity.Property(e => e.Stmpdh_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_ULTOPR")
                    .IsFixedLength(true);
                entity.Property(e => e.Stmpdh_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_USERID");


                entity.Property(e => e.Usr_Stmpdh_Catego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_CATEGO");

                entity.Property(e => e.Usr_Stmpdh_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_DEPTOS");


                entity.Property(e => e.Usr_Stmpdh_Father)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_FATHER");

                entity.Property(e => e.Usr_Stmpdh_Intnet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_INTNET")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpdh_Marcas).HasColumnName("USR_STMPDH_MARCAS");

                entity.Property(e => e.Usr_Stmpdh_Subcat)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_SUBCAT");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpdh_Idvtex).HasColumnName("USR_STMPDH_IDVTEX");
            });

            modelBuilder.Entity<Usr_Pratri>(entity =>
            {
                entity.HasKey(e => new { e.Usr_Pratri_Tippro, e.Usr_Pratri_Artcod, e.Usr_Pratri_Orden });

                entity.ToTable("USR_PRATRI");

                entity.Property(e => e.Usr_Pratri_Tippro)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRATRI_TIPPRO")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Pratri_Artcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRATRI_ARTCOD");

                entity.Property(e => e.Usr_Pratri_Orden).HasColumnName("USR_PRATRI_ORDEN");

                entity.Property(e => e.Usr_Pr_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_PR_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Pr_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_PR_FECALT");

                entity.Property(e => e.Usr_Pr_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_PR_FECMOD");

                entity.Property(e => e.Usr_Pr_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_PR_OALIAS");

                entity.Property(e => e.Usr_Pr_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_PR_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Pr_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_PR_USERID");

                entity.Property(e => e.Usr_Pratri_Campo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRATRI_CAMPO");

                entity.Property(e => e.Usr_Pratri_Valor)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRATRI_VALOR");
            });

            modelBuilder.Entity<Usr_Sttcas>(entity =>
            {
                entity.HasKey(e => new { e.RowId });

                entity.ToTable("USR_STTCASlog");

                entity.Property(e => e.Usr_Sttcas_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAS_DEPTOS");

                entity.Property(e => e.Usr_Sttcas_Catego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAS_CATEGO");

                entity.Property(e => e.Usr_Sttcas_Subcat)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAS_SUBCAT");

                entity.Property(e => e.Usr_St_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECALT");

                entity.Property(e => e.Usr_St_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECMOD");

                entity.Property(e => e.Usr_St_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_OALIAS");

                entity.Property(e => e.Usr_St_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_USERID");

                entity.Property(e => e.Usr_Sttcas_Descrp)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAS_DESCRP");

                entity.Property(e => e.Usr_Sttcas_Keywor)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAS_KEYWOR");

                entity.Property(e => e.Usr_Sttcas_Descri)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAS_DESCRI");

                entity.Property(e => e.Usr_Sttcas_Scores)
                    .HasColumnName("USR_STTCAS_SCORES");

                entity.Property(e => e.Usr_Sttcas_Isacti)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAS_ISACTI");

                entity.Property(e => e.Sfl_TableOperation)
                  .HasMaxLength(30)
                  .IsUnicode(false)
                  .HasColumnName("Sfl_TableOperation");

                entity.Property(e => e.Sfl_LoginDateTime)
                   .HasColumnType("datetime")
                   .HasColumnName("Sfl_LoginDateTime");

                entity.Property(e => e.Usr_Vtex_Transf)
                   .HasMaxLength(1)
                   .IsUnicode(false)
                   .HasColumnName("USR_VTEX_TRANSF");
            });

            modelBuilder.Entity<Usr_Sttcaa>(entity =>
            {
                entity.HasKey(e => new { e.RowId});

                entity.ToTable("USR_STTCAAlog");

                entity.Property(e => e.Usr_Sttcaa_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAA_DEPTOS");

                entity.Property(e => e.Usr_Sttcaa_Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAA_NOMBRE");
            
                entity.Property(e => e.Usr_St_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_OALIAS");

                entity.Property(e => e.Usr_St_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_USERID");

                entity.Property(e => e.Usr_Sttcaa_Defaul)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAA_DEFAUL");

                entity.Property(e => e.Usr_Sttcaa_Descrp)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAA_DESCRP");

                entity.Property(e => e.Usr_Sttcaa_Isfilt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAA_ISFILT")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcaa_Isonpr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAA_ISONPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcaa_Isrequ)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAA_ISREQU")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcaa_Isssku)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAA_ISSSKU")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcaa_Positi).HasColumnName("USR_STTCAA_POSITI");

                entity.Property(e => e.Usr_Sttcaa_Sidmen)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAA_SIDMEN")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcaa_Topmen)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAA_TOPMEN")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcaa_Fieldt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAA_FIELDT");
                
                entity.Property(e => e.Usr_Sttcaa_Isacti)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAA_ISACTI");

                entity.Property(e => e.Usr_Sttcaa_Grunam).HasColumnName("USR_STTCAA_GRUNAM");

                entity.Property(e => e.Sfl_TableOperation)
                  .HasMaxLength(30)
                  .IsUnicode(false)
                  .HasColumnName("Sfl_TableOperation");

                entity.Property(e => e.Sfl_LoginDateTime)
                   .HasColumnType("datetime")
                   .HasColumnName("Sfl_LoginDateTime");

                entity.Property(e => e.Usr_Vtex_Transf)
                   .HasMaxLength(1)
                   .IsUnicode(false)
                   .HasColumnName("USR_VTEX_TRANSF");

            });

            modelBuilder.Entity<Usr_Sttcah>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("USR_STTCAHlog");

                entity.Property(e => e.Usr_Sttcah_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAH_DEPTOS");

                entity.Property(e => e.Usr_St_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECALT");

                entity.Property(e => e.Usr_St_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECMOD");

                entity.Property(e => e.Usr_St_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_OALIAS");

                entity.Property(e => e.Usr_St_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_USERID");

                entity.Property(e => e.Usr_Sttcah_Descrp)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAH_DESCRP");

                entity.Property(e => e.Usr_Sttcah_Keywor)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAH_KEYWOR");

                entity.Property(e => e.Usr_Sttcah_Descri)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAH_DESCRI");

                entity.Property(e => e.Usr_Sttcah_Scores)
                    .HasColumnName("USR_STTCAH_SCORES");

                entity.Property(e => e.Sfl_TableOperation)
                  .HasMaxLength(30)
                  .IsUnicode(false)
                  .HasColumnName("Sfl_TableOperation");

                entity.Property(e => e.Sfl_LoginDateTime)
                   .HasColumnType("datetime")
                   .HasColumnName("Sfl_LoginDateTime");

                entity.Property(e => e.Usr_Vtex_Transf)
                   .HasMaxLength(1)
                   .IsUnicode(false)
                   .HasColumnName("USR_VTEX_TRANSF");
            });

            modelBuilder.Entity<Usr_Sttcai>(entity =>
            {
                entity.HasKey(e => new { e.RowId});

                entity.ToTable("USR_STTCAIlog");

                entity.Property(e => e.Usr_Sttcai_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAI_DEPTOS");

                entity.Property(e => e.Usr_Sttcai_Catego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAI_CATEGO");

                entity.Property(e => e.Usr_St_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECALT");

                entity.Property(e => e.Usr_St_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECMOD");

                entity.Property(e => e.Usr_St_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_OALIAS");

                entity.Property(e => e.Usr_St_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_USERID");

                entity.Property(e => e.Usr_Sttcai_Descrp)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAI_DESCRP");

                entity.Property(e => e.Usr_Sttcai_Keywor)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAI_KEYWOR");

                entity.Property(e => e.Usr_Sttcai_Descri)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAI_DESCRI");

                entity.Property(e => e.Usr_Sttcai_Scores)
                    .HasColumnName("USR_STTCAI_SCORES");

                entity.Property(e => e.Usr_Sttcai_Isacti)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAI_ISACTI");

                entity.Property(e => e.Sfl_TableOperation)
                   .HasMaxLength(30)
                   .IsUnicode(false)
                   .HasColumnName("Sfl_TableOperation");

                entity.Property(e => e.Sfl_LoginDateTime)
                   .HasColumnType("datetime")
                   .HasColumnName("Sfl_LoginDateTime");
                
                entity.Property(e => e.Usr_Vtex_Transf)
                   .HasMaxLength(1)
                   .IsUnicode(false)
                   .HasColumnName("USR_VTEX_TRANSF");

            });

            modelBuilder.Entity<Usr_Stmpph>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("USR_STMPPHlog");

                entity.Property(e => e.Usr_Stmpph_Indcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPH_INDCOD");

                entity.Property(e => e.Usr_St_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECALT");

                entity.Property(e => e.Usr_St_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECMOD");


                entity.Property(e => e.Usr_St_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_OALIAS");

                entity.Property(e => e.Usr_St_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_USERID");

                entity.Property(e => e.Usr_Stmpph_Catego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPH_CATEGO");

                entity.Property(e => e.Usr_Stmpph_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPH_DEPTOS");

                entity.Property(e => e.Usr_Stmpph_Descrp)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPH_DESCRP");

                entity.Property(e => e.Usr_Stmpph_Intnet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPH_INTNET")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpph_Marcas).HasColumnName("USR_STMPPH_MARCAS");

                entity.Property(e => e.Usr_Stmpph_Subcat)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPH_SUBCAT");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Usr_Stmpph_Real>(entity =>
            {
                entity.HasKey(e => e.Usr_Stmpph_Indcod);

                entity.ToTable("USR_STMPPH");

                entity.Property(e => e.Usr_Stmpph_Indcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPH_INDCOD");

                entity.Property(e => e.Usr_St_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECALT");

                entity.Property(e => e.Usr_St_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECMOD");


                entity.Property(e => e.Usr_St_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_OALIAS");

                entity.Property(e => e.Usr_St_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_USERID");

                entity.Property(e => e.Usr_Stmpph_Catego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPH_CATEGO");

                entity.Property(e => e.Usr_Stmpph_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPH_DEPTOS");

                entity.Property(e => e.Usr_Stmpph_Descrp)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPH_DESCRP");

                entity.Property(e => e.Usr_Stmpph_Intnet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPH_INTNET")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpph_Marcas).HasColumnName("USR_STMPPH_MARCAS");

                entity.Property(e => e.Usr_Stmpph_Subcat)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPH_SUBCAT");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpph_Idvtex).HasColumnName("USR_STMPPH_IDVTEX");
            });

            modelBuilder.Entity<Usr_Sttcax>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("USR_STTCAXlog");

                entity.Property(e => e.Usr_Sttcax_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAX_DEPTOS");

                entity.Property(e => e.Usr_Sttcax_Catego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAX_CATEGO");

                entity.Property(e => e.Usr_Sttcax_Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAX_NOMBRE");


                entity.Property(e => e.Usr_St_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECALT");

                entity.Property(e => e.Usr_St_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECMOD");


                entity.Property(e => e.Usr_St_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_OALIAS");

                entity.Property(e => e.Usr_St_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_USERID");

                entity.Property(e => e.Usr_Sttcax_Defaul)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAX_DEFAUL");

                entity.Property(e => e.Usr_Sttcax_Descrp)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAX_DESCRP");

                entity.Property(e => e.Usr_Sttcax_Fieldt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAX_FIELDT");

                entity.Property(e => e.Usr_Sttcax_Grunam)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAX_GRUNAM");

                entity.Property(e => e.Usr_Sttcax_Isacti)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAX_ISACTI")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcax_Isfilt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAX_ISFILT")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcax_Isonpr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAX_ISONPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcax_Isrequ)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAX_ISREQU")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcax_Isssku)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAX_ISSSKU")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcax_Positi).HasColumnName("USR_STTCAX_POSITI");

                entity.Property(e => e.Usr_Sttcax_Sidmen)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAX_SIDMEN")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcax_Topmen)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAX_TOPMEN")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Usr_Sttcay>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("USR_STTCAYlog");

                entity.Property(e => e.Usr_Sttcay_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAY_DEPTOS");

                entity.Property(e => e.Usr_Sttcay_Catego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAY_CATEGO");

                entity.Property(e => e.Usr_Sttcay_Subcat)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAY_SUBCAT");

                entity.Property(e => e.Usr_Sttcay_Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAY_NOMBRE");

                entity.Property(e => e.Usr_St_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECALT");

                entity.Property(e => e.Usr_St_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECMOD");


                entity.Property(e => e.Usr_St_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_OALIAS");

                entity.Property(e => e.Usr_St_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_USERID");

                entity.Property(e => e.Usr_Sttcay_Defaul)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAY_DEFAUL");

                entity.Property(e => e.Usr_Sttcay_Descrp)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAY_DESCRP");

                entity.Property(e => e.Usr_Sttcay_Fieldt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAY_FIELDT");

                entity.Property(e => e.Usr_Sttcay_Grunam)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAY_GRUNAM");

                entity.Property(e => e.Usr_Sttcay_Isacti)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAY_ISACTI")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcay_Isfilt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAY_ISFILT")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcay_Isonpr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAY_ISONPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcay_Isrequ)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAY_ISREQU")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcay_Isssku)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAY_ISSSKU")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcay_Positi).HasColumnName("USR_STTCAY_POSITI");

                entity.Property(e => e.Usr_Sttcay_Sidmen)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAY_SIDMEN")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttcay_Topmen)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAY_TOPMEN")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Usr_Sttgsh>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("USR_STTGSHlog");

                entity.Property(e => e.Usr_Sttgsh_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTGSH_DEPTOS");

                entity.Property(e => e.Usr_Sttgsh_Catego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTGSH_CATEGO");

                entity.Property(e => e.Usr_Sttgsh_Subcat)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTGSH_SUBCAT");

                entity.Property(e => e.Usr_Sttgsh_Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTGSH_NOMBRE");

                entity.Property(e => e.Usr_St_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECALT");

                entity.Property(e => e.Usr_St_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECMOD");

                entity.Property(e => e.Usr_St_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_OALIAS");

                entity.Property(e => e.Usr_St_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_USERID");

                entity.Property(e => e.Usr_Sttgsh_Idvtex).HasColumnName("USR_STTGSH_IDVTEX");

                entity.Property(e => e.Usr_Sttgsh_Positi).HasColumnName("USR_STTGSH_POSITI");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Usr_Sttmah>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("USR_STTMAHlog");

                entity.Property(e => e.Usr_Sttmah_Codigo)
                    .ValueGeneratedNever()
                    .HasColumnName("USR_STTMAH_CODIGO");

                entity.Property(e => e.Usr_St_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECALT");

                entity.Property(e => e.Usr_St_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECMOD");

                entity.Property(e => e.Usr_St_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_OALIAS");

                entity.Property(e => e.Usr_St_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_USERID");

                entity.Property(e => e.Usr_Sttmah_Descrp)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTMAH_DESCRP");

                entity.Property(e => e.Usr_Sttmah_Keywor)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTMAH_KEYWOR");

                entity.Property(e => e.Usr_Sttmah_Menhom)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTMAH_MENHOM")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttmah_Scores).HasColumnName("USR_STTMAH_SCORES");

                entity.Property(e => e.Usr_Sttmah_Sittit)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTMAH_SITTIT");

                entity.Property(e => e.Usr_Sttmah_Textos)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTMAH_TEXTOS");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);
            });
            modelBuilder.Entity<Usr_Sttgsh_Real>(entity =>
            {
                entity.HasKey(e => new { e.Usr_Sttgsh_Deptos, e.Usr_Sttgsh_Catego, e.Usr_Sttgsh_Subcat, e.Usr_Sttgsh_Nombre });

                entity.ToTable("USR_STTGSH");

                entity.Property(e => e.Usr_Sttgsh_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTGSH_DEPTOS");

                entity.Property(e => e.Usr_Sttgsh_Catego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTGSH_CATEGO");

                entity.Property(e => e.Usr_Sttgsh_Subcat)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTGSH_SUBCAT");

                entity.Property(e => e.Usr_Sttgsh_Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTGSH_NOMBRE");

                entity.Property(e => e.Usr_St_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECALT");

                entity.Property(e => e.Usr_St_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_ST_FECMOD");

                entity.Property(e => e.Usr_St_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_OALIAS");

                entity.Property(e => e.Usr_St_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_USERID");

                entity.Property(e => e.Usr_Sttgsh_Idvtex).HasColumnName("USR_STTGSH_IDVTEX");

                entity.Property(e => e.Usr_Sttgsh_Positi).HasColumnName("USR_STTGSH_POSITI");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
