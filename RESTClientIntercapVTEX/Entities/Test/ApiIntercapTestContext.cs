using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RESTClientIntercapVTEX.Entities;

#nullable disable

namespace RESTClientIntercapVTEX.Entities.Test
{
    public partial class ApiIntercapTestContext : DbContext
    {
        public ApiIntercapTestContext()
        {
        }

        public ApiIntercapTestContext(DbContextOptions<ApiIntercapTestContext> options)
            : base(options)
        {
        }

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

                entity.Property(e => e.Usr_Fcrmvi_Prevtx)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("USR_FCRMVI_PREVTX");

                entity.Property(e => e.Usr_Fcrmvi_Bonice)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("USR_FCRMVI_BONICE");
                entity.Property(e => e.Usr_Fcrmvi_Coecar)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("USR_FCRMVI_COECAR");

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
