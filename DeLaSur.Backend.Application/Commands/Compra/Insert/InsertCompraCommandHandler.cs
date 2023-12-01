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
        public InsertCompraCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            compraRepository = new CompraRepository(unitOfWork.Connection, unitOfWork.Transaction);
        }
        public async Task<ResponseModel> Handle(InsertCompraCommand request, CancellationToken cancellationToken)
        {
            var compra = request.Adapt<CompraModel>();
            var id = await compraRepository.Insert(compra);
            unitOfWork.Commit();
            return new() { Message = "Se registró la orden de compra con éxito", Data = id };
        }
    }
}
