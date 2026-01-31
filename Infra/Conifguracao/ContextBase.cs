using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Conifguracao
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions options) : base (options)
        {
            /*propositalmente vazio*/
        }

        public DbSet<ToDo> ToDo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*Depois dá pra colocar aqui um validador de usuários. Seria algo do tipo: builder.Entity<AppUser>().ToTable(AspNetUsers).HasKey(u => u.Id);*/
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(GetConnectionString());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public string GetConnectionString()
        {
            string LstConnectionString;
            LstConnectionString = "Data Source=todo.db"; //TODO: pegar do /configfile/Enviroment/Apresentacao.appseting.json/etc;
            return LstConnectionString;
        }
    }
}
