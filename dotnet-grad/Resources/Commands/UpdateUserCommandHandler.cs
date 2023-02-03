using BusinessLogicLayers.Interfaces;
using DataAccessLayer.Models;
using dotnet_grad.Dtos.Response;
using MediatR;

namespace Resources.Commands
{
  public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserResponseDto>
  {
    private readonly DatabaseContext _testContext;
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(DatabaseContext testContext, IUserRepository userRepository)
    {
      _testContext = testContext;
      _userRepository = userRepository;
    }

    public async Task<UserResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
      User user = new User(request.Name, request.Surname, request.IdNumber, request.Fullname, request.Email, request.Username);
      User updatedUser = await _userRepository.UpdateUser(request.Id, user);
      UserResponseDto dtoUser = new UserResponseDto(request.Name, request.Surname, request.Fullname, request.Email);
      if (user is null)
      {
        return default;
      }

      return dtoUser;
    }
  }
}