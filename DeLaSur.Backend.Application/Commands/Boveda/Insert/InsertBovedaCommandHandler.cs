using DeLaSur.Backend.Domain.Base;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using Mapster;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.Boveda.Insert
{
    public class InsertBovedaCommandHandler : IRequestHandler<InsertBovedaCommand, ResponseModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IBovedaRepository bovedaRepository;
        public InsertBovedaCommandHandler(IUnitOfWork unitOfWork, IBovedaRepository bovedaRepository)
        {
            this.unitOfWork = unitOfWork;
            this.bovedaRepository = bovedaRepository;
        }
        public async Task<ResponseModel> Handle(InsertBovedaCommand request, CancellationToken cancellationToken)
        {
            var boveda = request.Adapt<BovedaModel>();
            var id = await bovedaRepository.Insert(boveda);
            unitOfWork.Commit();
            return new() { Data = id, Message = "Se registró la boveda con éxito." };
        }
    }
}
