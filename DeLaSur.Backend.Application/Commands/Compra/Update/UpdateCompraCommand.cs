using DeLaSur.Backend.Domain.Base;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.Compra.Update
{
    public class UpdateCompraCommand : UpdateCompraRequest, IRequest<ResponseModel>
    {
    }
}
