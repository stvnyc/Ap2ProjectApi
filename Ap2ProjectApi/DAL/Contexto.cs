using Ap2ProjectApi.Data.models;
using Microsoft.EntityFrameworkCore;

namespace Ap2ProjectApi.DAL;

public class Contexto : DbContext
{
    public DbSet<Prioridades> Prioridades { get; set; }
    public DbSet<Sistemas> Sistemas { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
}
