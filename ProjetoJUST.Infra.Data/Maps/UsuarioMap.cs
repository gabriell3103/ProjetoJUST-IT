using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoJUST.Domain.Entities;

namespace ProjetoJUST.Infra.Data.Maps;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{		
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuario");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("idusuario").
            UseIdentityColumn();

        builder.Property(c => c.Email)
            .HasColumnName("email");

        builder.Property(c => c.Password)
            .HasColumnName("senha");

        builder.HasMany(c => c.UsuarioPermissions)
            .WithOne(p=> p.Usuario) 
            .HasForeignKey(x => x.UsuarioId);
    }
}