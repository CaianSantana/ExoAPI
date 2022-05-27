using Exoapi.Models;
using Microsoft.EntityFrameworkCore;
namespace Exoapi.Contexts
{
public class ExoContext : DbContext
    {
        public ExoContext()
        {
        }
        public ExoContext(DbContextOptions<ExoContext>options): base(options)
        {
        }
        // vamos utilizar esse método para configurar o banco de dados
protected override void
OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // cada provedor tem sua sintaxe para especificação
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-94ET363\\SQLEXPRESS; initial catalog = ExoAPI; Integrated Security = true");
            }
        }
        // dbset representa as entidades que serão utilizadas nas operações de leitura, criação, atualização e deleção
    public DbSet<Projeto> Projetos { get; set; }
    
    public DbSet<Funcionario> Funcionarios { get; set; }
    }
}