using FluentValidation;
using Resources.Commands;

namespace dotnet_grad.Validators
{
  public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
  {
    public CreateUserCommandValidator()
    {
      RuleFor(user => user.Email).NotNull().EmailAddress();
      RuleFor(user => user.Name).NotNull();
      RuleFor(user => user.Surname).NotNull();
      RuleFor(user => user.IdNumber).NotNull();
      RuleFor(user => user.Username).NotNull();
    }
  }
}