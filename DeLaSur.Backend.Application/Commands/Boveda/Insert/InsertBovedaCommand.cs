using DeLaSur.Backend.Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Commands.Boveda.Insert
{
    public class InsertBovedaCommand : IRequest<ResponseModel>
    {
        public required int IdTipoBoveda { get; set; }
        public string Codigo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string Ubicacion { get; set; } = null!;
    }
}
