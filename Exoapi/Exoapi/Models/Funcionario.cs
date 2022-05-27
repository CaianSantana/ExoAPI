
using System.ComponentModel.DataAnnotations;

namespace Exoapi.Models
{
    public class Funcionario
    {
        [Key]
        public int IDFuncionario { get; set; }

        public int IDProjeto { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public string? Nivel { get; set; }
    }
}
