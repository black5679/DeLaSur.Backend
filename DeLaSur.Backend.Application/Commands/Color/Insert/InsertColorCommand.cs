using DeLaSur.Backend.Domain.Base;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.Color.Insert
{
    public class InsertColorCommand : InsertColorRequest, IRequest<ResponseModel>
    {
    }
}
