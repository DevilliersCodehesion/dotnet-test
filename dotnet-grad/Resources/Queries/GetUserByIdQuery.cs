using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using dotnet_grad.Models;
using MediatR;

namespace Resources.Queries
{
  public class GetUserByIdQuery : IRequest<User>
  {
    public GetUserByIdQuery(int id)
    {
      Id = id;
    }
    public int Id { get; set; }
  }
}