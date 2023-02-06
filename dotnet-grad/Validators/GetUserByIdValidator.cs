using FluentValidation;
using Resources.Queries;

namespace dotnet_grad.Validators
{
  public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
  {
    public GetUserByIdValidator()
    {
      RuleFor(user => user.Id).NotNull();
    }
  }
}