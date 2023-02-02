using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Models;
using MediatR;

namespace Resources.Queries
{
  public class GetAllUsersQuery : IRequest<List<UserModel>>
  {

  }
}