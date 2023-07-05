using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

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
