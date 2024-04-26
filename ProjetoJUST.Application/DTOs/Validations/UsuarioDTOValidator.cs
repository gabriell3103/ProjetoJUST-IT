using FluentValidation;

namespace ProjetoJUST.Application.DTOs.Validations;

public class UsuarioDTOValidator : AbstractValidator<UsuarioDTO>
{
    public UsuarioDTOValidator() 
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage("Email deve ser informado!");

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage("Password deve ser informado!");
    }
}