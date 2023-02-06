using FluentValidation;
using Resources.Commands;

namespace dotnet_grad.Validators
{
  public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
  {

    public UpdateUserCommandValidator()
    {
      RuleFor(user => user.Email).NotNull().NotEmpty();
      RuleFor(user => user.Name).NotNull().NotEmpty();
      RuleFor(user => user.Surname).NotNull().NotEmpty();
      RuleFor(user => user.IdNumber).NotNull().NotEmpty();
      RuleFor(user => user.Username).NotNull().NotEmpty();
    }
  }
}