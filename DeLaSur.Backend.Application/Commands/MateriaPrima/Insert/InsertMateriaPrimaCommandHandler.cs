using DeLaSur.Backend.Domain.Base;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using MediatR;
using Mapster;
using DeLaSur.Backend.Domain.Models;

namespace DeLaSur.Backend.Application.Commands.MateriaPrima.Insert
{
    public class InsertMateriaPrimaCommandHandler : IRequestHandler<InsertMateriaPrimaCommand, ResponseModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMateriaPrimaRepository materiaPrimaRepository;
        public InsertMateriaPrimaCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            materiaPrimaRepository = new MateriaPrimaRepository(unitOfWork.Connection, unitOfWork.Transaction);
        }
        public async Task<ResponseModel> Handle(InsertMateriaPrimaCommand request, CancellationToken cancellationToken)
        {
            var materiaPrima = request.Adapt<MateriaPrimaModel>();
            materiaPrima.Material = request.Adapt<MaterialModel>();
            var id = await materiaPrimaRepository.Insert(materiaPrima);
            unitOfWork.Commit();
            return new ResponseModel { Data = id, Message = "Se registró la materia prima con éxito." };
        }
    }
}
