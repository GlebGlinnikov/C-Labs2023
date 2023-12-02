using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lab2
{
    internal class Context : DbContext
    {
        public DbSet<dbmark> dbmarks { get; set; }

        public Context() : base ("DefaultConnection") { }
    }
}
