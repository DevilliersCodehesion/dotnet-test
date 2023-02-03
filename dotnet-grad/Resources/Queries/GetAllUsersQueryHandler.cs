using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Interface;
using dotnet_grad.Models;
using dotnet_grad.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Resources.Queries
{
  public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserModel>>
  {
    private readonly TestContext _testContext;
    private readonly IUsers _userRepository;

    public GetAllUsersQueryHandler(TestContext testContext, IUsers userRepository)
    {
      _testContext = testContext;
      _userRepository = userRepository;
    }

    public async Task<List<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken) =>
        await _userRepository.GetUsersDetails();
  }
}