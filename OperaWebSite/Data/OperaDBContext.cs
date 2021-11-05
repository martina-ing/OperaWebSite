using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;//AGREGAR
using OperaWebSite.Models;//AGREGAR


namespace OperaWebSite.Data
{
    public class OperaDBContext : DbContext
    {
        public OperaDBContext() : base("KeyDB") { }
        public DbSet<Opera> Operas { get; set; }
    }
}