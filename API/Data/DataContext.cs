using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        //numele tabelei
        //public DbSet<AppAngajat> Detalii_Angajat { get; set; }
        public DbSet<AppManageri> Manageri { get; set; }
        public DbSet<AppAngajati> Angajati { get; set; }
        public DbSet<AppPerioadaEvaluare> PerioadaEvaluare { get; set; }
        public DbSet<AppDenumireTabeleTemplate> DenumireTabeleTemplate { get; set; }
        public DbSet<AppDenumireCampuriTemplate> DenumireCampuriTemplate { get; set; }
        public DbSet<AppNote> Note { get; set; }
        
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //relatia dintre AppAngajat si AppManager
            modelBuilder.Entity<AppAngajati>()
                .HasOne(b => b.AppManageri)
                .WithMany(i => i.Angajati)
                .HasForeignKey(b => b.ManagerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppAngajati>((angajat) =>
            {
                angajat.HasKey(I => I.AngajatId);
                angajat.Property(P => P.AngajatNume).IsRequired().HasMaxLength(200);
                angajat.Property(P => P.ManagerId).IsRequired();
                
                angajat.HasIndex(P => P.AngajatNume);
                angajat.HasIndex(P => P.ManagerId);
            });


            modelBuilder.Entity<AppPerioadaEvaluare>()
                .HasOne(b => b.AppAngajati)
                .WithMany(i => i.PerioadaEvaluare)
                .HasForeignKey(b => b.AngajatId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppPerioadaEvaluare>((perioadaevaluare) =>
            {
                perioadaevaluare.HasKey(I => I.Id);
                perioadaevaluare.Property(P => P.Perioada_evaluare_start).IsRequired();
                perioadaevaluare.Property(P => P.Perioada_evaluare_end).IsRequired();
                perioadaevaluare.Property(P => P.AngajatId).IsRequired();
                perioadaevaluare.Property(P => P.NoteId).IsRequired();
                perioadaevaluare.Property(P => P.DenumireTabeleTemplateId).IsRequired();
                
                perioadaevaluare.HasIndex(P => P.Perioada_evaluare_start);
                perioadaevaluare.HasIndex(P => P.Perioada_evaluare_end);
                perioadaevaluare.HasIndex(P => P.AngajatId);
                perioadaevaluare.HasIndex(P => P.NoteId);
                perioadaevaluare.HasIndex(P => P.DenumireTabeleTemplateId);
            });


            modelBuilder.Entity<AppDenumireTabeleTemplate>()
                .HasOne(b => b.AppPerioadaEvaluare)
                .WithOne(i => i.DenumireTabeleTemplate)
                .HasForeignKey<AppPerioadaEvaluare>(f => f.DenumireTabeleTemplateId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<AppDenumireTabeleTemplate>((denumiretabeletemplate) =>
            {
                denumiretabeletemplate.HasKey(I => I.Id);
                denumiretabeletemplate.Property(P => P.Denumire_tabele).IsRequired();
                
                denumiretabeletemplate.HasIndex(P => P.Denumire_tabele);
            });

           
           modelBuilder.Entity<AppNote>()
                .HasOne(b => b.AppPerioadaEvaluare)
                .WithOne(i => i.Note)
                .HasForeignKey<AppPerioadaEvaluare>(f => f.NoteId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<AppNote>((note) =>
            {
                note.HasKey(I => I.Id);
                note.Property(P => P.Nota).IsRequired();
                
                note.HasIndex(P => P.Nota);
            });


            modelBuilder.Entity<AppDenumireCampuriTemplate>()
                .HasOne(b => b.AppDenumireTabeleTemplate)
                .WithMany(i => i.DenumireCampuriTemplate)
                .HasForeignKey(f => f.DenumireTabeleTemplateId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<AppDenumireCampuriTemplate>((denumirecampuritemplate) =>
            {
                denumirecampuritemplate.HasKey(I => I.Id);
                denumirecampuritemplate.Property(P => P.Denumire_campuri).IsRequired();
                
                denumirecampuritemplate.HasIndex(P => P.Denumire_campuri);
            });
   
/*
            ////relatia dintre AppProductivitate si AppAngajat
            modelBuilder.Entity<AppAngajat>()
                .HasMany(i => i.Productivitate)
                .WithOne()
                .HasForeignKey(b => b.AppAngajat);
/*
            modelBuilder.Entity<AppProductivitate>()
                .WithMany(b => b.Author)
                .HasForeignKey<AuthorBiography>(b => b.AuthorRef);

/*
            modelBuilder.Entity<AppProductivitate>()
                .HasOne(b => b.AppAngajat)
                .WithMany(i => i.Productivitate)
                .HasForeignKey(b => b.AppAngajatId)
                .OnDelete(DeleteBehavior.Cascade);
*/

            /*//daca vreau sa modifici structura unei tabele
             modelBuilder.Entity<AppProductivitate>()
                    .Property(p => p.DateOfBirth)
                    .HasColumnName("DoB")
                    .HasColumnOrder(3)
                    .HasColumnType("datetime2");
            */
        }
    }
}