using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reeduca.Infra.Context
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
        }

        public DbSet<object> teste { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Caso queira fazer alguma configuração específica, 
            //pode usar os arquivos de configuração

            //modelBuilder.ApplyConfiguration(new xxxxxxxxxConfiguration());
        }
    }
}
