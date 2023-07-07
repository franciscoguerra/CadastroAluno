using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CadastroAluno.Context.Map
{
    public class AlunoMap : IEntityTypeConfiguration<AlunoModel>
    {
       
        public void Configure(EntityTypeBuilder<AlunoModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
