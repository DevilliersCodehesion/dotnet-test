using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using BusinessLogicLayers.Interfaces;
using DataAccessLayer.Models;
using dotnet_grad.Dtos.Response;
using dotnet_grad.Dtos.Request;

namespace Resources.Commands
{
  public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResponseDto>
  {
    private readonly DatabaseContext _testContext;
    private readonly IUserRepository _userRepository;
    public CreateUserCommandHandler(DatabaseContext testContext, IUserRepository userRepository)
    {
      _testContext = testContext;
      _userRepository = userRepository;
    }

    public async Task<UserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      User user = new User(request.Name, request.Surname, request.IdNumber, request.Fullname, request.Email, request.Username);
      await _userRepository.AddUser(user);
      UserResponseDto createdUser = new UserResponseDto(request.Name, request.Surname, request.Fullname, request.Email);
      return createdUser;
    }
  }
}