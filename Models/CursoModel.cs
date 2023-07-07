namespace CadastroAluno.Models
{
    public class CursoModel 
    {
        public int Id { get; set; }
        public string NomeCurso { get; set; }
        public int QtdModulos { get; set; }

        public ICollection<TurmaModel> Turmas { get; set; } = new List<TurmaModel>();
        
    }
}
