using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Models;
using dotnet_grad.Repository;
using MediatR;

namespace Resources.Commands
{
  public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserModel>
  {
    private readonly TestContext _testContext;
    private readonly UserRepository _userRepository;
    public CreateUserCommandHandler(TestContext testContext, UserRepository userRepository)
    {
      _testContext = testContext;
      _userRepository = userRepository;
    }

    public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      UserModel user = new UserModel(request.Name, request.Surname, request.IdNumber, request.Fullname, request.Email, request.Username);
      await _userRepository.AddUser(user);
      return user;
    }
  }
}