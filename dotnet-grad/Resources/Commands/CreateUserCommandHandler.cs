using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Interface;
using dotnet_grad.Models;
using MediatR;
using BusinessLogicLayers.Interfaces;
using DataAccessLayer.Models;

namespace Resources.Commands
{
  public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
  {
    private readonly TestContext _testContext;
    private readonly IUserRepository _userRepository;
    public CreateUserCommandHandler(TestContext testContext, IUserRepository userRepository)
    {
      _testContext = testContext;
      _userRepository = userRepository;
    }

    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      User user = new User(request.Name, request.Surname, request.IdNumber, request.Fullname, request.Email, request.Username);
      await _userRepository.AddUser(user);
      return user;
    }
  }
}