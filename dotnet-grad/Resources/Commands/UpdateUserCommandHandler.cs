using BusinessLogicLayers.Interfaces;
using DataAccessLayer.Models;
using dotnet_grad.Models;
using MediatR;

namespace Resources.Commands
{
  public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
  {
    private readonly TestContext _testContext;
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(TestContext testContext, IUserRepository userRepository)
    {
      _testContext = testContext;
      _userRepository = userRepository;
    }

    public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
      User user = new User(request.Name, request.Surname, request.IdNumber, request.Fullname, request.Email, request.Username);
      User updatedUser = await _userRepository.UpdateUser(request.Id, user);
      if (user is null)
      {
        return default;
      }

      return updatedUser;
    }
  }
}