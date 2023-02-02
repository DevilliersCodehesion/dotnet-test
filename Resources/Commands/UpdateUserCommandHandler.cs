using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resources.Commands
{
  public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserModel>
  {
    private readonly TestContext _testContext;
    public UpdateUserCommandHandler(TestContext testContext)
    {
      _testContext = testContext;
    }
  }
}