using System.ComponentModel.DataAnnotations;

namespace Exoapi.Models

{
    public class Projeto
    {
		[Key]
		public int IDProjeto { get; set; }
        public string? Titulo { get; set; }
		public DateTime DataInicio { get; set; }
		public string? Tecnologia { get; set; }
		public string? Resquisitos { get; set; }
		public string? Area { get; set; }
		public int NumeroFuncionarios { get; set; }


	}
}
