using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Resources.Queries
{
  public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserModel>>
  {
    private readonly TestContext _testContext;

    public GetAllUsersQueryHandler(TestContext testContext)
    {
      _testContext = testContext;
    }

    public async Task<IEnumerable<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken) =>
        await _testContext.Users.ToListAsync();
  }
}