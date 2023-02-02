using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resources.Commands
{
  public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserModel>
  {
    private readonly TestContext _testContext;
    private
    public CreateUserCommandHandler(TestContext testContext)
    {
      _testContext = testContext;
    }

    public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      UserModel user = new UserModel(request.Name, request.Surname, request.IdNumber, request.Fullname, request.Email, request.Username);
      _testContext.Users.Add(user);
      await _testContext.SaveChangesAsync();
      return user;
    }
  }
}