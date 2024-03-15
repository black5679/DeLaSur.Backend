using DeLaSur.Backend.Domain.Base;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.Compra.Insert
{
    public class InsertCompraCommandHandler : IRequestHandler<InsertCompraCommand, ResponseModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICompraRepository compraRepository;
        private readonly IDetalleCompraRepository detalleCompraRepository;
        public InsertCompraCommandHandler(IUnitOfWork unitOfWork, ICompraRepository compraRepository, IDetalleCompraRepository detalleCompraRepository)
        {
            this.unitOfWork = unitOfWork;
            this.compraRepository = compraRepository;
            this.detalleCompraRepository = detalleCompraRepository;
        }
        public async Task<ResponseModel> Handle(InsertCompraCommand request, CancellationToken cancellationToken)
        {
            var compra = request.Adapt<CompraModel>();
            var id = await compraRepository.Insert(compra);
            var detallesCompra = request.Detalles.Adapt<List<DetalleCompraModel>>();
            await detalleCompraRepository.Save(detallesCompra, id);
            unitOfWork.Commit();
            return new() { Message = "Se registró la orden de compra con éxito", Data = id };
        }
    }
}
