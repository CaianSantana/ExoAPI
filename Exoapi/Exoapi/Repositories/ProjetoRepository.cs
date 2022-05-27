using Exoapi.Contexts;
using Exoapi.Models;

namespace Exoapi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext _context;
        public ProjetoRepository(ExoContext context)
        {
            _context = context;
        }
        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }
        public Projeto BuscarId(int IDProjeto) 
        {
            return _context.Projetos.Find(IDProjeto);
        }
        public void Cadastrar(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            _context.SaveChanges();
        }

        public void Atualizar(int IDProjeto, Projeto projeto)
        {
            Projeto projetoBuscado = _context.Projetos.Find(IDProjeto);
            if (projetoBuscado != null)
            {
                projetoBuscado.Titulo = projeto.Titulo;
                projetoBuscado.DataInicio = projeto.DataInicio;
                projetoBuscado.Resquisitos = projeto.Resquisitos;
                projetoBuscado.Area = projeto.Area;
                projetoBuscado.Tecnologia = projeto.Tecnologia;
                projetoBuscado.NumeroFuncionarios = projeto.NumeroFuncionarios;
            }
            _context.Projetos.Update(projetoBuscado);
            _context.SaveChanges();
        }
        public void Deletar(int IDProjeto)
        {
            Projeto projeto = _context.Projetos.Find(IDProjeto);

            _context.Projetos.Remove(projeto);

            _context.SaveChanges();
        }
    }
}
