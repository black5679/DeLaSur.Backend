using DeLaSur.Backend.Domain.Base;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.MateriaPrimaBoveda.Insert
{
    public class InsertMateriaPrimaBovedaCommand : InsertMateriaPrimaBovedaRequest, IRequest<ResponseModel>
    {
    }
}
