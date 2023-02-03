using System;
using System.Collections.Generic;
using BusinessLogicLayers.Interfaces;
using DataAccessLayer.Models;
using dotnet_grad.Interface;
using dotnet_grad.Models;
using MediatR;

namespace Resources.Queries
{
  public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
  {
    private readonly TestContext _testContext;
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(TestContext testContext, IUserRepository userRepository)
    {
      _testContext = testContext;
      _userRepository = userRepository;
    }

    public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken) =>
        await _userRepository.GetUsersDetails();
  }
}