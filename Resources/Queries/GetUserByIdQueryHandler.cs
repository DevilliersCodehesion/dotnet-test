using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Resources.Queries
{
  public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserModel>
  {
    private readonly TestContext _testContext;
    public GetUserByIdQueryHandler(TestContext testContext)
    {
      _testContext = testContext;
    }

    public async Task<UserModel> handle(GetUserByIdQuery request, CancellationToken cancellationToken) =>
        await _testContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

  }
}