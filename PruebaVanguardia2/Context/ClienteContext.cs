using Microsoft.EntityFrameworkCore;
using PruebaVanguardia2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVanguardia2.Context
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        { }
        public DbSet<Cliente> Cliente { get; set; }








        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=DESKTOP-AICR3S2;Database=HelpDesk;User Id=sa;Password=1234");
        }
    }
}
