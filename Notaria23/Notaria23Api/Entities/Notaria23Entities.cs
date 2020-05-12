using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Notaria23Api.Entities
{
    public class Notaria23Entities : DbContext
    {
        public Notaria23Entities()
            : base("name=Notaria23Entities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        //public virtual DbSet<Categorias> Categorias { get; set; }
    }
}
