using Microsoft.EntityFrameworkCore;
using PruebaVanguardia2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVanguardiaDos.Context
{
    public class CliContext : DbContext
    {
        public CliContext(DbContextOptions<CliContext> options) : base(options)
        { }
        public DbSet<Cliente> Cliente { get; set; }








        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=DESKTOP-AICR3S2;Database=Cliente;User Id=sa;Password=1234");
        }
    }
}
