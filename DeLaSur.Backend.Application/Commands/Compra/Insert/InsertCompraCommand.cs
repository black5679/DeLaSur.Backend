using DeLaSur.Backend.Domain.Base;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.Compra.Insert
{
    public class InsertCompraCommand : InsertCompraRequest, IRequest<ResponseModel>
    {
    }
}
