using E_Tests.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Tests.Data
{
    public class ApplicationDbContext : IdentityDbContext<EtestUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<QuestionInTest> QuestionInTests { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Question>()
              .Property(z => z.id)
              .ValueGeneratedOnAdd();

            builder.Entity<Results>()
              .Property(z => z.id)
              .ValueGeneratedOnAdd();



            //question in test
            builder.Entity<QuestionInTest>()
               .HasKey(z => new { z.questionId, z.testId });
            //
            builder.Entity<QuestionInTest>()
               .HasOne(z => z.question)
               .WithMany(z => z.Tests)
               .HasForeignKey(z => z.questionId);

            builder.Entity<QuestionInTest>()
                .HasOne(z => z.test)
                .WithMany(z => z.Questions)
                .HasForeignKey(z => z.testId);

            builder.Entity<Test>()
               .HasOne<EtestUser>(z => z.user)
               .WithMany(z => z.Tests);



        }
       
       
        
        
    }
}
