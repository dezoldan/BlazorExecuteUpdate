using BlazorApp1.Client.Pages;
using BlazorApp1.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<AlunosTeste> TableTeste { get; set; }
    }
}
