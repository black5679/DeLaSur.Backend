using DeLaSur.Backend.Domain.Base;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.Services;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Services;
using Mapster;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.Usuario.Insert
{
    public class InsertUsuarioCommandHandler : IRequestHandler<InsertUsuarioCommand, ResponseModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IJwtService jwtService;
        public InsertUsuarioCommandHandler(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IJwtService jwtService)
        {
            this.unitOfWork = unitOfWork;
            this.usuarioRepository = usuarioRepository;
            this.jwtService = jwtService;
        }
        public async Task<ResponseModel> Handle(InsertUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = request.Adapt<UsuarioModel>();
            var password = jwtService.EncryptString("delasur" + DateTime.Now.Year);
            usuario.Password = password;
            var id = await usuarioRepository.Insert(usuario);
            unitOfWork.Commit();
            return new ResponseModel { Data = id, Message = "se registró el usuario con éxito" };
        }
    }
}
