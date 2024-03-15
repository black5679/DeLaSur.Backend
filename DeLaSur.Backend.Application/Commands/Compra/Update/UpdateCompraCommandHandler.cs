using DeLaSur.Backend.Application.Commands.Compra.Insert;
using DeLaSur.Backend.Domain.Base;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Commands.Compra.Update
{
    public class UpdateCompraCommandHandler : IRequestHandler<UpdateCompraCommand, ResponseModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICompraRepository compraRepository;
        private readonly IDetalleCompraRepository detalleCompraRepository;
        public UpdateCompraCommandHandler(IUnitOfWork unitOfWork, ICompraRepository compraRepository, IDetalleCompraRepository detalleCompraRepository)
        {
            this.unitOfWork = unitOfWork;
            this.compraRepository = compraRepository;
            this.detalleCompraRepository = detalleCompraRepository;
        }
        public async Task<ResponseModel> Handle(UpdateCompraCommand request, CancellationToken cancellationToken)
        {
            var compra = request.Adapt<CompraModel>();
            var id = await compraRepository.Update(compra);
            var detallesCompra = request.Detalles.Adapt<List<DetalleCompraModel>>();
            await detalleCompraRepository.Save(detallesCompra, id);
            unitOfWork.Commit();
            return new() { Message = "Se modificó la orden de compra con éxito", Data = id };
        }
    }
}
