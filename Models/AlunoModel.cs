namespace CadastroAluno.Models
{
    public class AlunoModel 
    {
        public int Id { get; set; }
        public string FirstNome { get; set; }
        public  string LastName { get; set; }
        public string CertidaoNascimento { get; set; }
        public string CPF { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public bool Status { get; set; }

        public ICollection<TurmaModel> Turmas { get; set; } = new List<TurmaModel>();
       
    }
}
