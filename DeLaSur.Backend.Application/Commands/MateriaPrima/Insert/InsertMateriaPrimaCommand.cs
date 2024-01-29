using DeLaSur.Backend.Domain.Base;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.MateriaPrima.Insert
{
    public class InsertMateriaPrimaCommand : IRequest<ResponseModel>
    {
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
