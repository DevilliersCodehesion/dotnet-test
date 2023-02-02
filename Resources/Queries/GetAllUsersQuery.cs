using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Resources.Queries
{
  public class GetAllUsersQuery : IRequest<UserModel>
  {

  }
}