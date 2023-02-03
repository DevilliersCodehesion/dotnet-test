using DataAccessLayer.Models;
using dotnet_grad.Dtos.Request;
using MediatR;

namespace Resources.Commands
{
  public class CreateUserCommand : IRequest<User>
  {
    public CreateUserCommand(UserRequestDto user)
    {
      Name = user.Name;
      Surname = user.Surname;
      IdNumber = user.IdNumber;
      Fullname = user.FullName;
      Email = user.Email;
      Username = user.Username;
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string IdNumber { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
  }
}