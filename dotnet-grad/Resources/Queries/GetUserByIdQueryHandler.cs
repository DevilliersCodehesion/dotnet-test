using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Models;
using dotnet_grad.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Resources.Queries
{
  public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserModel>
  {
    private readonly TestContext _testContext;
    UserRepository _userRepository;
    public GetUserByIdQueryHandler(TestContext testContext, UserRepository userRepository)
    {
      _testContext = testContext;
      _userRepository = userRepository;
    }

    public Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) =>
        _userRepository.GetUserDetails(request.Id);
  }
}