using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PromocaoHumana.Web.Data.Map;
using PromocaoHumana.Web.Domain;

namespace PromocaoHumana.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Igreja> Igrejas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        private IDbContextTransaction _transaction;

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new IgrejaMap());
            builder.ApplyConfiguration(new EnderecoMap());
            builder.ApplyConfiguration(new FamiliaMap());
            builder.ApplyConfiguration(new DoacaoMap());

            base.OnModelCreating(builder);
        }
    }
}