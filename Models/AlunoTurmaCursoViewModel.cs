namespace CadastroAluno.Models
{
    public class AlunoTurmaCursoViewModel
    {
        public int AlunoId { get; set; }
        public string AlunoFirstName { get; set; }
        public string AlunoLastName { get; set; }
        public string AlunoCertidaoNascimento { get; set; }
        public string AlunoCPF { get; set; }
        public string AlunoNomePai { get; set; }
        public string AlunoNomeMae { get; set; }
        public bool AlunoStatus { get; set; }

        public int TurmaId { get; set; }
        public string TurmaNome { get; set; }
        public DateTime TurmaHorario { get; set; }

        public int CursoId { get; set; }
        public string CursoNome { get; set; }
        public int CursoQtdModulos { get; set; }
    }
}
