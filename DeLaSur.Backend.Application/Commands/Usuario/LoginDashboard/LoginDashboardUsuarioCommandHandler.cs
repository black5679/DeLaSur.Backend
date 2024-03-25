using MediatR;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.Services;
using DeLaSur.Backend.Domain.UoW;
using Mapster;
using DeLaSur.Backend.Domain.Models;

namespace DeLaSur.Backend.Application.Commands.Usuario.LoginDashboard
{
    public class LoginDashboardUsuarioCommandHandler : IRequestHandler<LoginDashboardUsuarioCommand, string>
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IJwtService jwtService;
        public LoginDashboardUsuarioCommandHandler(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IJwtService jwtService)
        {
            this.unitOfWork = unitOfWork;
            this.jwtService = jwtService;
            this.usuarioRepository = usuarioRepository;
        }
        public async Task<string> Handle(LoginDashboardUsuarioCommand request, CancellationToken cancellationToken)
        {
            var password = jwtService.EncryptString(request.Password);
            var usuario = request.Adapt<UsuarioModel>();
            usuario.Password = password;
            var id = await usuarioRepository.LoginDashboard(usuario);
            // Genera el Token
            var token = jwtService.GenerateToken(id);
            unitOfWork.Commit();
            return token;
        }
    }
}
