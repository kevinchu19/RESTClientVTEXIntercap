using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public virtual DbSet<Stmpdh> Stmpdhs { get; set; }
        public virtual DbSet<Usr_Pratri> Usr_Pratri { get; set; }
        public virtual DbSet<Usr_Sttcas> Usr_Sttcas { get; set; }
        public virtual DbSet<Usr_Sttcaa> Usr_Sttcaa { get; set; }
        public virtual DbSet<Usr_Sttcah> Usr_Sttcah { get; set; }
        public virtual DbSet<Usr_Sttcai> Usr_Sttcai { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Stmpdh>(entity =>
            {
                entity.HasKey(e => new { e.Stmpdh_Tippro, e.Stmpdh_Artcod });

                entity.ToTable("STMPDH");

                entity.HasIndex(e => new { e.Stmpdh_Tipprq, e.Stmpdh_Artcoq }, "M_GR_FCRMVH");

                entity.HasIndex(e => new { e.Stmpdh_Argcos, e.Stmpdh_Tippro, e.Stmpdh_Artcod }, "P_ST_STTEVHWIZ");

                entity.HasIndex(e => new { e.Stmpdh_Artcod, e.Stmpdh_Descrp }, "STMPDH_SuperFind");

                entity.HasIndex(e => e.Stmpdh_Gasimp, "W_CO_CORMVZ");

                entity.HasIndex(e => new { e.Stmpdh_Tippro, e.Stmpdh_Artcod, e.Stmpdh_Pctcfv }, "W_GR_FCRMVH");

                entity.Property(e => e.Stmpdh_Tippro)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_TIPPRO")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Artcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_ARTCOD");

                entity.Property(e => e.Stmpdh_Agrump)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_AGRUMP");

                entity.Property(e => e.Stmpdh_Apltot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_APLTOT")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Argcos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_ARGCOS");

                entity.Property(e => e.Stmpdh_Artcoq)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_ARTCOQ");

                entity.Property(e => e.Stmpdh_Artdis)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_ARTDIS");

                entity.Property(e => e.Stmpdh_Artfam)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_ARTFAM");

                entity.Property(e => e.Stmpdh_Bieuso)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_BIEUSO")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Bmpbmp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_BMPBMP");

                entity.Property(e => e.Stmpdh_Clasar)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_CLASAR");

                entity.Property(e => e.Stmpdh_Clasif)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_CLASIF");

                entity.Property(e => e.Stmpdh_Cnmman)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_CNMMAN")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Cntlic).HasColumnName("STMPDH_CNTLIC");

                entity.Property(e => e.Stmpdh_Cntlin).HasColumnName("STMPDH_CNTLIN");

                entity.Property(e => e.Stmpdh_Codcpc)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_CODCPC");

                entity.Property(e => e.Stmpdh_Codcpt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_CODCPT");

                entity.Property(e => e.Stmpdh_Codfam)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_CODFAM");

                entity.Property(e => e.Stmpdh_Codmer)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_CODMER");

                entity.Property(e => e.Stmpdh_Codmtx)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_CODMTX");

                entity.Property(e => e.Stmpdh_Codreg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_CODREG");

                entity.Property(e => e.Stmpdh_Codsec)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_CODSEC");

                entity.Property(e => e.Stmpdh_Comori)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_COMORI");

                entity.Property(e => e.Stmpdh_Ctrlbc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_CTRLBC")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Ctrlbf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_CTRLBF")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Cuenpv)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_CUENPV");

                entity.Property(e => e.Stmpdh_Cuenvt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_CUENVT");

                entity.Property(e => e.Stmpdh_Ddeprd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DDEPRD");

                entity.Property(e => e.Stmpdh_Dderef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DDEREF");

                entity.Property(e => e.Stmpdh_Dderep)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DDEREP");

                entity.Property(e => e.Stmpdh_Ddeuco)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DDEUCO");

                entity.Property(e => e.Stmpdh_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Defatr)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DEFATR");

                entity.Property(e => e.Stmpdh_Defdes)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DEFDES");

                entity.Property(e => e.Stmpdh_Defenv)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DEFENV");

                entity.Property(e => e.Stmpdh_Defest)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DEFEST");

                entity.Property(e => e.Stmpdh_Deffec)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DEFFEC");

                entity.Property(e => e.Stmpdh_Defotr)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DEFOTR");

                entity.Property(e => e.Stmpdh_Defser)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DEFSER");

                entity.Property(e => e.Stmpdh_Defubi)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DEFUBI");

                entity.Property(e => e.Stmpdh_Descar)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DESCAR")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Descrp)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_DESCRP");

                entity.Property(e => e.Stmpdh_Diaent).HasColumnName("STMPDH_DIAENT");

                entity.Property(e => e.Stmpdh_Edcaco)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_EDCACO")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Edcafc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_EDCAFC")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Edcoco)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_EDCOCO")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Edcofc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_EDCOFC")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Estamo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_ESTAMO")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Expres)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_EXPRES");

                entity.Property(e => e.Stmpdh_Facaco)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("STMPDH_FACACO");

                entity.Property(e => e.Stmpdh_Facalt)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("STMPDH_FACALT");

                entity.Property(e => e.Stmpdh_Faccco)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("STMPDH_FACCCO");

                entity.Property(e => e.Stmpdh_Faccon)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("STMPDH_FACCON");

                entity.Property(e => e.Stmpdh_Facfac)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("STMPDH_FACFAC");

                entity.Property(e => e.Stmpdh_Facfco)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("STMPDH_FACFCO");

                entity.Property(e => e.Stmpdh_Facsec)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("STMPDH_FACSEC");

                entity.Property(e => e.Stmpdh_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("STMPDH_FECALT");

                entity.Property(e => e.Stmpdh_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("STMPDH_FECMOD");

                entity.Property(e => e.Stmpdh_Fecprd)
                    .HasColumnType("datetime")
                    .HasColumnName("STMPDH_FECPRD");

                entity.Property(e => e.Stmpdh_Fecref)
                    .HasColumnType("datetime")
                    .HasColumnName("STMPDH_FECREF");

                entity.Property(e => e.Stmpdh_Fecrep)
                    .HasColumnType("datetime")
                    .HasColumnName("STMPDH_FECREP");

                entity.Property(e => e.Stmpdh_Fecuco)
                    .HasColumnType("datetime")
                    .HasColumnName("STMPDH_FECUCO");

                entity.Property(e => e.Stmpdh_Formco)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_FORMCO");

                entity.Property(e => e.Stmpdh_Formfc)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_FORMFC");

                entity.Property(e => e.Stmpdh_Gasimp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_GASIMP")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Habime)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_HABIME")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Habret)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_HABRET")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Indcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_INDCOD");

                entity.Property(e => e.Stmpdh_Kitsco)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_KITSCO")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Kitsfc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_KITSFC")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Lotcpa)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_LOTCPA");

                entity.Property(e => e.Stmpdh_Lotfab)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_LOTFAB");


                entity.Property(e => e.Stmpdh_Lotprd).HasColumnName("STMPDH_LOTPRD");


                entity.Property(e => e.Stmpdh_Lotref).HasColumnName("STMPDH_LOTREF");

                entity.Property(e => e.Stmpdh_Lotrep).HasColumnName("STMPDH_LOTREP");

                entity.Property(e => e.Stmpdh_Lotuco).HasColumnName("STMPDH_LOTUCO");

                entity.Property(e => e.Stmpdh_Masclp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_MASCLP");

                entity.Property(e => e.Stmpdh_Maxsec)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("STMPDH_MAXSEC");

                entity.Property(e => e.Stmpdh_Metpro)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_METPRO");

                entity.Property(e => e.Stmpdh_Minsec)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("STMPDH_MINSEC");

                entity.Property(e => e.Stmpdh_Modcpc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_MODCPC");

                entity.Property(e => e.Stmpdh_Modcpt)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_MODCPT");

                entity.Property(e => e.Stmpdh_Mongas)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_MONGAS");

                entity.Property(e => e.Stmpdh_Monprd)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_MONPRD");

                entity.Property(e => e.Stmpdh_Monref)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_MONREF");

                entity.Property(e => e.Stmpdh_Monrep)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_MONREP");

                entity.Property(e => e.Stmpdh_Monuco)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_MONUCO");

                entity.Property(e => e.Stmpdh_Nomcot)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_NOMCOT");

                entity.Property(e => e.Stmpdh_Nvrpre)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_NVRPRE")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_OALIAS");

                entity.Property(e => e.Stmpdh_Observ)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_OBSERV");

                entity.Property(e => e.Stmpdh_Oleole)
                    .HasColumnType("text")
                    .HasColumnName("STMPDH_OLEOLE");

                entity.Property(e => e.Stmpdh_Pctcfc)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_PCTCFC");

                entity.Property(e => e.Stmpdh_Pctcfv)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_PCTCFV");

                entity.Property(e => e.Stmpdh_Pesctr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_PESCTR")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Pesfac)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_PESFAC");

                entity.Property(e => e.Stmpdh_Pesmax)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_PESMAX");

                entity.Property(e => e.Stmpdh_Pesmin)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_PESMIN");

                entity.Property(e => e.Stmpdh_Pesuni)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_PESUNI")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Pocosto)
                    .HasColumnType("numeric(20, 8)")
                    .HasColumnName("STMPDH_POCOSTO");

                entity.Property(e => e.Stmpdh_Porboc)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_PORBOC");

                entity.Property(e => e.Stmpdh_Porbof)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_PORBOF");

                entity.Property(e => e.Stmpdh_Preprd)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("STMPDH_PREPRD");

                entity.Property(e => e.Stmpdh_Preref)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("STMPDH_PREREF");

                entity.Property(e => e.Stmpdh_Prerep)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("STMPDH_PREREP");

                entity.Property(e => e.Stmpdh_Preuco)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("STMPDH_PREUCO");

                entity.Property(e => e.Stmpdh_Prmipr)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_PRMIPR");

                entity.Property(e => e.Stmpdh_Prmxpr)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_PRMXPR");

                entity.Property(e => e.Stmpdh_Prove1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_PROVE1");

                entity.Property(e => e.Stmpdh_Prove2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_PROVE2");

                entity.Property(e => e.Stmpdh_Ptoped)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("STMPDH_PTOPED");

                entity.Property(e => e.Stmpdh_Recalc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_RECALC")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Refsec)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("STMPDH_REFSEC");

                entity.Property(e => e.Stmpdh_Rubr01)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_RUBR01");

                entity.Property(e => e.Stmpdh_Rubr02)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_RUBR02");

                entity.Property(e => e.Stmpdh_Rubr03)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_RUBR03");

                entity.Property(e => e.Stmpdh_Rubr04)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_RUBR04");

                entity.Property(e => e.Stmpdh_Rubr05)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_RUBR05");

                entity.Property(e => e.Stmpdh_Rubr06)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_RUBR06");

                entity.Property(e => e.Stmpdh_Rubr07)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_RUBR07");

                entity.Property(e => e.Stmpdh_Rubr08)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_RUBR08");

                entity.Property(e => e.Stmpdh_Rubr09)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_RUBR09");

                entity.Property(e => e.Stmpdh_Rubr10)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_RUBR10");

                entity.Property(e => e.Stmpdh_Simuco)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_SIMUCO")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Simufc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_SIMUFC")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Simupd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_SIMUPD")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Stkmax)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("STMPDH_STKMAX");

                entity.Property(e => e.Stmpdh_Stkmin)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("STMPDH_STKMIN");

                entity.Property(e => e.Stmpdh_Textos)
                    .HasColumnType("text")
                    .HasColumnName("STMPDH_TEXTOS");

                entity.Property(e => e.Stmpdh_Tipcpc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_TIPCPC")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Tipcpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_TIPCPT")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Tipfam)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_TIPFAM")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Tipgas)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_TIPGAS");

                entity.Property(e => e.Stmpdh_Tipprq)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_TIPPRQ")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Tlcalt)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_TLCALT");

                entity.Property(e => e.Stmpdh_Tlccon)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_TLCCON");

                entity.Property(e => e.Stmpdh_Tlcfac)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_TLCFAC");

                entity.Property(e => e.Stmpdh_Tlfalt)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_TLFALT");

                entity.Property(e => e.Stmpdh_Tlfcon)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_TLFCON");

                entity.Property(e => e.Stmpdh_Tlffac)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_TLFFAC");

                entity.Property(e => e.Stmpdh_Tolcom)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_TOLCOM");

                entity.Property(e => e.Stmpdh_Tolpro)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_TOLPRO");

                entity.Property(e => e.Stmpdh_Tolven)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("STMPDH_TOLVEN");

                entity.Property(e => e.Stmpdh_Trazab)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_TRAZAB")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Ultniv).HasColumnName("STMPDH_ULTNIV");

                entity.Property(e => e.Stmpdh_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Stmpdh_Uniaco)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_UNIACO");

                entity.Property(e => e.Stmpdh_Unialt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_UNIALT");

                entity.Property(e => e.Stmpdh_Unicco)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_UNICCO");

                entity.Property(e => e.Stmpdh_Unicon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_UNICON");

                entity.Property(e => e.Stmpdh_Unifac)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_UNIFAC");

                entity.Property(e => e.Stmpdh_Unifco)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_UNIFCO");

                entity.Property(e => e.Stmpdh_Unimed)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_UNIMED");

                entity.Property(e => e.Stmpdh_Unimtx).HasColumnName("STMPDH_UNIMTX");

                entity.Property(e => e.Stmpdh_Unipes)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_UNIPES");

                entity.Property(e => e.Stmpdh_Unisec)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_UNISEC");

                entity.Property(e => e.Stmpdh_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("STMPDH_USERID");

                entity.Property(e => e.Stmpdh_Utilid)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("STMPDH_UTILID");

                entity.Property(e => e.Stmpdh_Volume)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("STMPDH_VOLUME");

                entity.Property(e => e.Usr_Stmpdh_Archft)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_ARCHFT");

                entity.Property(e => e.Usr_Stmpdh_Catego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_CATEGO");

                entity.Property(e => e.Usr_Stmpdh_Certif)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_CERTIF");

                entity.Property(e => e.Usr_Stmpdh_Chasin)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_CHASIN");

                entity.Property(e => e.Usr_Stmpdh_Conapl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_CONAPL");

                entity.Property(e => e.Usr_Stmpdh_Conimg)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_CONIMG");

                entity.Property(e => e.Usr_Stmpdh_Consug)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_CONSUG");

                entity.Property(e => e.Usr_Stmpdh_Consus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_CONSUS");

                entity.Property(e => e.Usr_Stmpdh_Convid)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_CONVID");

                entity.Property(e => e.Usr_Stmpdh_Cosmkt)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("USR_STMPDH_COSMKT");

                entity.Property(e => e.Usr_Stmpdh_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_DEPTOS");

                entity.Property(e => e.Usr_Stmpdh_Desimp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_DESIMP");

                entity.Property(e => e.Usr_Stmpdh_Exacsm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_EXACSM")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpdh_Iddrop)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("USR_STMPDH_IDDROP");

                entity.Property(e => e.Usr_Stmpdh_Imgchi)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_IMGCHI");

                entity.Property(e => e.Usr_Stmpdh_Imggra)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_IMGGRA");

                entity.Property(e => e.Usr_Stmpdh_Import)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_IMPORT")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpdh_Inclve)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_INCLVE")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpdh_Interv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_INTERV");

                entity.Property(e => e.Usr_Stmpdh_Intnet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_INTNET")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpdh_Limcnt)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_LIMCNT")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpdh_Nropar)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_NROPAR");

                entity.Property(e => e.Usr_Stmpdh_Pddrop)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("USR_STMPDH_PDDROP");

                entity.Property(e => e.Usr_Stmpdh_Pnuevo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_PNUEVO")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpdh_Porgim)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("USR_STMPDH_PORGIM");

                entity.Property(e => e.Usr_Stmpdh_Posara)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_POSARA");

                entity.Property(e => e.Usr_Stmpdh_Prdped)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_PRDPED")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Stmpdh_Smin40)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("USR_STMPDH_SMIN40");

                entity.Property(e => e.Usr_Stmpdh_Subcat)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_SUBCAT");

                entity.Property(e => e.Usr_Stmpdh_Tipdis)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_TIPDIS");

                entity.Property(e => e.Usr_Stmpdh_Varpre)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_VARPRE");

                entity.Property(e => e.Usr_Stmpdh_Videop)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("USR_STMPDH_VIDEOP");
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
                entity.HasKey(e => new { e.Usr_Sttcas_Deptos, e.Usr_Sttcas_Catego, e.Usr_Sttcas_Subcat });

                entity.ToTable("USR_STTCAS");

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
            });

            modelBuilder.Entity<Usr_Sttcaa>(entity =>
            {
                entity.HasKey(e => new { e.Usr_Sttcaa_Deptos, e.Usr_Sttcaa_Codatr });

                entity.ToTable("USR_STTCAA");

                entity.Property(e => e.Usr_Sttcaa_Deptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAA_DEPTOS");

                entity.Property(e => e.Usr_Sttcaa_Codatr)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USR_STTCAA_CODATR");
            
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

            });

            modelBuilder.Entity<Usr_Sttcah>(entity =>
            {
                entity.HasKey(e => e.Usr_Sttcah_Deptos);

                entity.ToTable("USR_STTCAH");

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
            });

            modelBuilder.Entity<Usr_Sttcai>(entity =>
            {
                entity.HasKey(e => new { e.Usr_Sttcai_Deptos, e.Usr_Sttcai_Catego });

                entity.ToTable("USR_STTCAI");

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

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
