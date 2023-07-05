namespace CadastroAluno.Models
{
    public class TurmaModel 
    {
        public int Id { get; set; }
        public string NomeTurma { get; set; }
        public DateTime Horario { get; set; }

        public int CursoId { get; set; }
        public CursoModel Curso { get; set; }

        public ICollection<AlunoModel> Alunos { get; set; } = new List<AlunoModel>();
        
    }
}
