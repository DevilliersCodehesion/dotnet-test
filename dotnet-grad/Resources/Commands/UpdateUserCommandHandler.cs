using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Models;
using dotnet_grad.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Resources.Commands
{
  public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserModel>
  {
    private readonly TestContext _testContext;
    private readonly UserRepository _userRepository;

    public UpdateUserCommandHandler(TestContext testContext, UserRepository userRepository)
    {
      _testContext = testContext;
      _userRepository = userRepository;
    }

    public async Task<UserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
      UserModel user = new UserModel(request.Name, request.Surname, request.IdNumber, request.Fullname, request.Email, request.Username);
      UserModel updatedUser = await _userRepository.UpdateUser(request.Id, user);
      if (user is null)
      {
        return default;
      }

      return updatedUser;
    }
  }
}