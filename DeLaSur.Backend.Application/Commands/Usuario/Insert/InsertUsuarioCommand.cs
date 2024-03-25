using DeLaSur.Backend.Domain.Base;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.Usuario.Insert
{
    public class InsertUsuarioCommand : InsertUsuarioRequest, IRequest<ResponseModel>
    {
    }
}
