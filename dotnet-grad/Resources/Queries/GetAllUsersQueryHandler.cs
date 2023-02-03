using System;
using System.Collections.Generic;
using BusinessLogicLayers.Interfaces;
using DataAccessLayer.Models;
using MediatR;

namespace Resources.Queries
{
  public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
  {
    private readonly DatabaseContext _testContext;
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(DatabaseContext testContext, IUserRepository userRepository)
    {
      _testContext = testContext;
      _userRepository = userRepository;
    }

    public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken) =>
        await _userRepository.GetUsersDetails();
  }
}