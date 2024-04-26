using FluentValidation;

namespace ProjetoJUST.Application.DTOs.Validations;

public class UserDTOValidator : AbstractValidator<UserDTO>
{
    public UserDTOValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage("Email deve ser informado!");

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome deve ser informado!");

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage("Senha deve ser informado!");
    }
}