using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Commands.Usuario.LoginDashboard
{
    public class LoginDashboardUsuarioRequest
    {
        public string Correo { get; init; } = null!;
        public string Password { get; set; } = null!;
    }
}
