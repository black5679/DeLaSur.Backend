using DeLaSur.Backend.Domain.Base;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using MediatR;
using Mapster;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Exceptions;

namespace DeLaSur.Backend.Application.Commands.MateriaPrima.Insert
{
    public class InsertMateriaPrimaCommandHandler : IRequestHandler<InsertMateriaPrimaCommand, ResponseModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMateriaPrimaRepository materiaPrimaRepository;
        public InsertMateriaPrimaCommandHandler(IUnitOfWork unitOfWork, IMateriaPrimaRepository materiaPrimaRepository)
        {
            this.unitOfWork = unitOfWork;
            this.materiaPrimaRepository = materiaPrimaRepository;
        }
        public async Task<ResponseModel> Handle(InsertMateriaPrimaCommand request, CancellationToken cancellationToken)
        {
            var materiaPrima = request.Adapt<MateriaPrimaModel>();
            var id = await materiaPrimaRepository.Insert(materiaPrima);
            unitOfWork.Commit();
            return new() { Data = id, Message = "Se registró la materia prima con éxito." };
        }
    }
}
