using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoJUST.Domain.Entities;

namespace ProjetoJUST.Infra.Data.Maps;

public class UserMap : IEntityTypeConfiguration<User>	
{		
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("pessoa");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("IdPessoa").
            UseIdentityColumn();

        builder.Property(c => c.Email)
            .HasColumnName("email");

        builder.Property(c => c.Name)
            .HasColumnName("nome");

        builder.Property(c => c.Password)
            .HasColumnName("senha");
        
        
    }
}