using Exoapi.Models;

namespace Exoapi.Interfaces
{
    public interface IFuncionarioRepository
    {
        List<Funcionario> Listar();

        Funcionario BuscarId(int id);

        void Cadastrar(Funcionario funcionario);

        void Alterar(int id, Funcionario funcionario);

        void Deletar(int id);

        Funcionario Login(string email, string senha);
    }
}
