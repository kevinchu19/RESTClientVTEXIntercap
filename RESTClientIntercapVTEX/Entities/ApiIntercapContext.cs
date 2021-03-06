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
        public virtual DbSet<Usr_Pratrm> Usr_Pratrm { get; set; }
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
        public virtual DbSet<Usr_Sttcaa_Real> Usr_Sttcaa_Real { get; set; }
        public virtual DbSet<Usr_Sttcax_Real> Usr_Sttcax_Real { get; set; }
        public virtual DbSet<Usr_Sttcay_Real> Usr_Sttcay_Real { get; set; }
        public virtual DbSet<Usr_Sttvai> Usr_Sttvai { get; set; }
        public virtual DbSet<Usr_Sttvai_Real> Usr_Sttvai_Real { get; set; }
        public virtual DbSet<Usr_Pratri_Real> Usr_Pratri_Real{ get; set; }
        public virtual DbSet<Usr_Pratrm_Real> Usr_Pratrm_Real { get; set; }
        public virtual DbSet<Usr_Stmppa_Real> Usr_Stmppa_Real { get; set; }
        public virtual DbSet<Usr_Stmppa> Usr_Stmppa { get; set; }
        public virtual DbSet<Usr_Stimpr_Real> Usr_Stimpr_Real { get; set; }
        public virtual DbSet<Usr_Stimpr> Usr_Stimpr { get; set; }
        public virtual DbSet<Usr_Prmoto> Usr_Prmoto { get; set; }
        public virtual DbSet<Usr_Prmoto_Real> Usr_Prmoto_Real { get; set; }
        public virtual DbSet<Sar_Fcrmvh> Sar_Fcrmvh { get; set; }
        public virtual DbSet<Sar_Fcrmvi> Sar_Fcrmvi { get; set; }
        public virtual DbSet<Sar_Fcrmvt> Sar_Fcrmvt { get; set; }
        public virtual DbSet<Usr_Vtexha> Usr_Vtexha { get; set; }
        public virtual DbSet<Usr_Dscont> Usr_Dscont { get; set; }
        public virtual DbSet<Usr_Dspaym> Usr_Dspaym { get; set; }
        public virtual DbSet<Usr_Dspeml> Usr_Dspeml { get; set; }
        public virtual DbSet<Usr_Dsship> Usr_Dsship { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Stmpdh>(entity =>
            {
                entity.HasKey(e => new { e.Stmpdh_Tippro, e.Stmpdh_Artcod });

                entity.ToTable("STMPDHlog");

                entity.Property(e => e.Stmpdh_Tippro)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_TIPPRO");

                entity.Property(e => e.Stmpdh_Artcod)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_ARTCOD");

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

                entity.Property(e => e.Stmpdh_Kitsfc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_KITSFC");

                entity.Property(e => e.Stmpdh_Unimed)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_UNIMED");


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


                entity.Property(e => e.Usr_Stmpdh_Father).HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_FATHER")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpdh_Intnet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_INTNET")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpdh_Marcas).HasColumnName("USR_STMPDH_MARCAS");

                entity.Property(e => e.Usr_Stmpdh_Idvtex).HasColumnName("USR_STMPDH_IDVTEX");

                entity.Property(e => e.Usr_Stmpdh_IdSKUvtex).HasColumnType("int").HasColumnName("USR_STMPDH_IDSKUVTEX");

                entity.Property(e => e.Usr_Stmpdh_Subcat)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_SUBCAT");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtex_Skutra)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_SKUTRA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtex_Isacti)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_ISACTI")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpdh_Keywor)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_KEYWOR")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Stmpdh_Real>(entity =>
            {
                entity.HasKey(e => new { e.Stmpdh_Tippro, e.Stmpdh_Artcod });

                entity.ToTable("STMPDH");

                entity.Property(e => e.Stmpdh_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Tippro)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_TIPPRO");

                entity.Property(e => e.Stmpdh_Artcod)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_ARTCOD");

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


                entity.Property(e => e.Usr_Vtex_Skutra)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_SKUTRA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtex_Stktra)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_STKTRA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtex_Imgtra)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_IMGTRA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vtex_Pretra)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_PRETRA")
                    .IsFixedLength(true);
                
                entity.Property(e => e.Usr_Vtex_Isacti)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_ISACTI")
                    .IsFixedLength(true);

                

                entity.Property(e => e.Usr_Stmpdh_Idvtex).HasColumnName("USR_STMPDH_IDVTEX");
                
                entity.Property(e => e.Usr_Stmpdh_IdSKUvtex).HasColumnName("USR_STMPDH_IDSKUVTEX");
            });

            modelBuilder.Entity<Usr_Pratri>(entity =>
            {
                entity.HasKey(e => new { e.RowId });

                entity.ToTable("USR_PRATRIlog");

                entity.Property(e => e.Usr_Pratri_Tippro)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRATRI_TIPPRO")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Pratri_Artcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRATRI_ARTCOD");

                entity.Property(e => e.ProductId).HasColumnName("ProductId");
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

                entity.Property(e => e.Usr_St_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_ST_OALIAS");

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
                    .HasColumnName("USR_PRATRI_CAMPO");

                entity.Property(e => e.Usr_Pratri_Idvtex).HasColumnName("USR_PRATRI_IDVTEX");

                entity.Property(e => e.Usr_Pratri_Valor)
                    .HasColumnName("USR_PRATRI_VALOR");

                entity.Property(e => e.Usr_Pratri_Textos)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRATRI_TEXTOS");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);

                entity.Property(e => e.Sfl_TableOperation)
                  .HasMaxLength(30)
                  .IsUnicode(false)
                  .HasColumnName("Sfl_TableOperation");

                entity.Property(e => e.Sfl_LoginDateTime)
                   .HasColumnType("datetime")
                   .HasColumnName("Sfl_LoginDateTime");

            });


            modelBuilder.Entity<Usr_Pratrm>(entity =>
            {
                entity.HasKey(e => new { e.RowId });

                entity.ToTable("USR_PRATRMlog");

                entity.Property(e => e.Usr_Pratrm_Tippro)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRATRM_TIPPRO")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Pratrm_Artcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRATRM_ARTCOD");

                entity.Property(e => e.Usr_Pratrm_Orden).HasColumnName("USR_PRATRM_ORDEN");

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


                entity.Property(e => e.Usr_Pr_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_PR_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Pr_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_PR_USERID");

                entity.Property(e => e.Usr_Pratrm_Campo)
                    .HasColumnName("USR_PRATRM_CAMPO");

                entity.Property(e => e.Usr_Pratrm_Idvtex).HasColumnName("USR_PRATRM_IDVTEX");

                entity.Property(e => e.Usr_Pratrm_Valor)
                    .HasColumnName("USR_PRATRM_VALOR");


                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);

                entity.Property(e => e.Sfl_TableOperation)
                  .HasMaxLength(30)
                  .IsUnicode(false)
                  .HasColumnName("Sfl_TableOperation");

                entity.Property(e => e.Sfl_LoginDateTime)
                   .HasColumnType("datetime")
                   .HasColumnName("Sfl_LoginDateTime");

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

                entity.Property(e => e.Usr_Sttcaa_Idvtex).HasColumnName("USR_STTCAA_IDVTEX");

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
                entity.Property(e => e.Usr_Stmpph_Idvtex).HasColumnName("USR_STMPPH_IDVTEX");

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

                entity.Property(e => e.Usr_Sttcax_Idvtex).HasColumnName("USR_STTCAX_IDVTEX");
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
                    .HasColumnName("USR_STTCAY_FIELDT");

                entity.Property(e => e.Usr_Sttcay_Grunam)
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

                entity.Property(e => e.Usr_Sttcay_Idvtex).HasColumnName("USR_STTCAY_IDVTEX");
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

            modelBuilder.Entity<Usr_Sttcaa_Real>(entity =>
            {
                entity.HasKey(e => new { e.Usr_Sttcaa_Deptos, e.Usr_Sttcaa_Nombre });

                entity.ToTable("USR_STTCAA");

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

                entity.Property(e => e.Usr_Vtex_Transf)
                   .HasMaxLength(1)
                   .IsUnicode(false)
                   .HasColumnName("USR_VTEX_TRANSF");

                entity.Property(e => e.Usr_Sttcaa_Idvtex).HasColumnName("USR_STTCAA_IDVTEX");

            });

            modelBuilder.Entity<Usr_Sttcax_Real>(entity =>
            {
                entity.HasKey(e => new { e.Usr_Sttcax_Deptos , e.Usr_Sttcax_Catego, e.Usr_Sttcax_Nombre});

                entity.ToTable("USR_STTCAX");

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

                entity.Property(e => e.Usr_Sttcax_Idvtex).HasColumnName("USR_STTCAX_IDVTEX");
            });

            modelBuilder.Entity<Usr_Sttcay_Real>(entity =>
            {
                entity.HasKey(e => new { e.Usr_Sttcay_Deptos, e.Usr_Sttcay_Catego, e.Usr_Sttcay_Subcat,e.Usr_Sttcay_Nombre});

                entity.ToTable("USR_STTCAY");

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

                entity.Property(e => e.Usr_Sttcay_Idvtex).HasColumnName("USR_STTCAY_IDVTEX");
            });

            modelBuilder.Entity<Usr_Sttvai>(entity =>
            {
                entity.HasKey(e => new { e.RowId });

                entity.ToTable("USR_STTVAIlog");

                entity.Property(e => e.Usr_Sttvai_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTVAI_DEPTOS");

                entity.Property(e => e.Usr_Sttvai_Catego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTVAI_CATEGO");

                entity.Property(e => e.Usr_Sttvai_Subcat)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTVAI_SUBCAT");

                entity.Property(e => e.Usr_Sttvai_Fielid).HasColumnName("USR_STTVAI_FIELID");

                entity.Property(e => e.Usr_Sttvai_Valor)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTVAI_VALOR");

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

                entity.Property(e => e.Usr_Sttvai_Idvtex).HasColumnName("USR_STTVAI_IDVTEX");

                entity.Property(e => e.Usr_Sttvai_Isacti)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTVAI_ISACTI")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttvai_Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTVAI_NOMBRE");

                entity.Property(e => e.Usr_Sttvai_Positi).HasColumnName("USR_STTVAI_POSITI");

                entity.Property(e => e.Usr_Sttvai_Textos)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTVAI_TEXTOS");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);

                entity.Property(e => e.Sfl_TableOperation)
                  .HasMaxLength(30)
                  .IsUnicode(false)
                  .HasColumnName("Sfl_TableOperation");

                entity.Property(e => e.Sfl_LoginDateTime)
                   .HasColumnType("datetime")
                   .HasColumnName("Sfl_LoginDateTime");
            });

            modelBuilder.Entity<Usr_Sttvai_Real>(entity =>
            {
                entity.HasKey(e => new { e.Usr_Sttvai_Deptos, e.Usr_Sttvai_Catego, e.Usr_Sttvai_Subcat, e.Usr_Sttvai_Fielid, e.Usr_Sttvai_Valor});

                entity.ToTable("USR_STTVAI");

                entity.Property(e => e.Usr_Sttvai_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTVAI_DEPTOS");

                entity.Property(e => e.Usr_Sttvai_Catego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTVAI_CATEGO");

                entity.Property(e => e.Usr_Sttvai_Subcat)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTVAI_SUBCAT");

                entity.Property(e => e.Usr_Sttvai_Fielid).HasColumnName("USR_STTVAI_FIELID");

                entity.Property(e => e.Usr_Sttvai_Valor)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTVAI_VALOR");

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

                entity.Property(e => e.Usr_Sttvai_Idvtex).HasColumnName("USR_STTVAI_IDVTEX");

                entity.Property(e => e.Usr_Sttvai_Isacti)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTVAI_ISACTI")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Sttvai_Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTVAI_NOMBRE");

                entity.Property(e => e.Usr_Sttvai_Positi).HasColumnName("USR_STTVAI_POSITI");

                entity.Property(e => e.Usr_Sttvai_Textos)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTVAI_TEXTOS");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Usr_Pratri_Real>(entity =>
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

                entity.Property(e => e.Usr_Pratri_Idvtex).HasColumnName("USR_PRATRI_IDVTEX");

                entity.Property(e => e.Usr_Pratri_Valor)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRATRI_VALOR");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);
            });


            modelBuilder.Entity<Usr_Pratrm_Real>(entity =>
            {
                entity.HasKey(e => new { e.Usr_Pratrm_Tippro, e.Usr_Pratrm_Artcod, e.Usr_Pratrm_Orden });

                entity.ToTable("USR_PRatrm");

                entity.Property(e => e.Usr_Pratrm_Tippro)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRATRM_TIPPRO")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Pratrm_Artcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRATRM_ARTCOD");

                entity.Property(e => e.Usr_Pratrm_Orden).HasColumnName("USR_PRATRM_ORDEN");

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

                entity.Property(e => e.Usr_Pratrm_Campo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRATRM_CAMPO");

                entity.Property(e => e.Usr_Pratrm_Idvtex).HasColumnName("USR_PRATRM_IDVTEX");

                entity.Property(e => e.Usr_Pratrm_Valor)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRATRM_VALOR");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);
            });


            modelBuilder.Entity<Usr_Stmppa_Real>(entity =>
            {
                entity.HasKey(e => new { e.Usr_Stmppa_Indcod, e.Usr_Stmppa_Orden });

                entity.ToTable("USR_STMPPA");

                entity.Property(e => e.Usr_Stmppa_Indcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPA_INDCOD");

                entity.Property(e => e.Usr_Stmppa_Orden).HasColumnName("USR_STMPPA_ORDEN");

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

                entity.Property(e => e.Usr_Stmppa_Campo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPA_CAMPO");

                entity.Property(e => e.Usr_Stmppa_Idvtex).HasColumnName("USR_STMPPA_IDVTEX");

                entity.Property(e => e.Usr_Stmppa_Valor)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPA_VALOR");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);
            });


            modelBuilder.Entity<Usr_Stmppa>(entity =>
            {
                entity.HasKey(e => new { e.RowId });

                entity.ToTable("USR_Stmppalog");

                entity.Property(e => e.Usr_Stmppa_Indcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_Stmppa_INDCOD")
                    .IsFixedLength(true);
                
                entity.Property(e => e.ProductId).HasColumnName("ProductId");

                entity.Property(e => e.Usr_Stmppa_Orden).HasColumnName("USR_Stmppa_ORDEN");

                entity.Property(e => e.Usr_St_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Usr_St_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("Usr_St_FECALT");

                entity.Property(e => e.Usr_St_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("Usr_St_FECMOD");

                entity.Property(e => e.Usr_St_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Usr_St_OALIAS");

                entity.Property(e => e.Usr_St_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Usr_St_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_St_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Usr_St_USERID");

                entity.Property(e => e.Usr_Stmppa_Campo)
                    .HasColumnName("USR_Stmppa_CAMPO");

                entity.Property(e => e.Usr_Stmppa_Idvtex).HasColumnName("USR_Stmppa_IDVTEX");

                entity.Property(e => e.Usr_Stmppa_Valor)
                    .HasColumnName("USR_Stmppa_VALOR");

                entity.Property(e => e.Usr_Stmppa_Textos)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPPA_TEXTOS");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);

                entity.Property(e => e.Sfl_TableOperation)
                  .HasMaxLength(30)
                  .IsUnicode(false)
                  .HasColumnName("Sfl_TableOperation");

                entity.Property(e => e.Sfl_LoginDateTime)
                   .HasColumnType("datetime")
                   .HasColumnName("Sfl_LoginDateTime");

            });

            modelBuilder.Entity<Usr_Stimpr_Real>(entity =>
            {
                entity.HasKey(e => new { e.Usr_Stimpr_Tippro, e.Usr_Stimpr_Artcod, e.Usr_Stimpr_Orden });

                entity.ToTable("USR_STIMPR");

                entity.Property(e => e.Usr_Stimpr_Tippro)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STIMPR_TIPPRO")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stimpr_Artcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_STIMPR_ARTCOD");

                entity.Property(e => e.Usr_Stimpr_Orden).HasColumnName("USR_STIMPR_ORDEN");

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

                entity.Property(e => e.Usr_Stimpr_Idvtex).HasColumnName("USR_STIMPR_IDVTEX");

                entity.Property(e => e.Usr_Stimpr_Imgdps)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_STIMPR_IMGDPS");

                entity.Property(e => e.Usr_Stimpr_Imggra)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_STIMPR_IMGGRA");

                entity.Property(e => e.Usr_Stimpr_Imgtok)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_STIMPR_IMGTOK");

                entity.Property(e => e.Usr_Stimpr_Pathim)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_STIMPR_PATHIM");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Usr_Stimpr>(entity =>
            {
                entity.HasKey(e => new { e.Usr_Stimpr_Tippro,e.Usr_Stimpr_Artcod,e.Usr_Stimpr_Orden });

                entity.ToTable("USR_STIMPRlog");

                entity.Property(e => e.Usr_Stimpr_Tippro)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STIMPR_TIPPRO")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stimpr_Artcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_STIMPR_ARTCOD");

                entity.Property(e => e.SKUId).HasColumnName("SKUId");

                entity.Property(e => e.Usr_Stimpr_Orden).HasColumnName("USR_STIMPR_ORDEN");

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

                entity.Property(e => e.Usr_Stimpr_Idvtex).HasColumnName("USR_STIMPR_IDVTEX");

                entity.Property(e => e.Usr_Stimpr_Imgdps)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_STIMPR_IMGDPS");

                entity.Property(e => e.Usr_Stimpr_Imggra)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_STIMPR_IMGGRA");

                entity.Property(e => e.Usr_Stimpr_Imgtok)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_STIMPR_IMGTOK");

                entity.Property(e => e.Usr_Stimpr_Pathim)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_STIMPR_PATHIM");

                entity.Property(e => e.Usr_Stimpr_Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_STIMPR_NAME");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);

                entity.Property(e => e.Sfl_TableOperation)
                  .HasMaxLength(30)
                  .IsUnicode(false)
                  .HasColumnName("Sfl_TableOperation");

                entity.Property(e => e.Sfl_LoginDateTime)
                   .HasColumnType("datetime")
                   .HasColumnName("Sfl_LoginDateTime");


            });

            modelBuilder.Entity<Usr_Prmoto_Real>(entity =>
            {
                entity.HasKey(e => e.Usr_Prmoto_Idmoto);

                entity.ToTable("USR_PRMOTO");

                entity.Property(e => e.Usr_Prmoto_Idmoto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_IDMOTO");


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

                entity.Property(e => e.Usr_Pr_Hormov)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_PR_HORMOV");


                entity.Property(e => e.Usr_Pr_Module)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_PR_MODULE");

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

                entity.Property(e => e.Usr_Prmoto_Adesde)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_ADESDE");

                entity.Property(e => e.Usr_Prmoto_Ahasta)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_AHASTA");

                entity.Property(e => e.Usr_Prmoto_Cilind)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_CILIND");

                entity.Property(e => e.Usr_Prmoto_Marca)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_MARCA");

                entity.Property(e => e.Usr_Prmoto_Modelo)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_MODELO");

                entity.Property(e => e.Usr_Prmoto_Tipmot)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_TIPMOT");

                entity.Property(e => e.Usr_Prmoto_Version)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_VERSION");


                entity.Property(e => e.Usr_Prmoto_Idvtex)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_IDVTEX");

                entity.Property(e => e.Usr_Vtex_Anohastra).HasColumnName("USR_VTEX_ANOHASTRA");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Usr_Prmoto>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("USR_PRMOTOlog");

                entity.Property(e => e.Usr_Prmoto_Idmoto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_IDMOTO");


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

                entity.Property(e => e.Usr_Prmoto_Adesde)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_ADESDE");

                entity.Property(e => e.Usr_Prmoto_Ahasta)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_AHASTA");

                entity.Property(e => e.Usr_Prmoto_Cilind)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_CILIND");

                entity.Property(e => e.Usr_Prmoto_Marca)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_MARCA");

                entity.Property(e => e.Usr_Prmoto_Modelo)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_MODELO");

                entity.Property(e => e.Usr_Prmoto_Tipmot)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_TIPMOT");

                entity.Property(e => e.Usr_Prmoto_Version)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_VERSION");

                entity.Property(e => e.Usr_Vtex_Anohastra).HasColumnName("USR_VTEX_ANOHASTRA");

                entity.Property(e => e.Usr_Vtex_Transf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEX_TRANSF")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Prmoto_Idvtex)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("USR_PRMOTO_IDVTEX")
                    .IsFixedLength(true);

                entity.Property(e => e.Sfl_TableOperation)
                  .HasMaxLength(30)
                  .IsUnicode(false)
                  .HasColumnName("Sfl_TableOperation");

                entity.Property(e => e.Sfl_LoginDateTime)
                   .HasColumnType("datetime")
                   .HasColumnName("Sfl_LoginDateTime");

            });

            modelBuilder.Entity<Sar_Fcrmvh>(entity =>
            {
                entity.HasKey(e => e.Sar_Fcrmvh_Identi);

                entity.ToTable("SAR_FCRMVH");

                entity.HasMany(e => e.Sar_Fcrmvis)
                      .WithOne(c => c.Sar_Fcrmvh)
                      .HasForeignKey(c => c.Sar_Fcrmvi_Identi);

                entity.Property(e => e.Sar_Fcrmvh_Identi)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_IDENTI");


                entity.Property(e => e.Sar_Fc_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FC_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Sar_Fc_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("SAR_FC_FECALT");

                entity.Property(e => e.Sar_Fc_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("SAR_FC_FECMOD");


                entity.Property(e => e.Sar_Fc_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FC_OALIAS");

                entity.Property(e => e.Sar_Fc_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FC_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Sar_Fc_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FC_USERID");

                entity.Property(e => e.Sar_Fcrmvh_Cambio)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("SAR_FCRMVH_CAMBIO");

                entity.Property(e => e.Sar_Fcrmvh_Camion)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_CAMION");

                entity.Property(e => e.Sar_Fcrmvh_Cirapl)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_CIRAPL");

                entity.Property(e => e.Sar_Fcrmvh_Circom)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_CIRCOM");

                entity.Property(e => e.Sar_Fcrmvh_Cntpdc)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_CNTPDC");

                entity.Property(e => e.Sar_Fcrmvh_Codemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_CODEMP");

                entity.Property(e => e.Sar_Fcrmvh_Codfcj)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_CODFCJ");

                entity.Property(e => e.Sar_Fcrmvh_Codfor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_CODFOR");

                entity.Property(e => e.Sar_Fcrmvh_Codfst)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_CODFST");

                entity.Property(e => e.Sar_Fcrmvh_Codfvt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_CODFVT");

                entity.Property(e => e.Sar_Fcrmvh_Codjob)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_CODJOB");

                entity.Property(e => e.Sar_Fcrmvh_Codlis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_CODLIS")
                    .IsFixedLength(true);

                entity.Property(e => e.Sar_Fcrmvh_Codpai)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_CODPAI");

                entity.Property(e => e.Sar_Fcrmvh_Codpos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_CODPOS");

                entity.Property(e => e.Sar_Fcrmvh_Cofdeu)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_COFDEU");

                entity.Property(e => e.Sar_Fcrmvh_Coffac)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_COFFAC");

                entity.Property(e => e.Sar_Fcrmvh_Coflis)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_COFLIS");

                entity.Property(e => e.Sar_Fcrmvh_Coniva)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_CONIVA");

                entity.Property(e => e.Sar_Fcrmvh_Deposi)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_DEPOSI");

                entity.Property(e => e.Sar_Fcrmvh_Direcc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_DIRECC");

                entity.Property(e => e.Sar_Fcrmvh_Direml)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_DIREML");

                entity.Property(e => e.Sar_Fcrmvh_Ejeaut)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_EJEAUT")
                    .IsFixedLength(true);

                entity.Property(e => e.Sar_Fcrmvh_Empfcj)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_EMPFCJ");

                entity.Property(e => e.Sar_Fcrmvh_Empfst)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_EMPFST");

                entity.Property(e => e.Sar_Fcrmvh_Empfvt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_EMPFVT");

                entity.Property(e => e.Sar_Fcrmvh_Errmsg)
                    .HasColumnType("text")
                    .HasColumnName("SAR_FCRMVH_ERRMSG");

                entity.Property(e => e.Sar_Fcrmvh_Fchmov)
                    .HasColumnType("datetime")
                    .HasColumnName("SAR_FCRMVH_FCHMOV");

                entity.Property(e => e.Sar_Fcrmvh_Genfac)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_GENFAC")
                    .IsFixedLength(true);

                entity.Property(e => e.Sar_Fcrmvh_Jurctd)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_JURCTD");

                entity.Property(e => e.Sar_Fcrmvh_Jurisd)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_JURISD");

                entity.Property(e => e.Sar_Fcrmvh_Modfcj)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_MODFCJ");

                entity.Property(e => e.Sar_Fcrmvh_Modfor)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_MODFOR");

                entity.Property(e => e.Sar_Fcrmvh_Modfst)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_MODFST");

                entity.Property(e => e.Sar_Fcrmvh_Modfvt)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_MODFVT");

                entity.Property(e => e.Sar_Fcrmvh_Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_NOMBRE");

                entity.Property(e => e.Sar_Fcrmvh_Nrocta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_NROCTA");

                entity.Property(e => e.Sar_Fcrmvh_Nrodo1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_NRODO1");

                entity.Property(e => e.Sar_Fcrmvh_Nrodo2)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_NRODO2");

                entity.Property(e => e.Sar_Fcrmvh_Nrodoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_NRODOC");

                entity.Property(e => e.Sar_Fcrmvh_Nrofcj).HasColumnName("SAR_FCRMVH_NROFCJ");

                entity.Property(e => e.Sar_Fcrmvh_Nrofor).HasColumnName("SAR_FCRMVH_NROFOR");

                entity.Property(e => e.Sar_Fcrmvh_Nrofst).HasColumnName("SAR_FCRMVH_NROFST");

                entity.Property(e => e.Sar_Fcrmvh_Nrofvt).HasColumnName("SAR_FCRMVH_NROFVT");

                entity.Property(e => e.Sar_Fcrmvh_Sector)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_SECTOR");

                entity.Property(e => e.Sar_Fcrmvh_Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_STATUS");

                entity.Property(e => e.Sar_Fcrmvh_Sucurs)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_SUCURS");

                entity.Property(e => e.Sar_Fcrmvh_Telefn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_TELEFN");

                entity.Property(e => e.Sar_Fcrmvh_Textos)
                    .HasColumnType("text")
                    .HasColumnName("SAR_FCRMVH_TEXTOS");

                entity.Property(e => e.Sar_Fcrmvh_Tipdo1)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_TIPDO1");

                entity.Property(e => e.Sar_Fcrmvh_Tipdo2)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_TIPDO2");

                entity.Property(e => e.Sar_Fcrmvh_Tracod)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_TRACOD");

                entity.Property(e => e.Sar_Fcrmvh_Tranum)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_TRANUM");

                entity.Property(e => e.Sar_Fcrmvh_Traurl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_TRAURL");

                entity.Property(e => e.Sar_Fcrmvh_Vnddor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVH_VNDDOR");
            });

            modelBuilder.Entity<Sar_Fcrmvi>(entity =>
            {
                entity.HasKey(e => new { e.Sar_Fcrmvi_Identi, e.Sar_Fcrmvi_Nroitm });

                entity.ToTable("SAR_FCRMVI");

                entity.HasOne(e => e.Sar_Fcrmvh)
                      .WithMany(c => c.Sar_Fcrmvis)
                      .HasForeignKey(c => c.Sar_Fcrmvi_Identi);

                entity.Property(e => e.Sar_Fcrmvi_Identi)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVI_IDENTI");

                entity.Property(e => e.Sar_Fcrmvi_Nroitm).HasColumnName("SAR_FCRMVI_NROITM");

                entity.Property(e => e.Sar_Fc_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FC_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Sar_Fc_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("SAR_FC_FECALT");

                entity.Property(e => e.Sar_Fc_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("SAR_FC_FECMOD");

                entity.Property(e => e.Sar_Fc_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FC_OALIAS");

                entity.Property(e => e.Sar_Fc_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FC_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Sar_Fc_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FC_USERID");

                entity.Property(e => e.Sar_Fcrmvi_Artcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVI_ARTCOD");

                entity.Property(e => e.Sar_Fcrmvi_Cantid)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("SAR_FCRMVI_CANTID");

                entity.Property(e => e.Usr_Fcrmvi_Bonice)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("USR_FCRMVI_BONICE");
                entity.Property(e => e.Usr_Fcrmvi_Coecar)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("USR_FCRMVI_COECAR");

                entity.Property(e => e.Usr_Fcrmvi_Prevtx)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("USR_FCRMVI_PREVTX");

                entity.Property(e => e.Sar_Fcrmvi_Codapl)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVI_CODAPL")
                    .IsFixedLength(true);

                entity.Property(e => e.Sar_Fcrmvi_Codcpt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVI_CODCPT");

                entity.Property(e => e.Sar_Fcrmvi_Empapl)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVI_EMPAPL");

                entity.Property(e => e.Sar_Fcrmvi_Itmapl).HasColumnName("SAR_FCRMVI_ITMAPL");

                entity.Property(e => e.Sar_Fcrmvi_Modapl)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVI_MODAPL");

                entity.Property(e => e.Sar_Fcrmvi_Nroapl).HasColumnName("SAR_FCRMVI_NROAPL");

                entity.Property(e => e.Sar_Fcrmvi_Pctbf1)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("SAR_FCRMVI_PCTBF1");

                entity.Property(e => e.Sar_Fcrmvi_Pctbf2)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("SAR_FCRMVI_PCTBF2");

                entity.Property(e => e.Sar_Fcrmvi_Pctbf3)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("SAR_FCRMVI_PCTBF3");

                entity.Property(e => e.Sar_Fcrmvi_Precio)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("SAR_FCRMVI_PRECIO");

                entity.Property(e => e.Sar_Fcrmvi_Tipcpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVI_TIPCPT")
                    .IsFixedLength(true);

                entity.Property(e => e.Sar_Fcrmvi_Tippro)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVI_TIPPRO")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Fcrmvi_Origen)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVI_ORIGEN");

                entity.Property(e => e.Usr_Fcrmvi_Deposi)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVI_DEPOSI");

                entity.Property(e => e.Usr_Fcrmvi_Sector)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVI_SECTOR");

                entity.Property(e => e.Usr_Fcrmvi_Selsla)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVI_SELSLA");
            });

            modelBuilder.Entity<Sar_Fcrmvt>(entity =>
            {
                entity.HasKey(e => new { e.Sar_Fcrmvt_Identi, e.Sar_Fcrmvt_Nroitm });

                entity.ToTable("SAR_FCRMVT");

                entity.Property(e => e.Sar_Fcrmvt_Identi)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVT_IDENTI");

                entity.Property(e => e.Sar_Fcrmvt_Nroitm).HasColumnName("SAR_FCRMVT_NROITM");

                entity.Property(e => e.Sar_Fc_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FC_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Sar_Fc_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("SAR_FC_FECALT");

                entity.Property(e => e.Sar_Fc_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("SAR_FC_FECMOD");


                entity.Property(e => e.Sar_Fc_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FC_OALIAS");

                entity.Property(e => e.Sar_Fc_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FC_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Sar_Fc_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FC_USERID");

                entity.Property(e => e.Sar_Fcrmvt_Cambio)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("SAR_FCRMVT_CAMBIO");

                entity.Property(e => e.Sar_Fcrmvt_Catego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVT_CATEGO");

                entity.Property(e => e.Sar_Fcrmvt_Cheque).HasColumnName("SAR_FCRMVT_CHEQUE");

                entity.Property(e => e.Sar_Fcrmvt_Chesuc).HasColumnName("SAR_FCRMVT_CHESUC");

                entity.Property(e => e.Sar_Fcrmvt_Clring).HasColumnName("SAR_FCRMVT_CLRING");

                entity.Property(e => e.Sar_Fcrmvt_Codbco)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVT_CODBCO");

                entity.Property(e => e.Sar_Fcrmvt_Codcpt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVT_CODCPT");

                entity.Property(e => e.Sar_Fcrmvt_Docfir)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVT_DOCFIR");

                entity.Property(e => e.Sar_Fcrmvt_Fchvnc)
                    .HasColumnType("datetime")
                    .HasColumnName("SAR_FCRMVT_FCHVNC");

                entity.Property(e => e.Sar_Fcrmvt_Import)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("SAR_FCRMVT_IMPORT");

                entity.Property(e => e.Sar_Fcrmvt_Impuss)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("SAR_FCRMVT_IMPUSS");

                entity.Property(e => e.Sar_Fcrmvt_Monext)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVT_MONEXT");

                entity.Property(e => e.Sar_Fcrmvt_Nroint).HasColumnName("SAR_FCRMVT_NROINT");

                entity.Property(e => e.Sar_Fcrmvt_Textos)
                    .HasColumnType("text")
                    .HasColumnName("SAR_FCRMVT_TEXTOS");

                entity.Property(e => e.Sar_Fcrmvt_Tipcpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SAR_FCRMVT_TIPCPT")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Usr_Vtexha>(entity =>
            {
                entity.HasKey(e => e.Usr_Vtexha_Ordid);

                entity.ToTable("USR_VTEXHA");

                entity.Property(e => e.Usr_Vtexha_Ordid)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEXHA_ORDID");

                entity.Property(e => e.Usr_Vt_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VT_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vt_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_VT_FECALT");

                entity.Property(e => e.Usr_Vt_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_VT_FECMOD");

                entity.Property(e => e.Usr_Vt_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_VT_OALIAS");

                entity.Property(e => e.Usr_Vt_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VT_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Vt_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_VT_USERID");

                entity.Property(e => e.Usr_Vtexha_Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTEXHA_STATUS")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Usr_Dscont>(entity =>
            {
                entity.HasKey(e => e.Usr_Dscont_DspemlId);

                entity.ToTable("USR_DSCONT");

                entity.HasOne(e => e.Header)
                      .WithMany(c => c.Contacts)
                      .HasForeignKey(c => c.Usr_Dscont_DspemlId);

                entity.Property(e => e.Usr_Dscont_DspemlId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_DSPEML_ID");


                entity.Property(e => e.Usr_Ds_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Ds_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_DS_FECALT");

                entity.Property(e => e.Usr_Ds_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_DS_FECMOD");
                entity.Property(e => e.Usr_Ds_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_OALIAS");

                entity.Property(e => e.Usr_Ds_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Ds_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_USERID");

                entity.Property(e => e.Usr_Dscont_Addnot)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_ADDNOT");

                entity.Property(e => e.Usr_Dscont_City)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_CITY");

                entity.Property(e => e.Usr_Dscont_Id)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_ID");

                entity.Property(e => e.Usr_Dscont_Mail)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_MAIL");

                entity.Property(e => e.Usr_Dscont_Name)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_NAME");

                entity.Property(e => e.Usr_Dscont_Person)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_PERSON");

                entity.Property(e => e.Usr_Dscont_Phonen)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_PHONEN");

                entity.Property(e => e.Usr_Dscont_Proapp)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_PROAPP");

                entity.Property(e => e.Usr_Dscont_Proini)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_PROINI");

                entity.Property(e => e.Usr_Dscont_State)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_STATE");

                entity.Property(e => e.Usr_Dscont_Strenu)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_STRENU");

                entity.Property(e => e.Usr_Dscont_Stretn)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_STRETN");

                entity.Property(e => e.Usr_Dscont_Taxid)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_TAXID");

                entity.Property(e => e.Usr_Dscont_Type)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_TYPE");

                entity.Property(e => e.Usr_Dscont_Zipcod)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_ZIPCOD");


                entity.Property(e => e.Usr_Dscont_Tipdoc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_TIPDOC");


                entity.Property(e => e.Usr_Dscont_Nrodoc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_NRODOC");

                entity.Property(e => e.Usr_Dscont_Cndiva)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSCONT_CNDIVA");
            });

            modelBuilder.Entity<Usr_Dspaym>(entity =>
            {
                entity.HasKey(e => new { e.Usr_Dspaym_DspemlId, e.Usr_Dspaym_Inteid });

                entity.ToTable("USR_DSPAYM");

                entity.HasOne(e => e.Header)
                      .WithMany(c => c.Payments)
                      .HasForeignKey(c => c.Usr_Dspaym_DspemlId);

                entity.Property(e => e.Usr_Dspaym_DspemlId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPAYM_DSPEML_ID");

                entity.Property(e => e.Usr_Dspaym_Inteid)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPAYM_INTEID");

                entity.Property(e => e.Usr_Ds_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Ds_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_DS_FECALT");

                entity.Property(e => e.Usr_Ds_Fecmod)
                    .HasColumnType("datetime");

                entity.Property(e => e.Usr_Ds_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_OALIAS");

                entity.Property(e => e.Usr_Ds_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Ds_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_USERID");

                entity.Property(e => e.Usr_Dspaym_Amount)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("USR_DSPAYM_AMOUNT");

                entity.Property(e => e.Usr_Dspaym_Date)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_DSPAYM_DATE");

                entity.Property(e => e.Usr_Dspaym_Instal).HasColumnName("USR_DSPAYM_INSTAL");

                entity.Property(e => e.Usr_Dspaym_Method)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPAYM_METHOD");

                entity.Property(e => e.Usr_Dspaym_Notes)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPAYM_NOTES");

                entity.Property(e => e.Usr_Dspaym_Status)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPAYM_STATUS");

                entity.Property(e => e.Usr_Dspaym_Trafee)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("USR_DSPAYM_TRAFEE");
            });

            modelBuilder.Entity<Usr_Dspeml>(entity =>
            {
                entity.ToTable("USR_DSPEML");

                entity.HasKey(e => new { e.Usr_Dspeml_Id});


                entity.HasMany(e => e.Contacts)
                      .WithOne(c => c.Header)
                      .HasForeignKey(c => c.Usr_Dscont_DspemlId);
                
                entity.HasMany(e => e.Payments)
                      .WithOne(c => c.Header)
                      .HasForeignKey(c => c.Usr_Dspaym_DspemlId);

                entity.HasMany(e => e.ShippingData)
                      .WithOne(c => c.Header)
                      .HasForeignKey(c => c.Usr_Dsship_DspemlId);

                entity.Property(e => e.Usr_Dspeml_Id)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_ID");

                entity.Property(e => e.Usr_Ds_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Ds_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_DS_FECALT");

                entity.Property(e => e.Usr_Ds_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_DS_FECMOD");


                entity.Property(e => e.Usr_Ds_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_OALIAS");

                entity.Property(e => e.Usr_Ds_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Ds_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_USERID");

                entity.Property(e => e.Usr_Dspeml_Amount)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("USR_DSPEML_AMOUNT");

                entity.Property(e => e.Usr_Dspeml_Cenvin)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("USR_DSPEML_CENVIN");

                entity.Property(e => e.Usr_Dspeml_Channe).HasColumnName("USR_DSPEML_CHANNE");

                entity.Property(e => e.Usr_Dspeml_Codfor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_CODFOR");

                entity.Property(e => e.Usr_Dspeml_Curren)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_CURREN");

                entity.Property(e => e.Usr_Dspeml_Delffs)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_DELFFS");

                entity.Property(e => e.Usr_Dspeml_Delmet)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_DELMET");

                entity.Property(e => e.Usr_Dspeml_Delsta)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_DELSTA");

                entity.Property(e => e.Usr_Dspeml_Fchmov)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_DSPEML_FCHMOV");

                entity.Property(e => e.Usr_Dspeml_Iscanc)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_ISCANC");

                entity.Property(e => e.Usr_Dspeml_Isopen)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_ISOPEN");

                entity.Property(e => e.Usr_Dspeml_Modfor)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_MODFOR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Dspeml_Nrocta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_NROCTA");

                entity.Property(e => e.Usr_Dspeml_Nrofor).HasColumnName("USR_DSPEML_NROFOR");

                entity.Property(e => e.Usr_Dspeml_Origen)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_ORIGEN");

                entity.Property(e => e.Usr_Dspeml_Paprov)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("USR_DSPEML_PAPROV");

                entity.Property(e => e.Usr_Dspeml_Payffs)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_PAYFFS");

                entity.Property(e => e.Usr_Dspeml_Paysta)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_PAYSTA");

                entity.Property(e => e.Usr_Dspeml_Payter)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_PAYTER");

                entity.Property(e => e.Usr_Dspeml_Pdtusr)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_PDTUSR");

                entity.Property(e => e.Usr_Dspeml_Prceti)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_PRCETI");

                entity.Property(e => e.Usr_Dspeml_Prcint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_PRCINT");

                entity.Property(e => e.Usr_Dspeml_Shicos)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("USR_DSPEML_SHICOS");

                entity.Property(e => e.Usr_Dspeml_Wareho)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSPEML_WAREHO");
            });

            modelBuilder.Entity<Usr_Dsship>(entity =>
            {
                entity.HasKey(e => new { e.Usr_Dsship_DspemlId, e.Usr_Dsship_Trackn });

                entity.ToTable("USR_DSSHIP");

                entity.HasOne(e => e.Header)
                      .WithMany(c => c.ShippingData)
                      .HasForeignKey(c => c.Usr_Dsship_DspemlId);

                entity.Property(e => e.Usr_Dsship_DspemlId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSSHIP_DSPEML_ID");

                entity.Property(e => e.Usr_Dsship_Trackn)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSSHIP_TRACKN");

                entity.Property(e => e.Usr_Ds_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Ds_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_DS_FECALT");

                entity.Property(e => e.Usr_Ds_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_DS_FECMOD");


                entity.Property(e => e.Usr_Ds_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_OALIAS");

                entity.Property(e => e.Usr_Ds_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Ds_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USR_DS_USERID");

                entity.Property(e => e.Usr_Dsship_Courie)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_DSSHIP_COURIE");

                entity.Property(e => e.Usr_Dsship_Lblurl)
                    .HasColumnType("text")
                    .HasColumnName("USR_DSSHIP_LBLURL");

                entity.Property(e => e.Usr_Dsship_Traurl)
                    .HasColumnType("text")
                    .HasColumnName("USR_DSSHIP_TRAURL");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
