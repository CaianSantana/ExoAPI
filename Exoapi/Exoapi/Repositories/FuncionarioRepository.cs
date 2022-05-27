using Exoapi.Contexts;
using Exoapi.Interfaces;
using Exoapi.Models;

namespace Exoapi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ExoContext _context;

        public FuncionarioRepository(ExoContext context)
        {
            _context = context;
        }
        public List<Funcionario> Listar()
        {
            return _context.Funcionarios.ToList();
        }
        public Funcionario BuscarId(int IDFuncionario)
        {
            return _context.Funcionarios.Find(IDFuncionario);
        }
        public void Cadastrar(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
        }
        public void Alterar(int IDFuncionario, Funcionario funcionario)
        {

            Funcionario funcionarioEncontrado = _context.Funcionarios.Find(IDFuncionario);
            if (funcionarioEncontrado != null)
            {
                funcionarioEncontrado.Nome = funcionario.Nome;
                funcionarioEncontrado.Email = funcionario.Email;
                funcionarioEncontrado.Senha = funcionario.Senha;
                funcionarioEncontrado.Nivel = funcionario.Nivel;
            }
            _context.Funcionarios.Update(funcionarioEncontrado);
            _context.SaveChanges();
        }
        public void Deletar(int IDFuncionario)
        {
            Funcionario funcionario = _context.Funcionarios.Find(IDFuncionario);


            _context.Funcionarios.Remove(funcionario);

            _context.SaveChanges();
        }

        

        public Funcionario Login(string email, string senha)
        {
            return _context.Funcionarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }
    }
}
