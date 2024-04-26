using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoJUST.Domain.Entities;

namespace ProjetoJUST.Infra.Data.Maps;

public class UsuarioPermissionMap : IEntityTypeConfiguration<UsuarioPermission>
{
    public void Configure(EntityTypeBuilder<UsuarioPermission> builder)
    {
        builder.ToTable("permissaousuario");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("idpermissaousuario").
            UseIdentityColumn();

        builder.Property(c => c.UsuarioId)
            .HasColumnName("idusuario");

        builder.Property(c => c.PermissionId)
            .HasColumnName("idpermissao");

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.UsuarioPermissions);

        builder.HasOne(x => x.Permission)
            .WithMany(x => x.UsuarioPermissions);        
    }
}
