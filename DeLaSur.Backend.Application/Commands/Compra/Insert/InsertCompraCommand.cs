using DeLaSur.Backend.Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Commands.Compra.Insert
{
    public class InsertCompraCommand : IRequest<ResponseModel>
    {
        public int IdProveedor {  get; set; }
    }
}
