using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using FluentValidation;
using dotnet_grad.Models;
using dotnet_grad.Dtos.Request;

namespace dotnet_grad.Validators
{
  public class UserValidator : AbstractValidator<UserRequestDto>
  {
    public UserValidator()
    {
      RuleFor(user => user.Email).NotNull().NotEmpty();
      RuleFor(user => user.Name).NotNull().NotEmpty();
      RuleFor(user => user.Surname).NotNull().NotEmpty();
      RuleFor(user => user.IdNumber).NotNull().NotEmpty();
      RuleFor(user => user.Username).NotNull().NotEmpty();
    }
  }
}