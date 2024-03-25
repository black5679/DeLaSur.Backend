using MediatR;

namespace DeLaSur.Backend.Application.Commands.Usuario.LoginDashboard
{
    public class LoginDashboardUsuarioCommand : LoginDashboardUsuarioRequest, IRequest<string>
    {
    }
}
