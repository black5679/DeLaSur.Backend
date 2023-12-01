using DeLaSur.Backend.Domain.Base;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.ProductoBoveda.Insert
{
    public class InsertProductoBovedaCommand : InsertProductoBovedaRequest, IRequest<ResponseModel>
    {
    }
}
