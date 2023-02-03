using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayers.Interfaces;
using DataAccessLayer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Resources.Queries
{
  public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
  {
    private readonly DatabaseContext _testContext;
    IUserRepository _userRepository;
    public GetUserByIdQueryHandler(DatabaseContext testContext, IUserRepository userRepository)
    {
      _testContext = testContext;
      _userRepository = userRepository;
    }

    public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) =>
        _userRepository.GetUserDetails(request.Id);
  }
}