using DeLaSur.Backend.Domain.Base;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using Mapster;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.Color.Insert
{
    public class InsertColorCommandHandler : IRequestHandler<InsertColorCommand, ResponseModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IColorRepository colorRepository;
        public InsertColorCommandHandler(IUnitOfWork unitOfWork, IColorRepository colorRepository)
        {
            this.unitOfWork = unitOfWork;
            this.colorRepository = colorRepository;
        }
        public async Task<ResponseModel> Handle(InsertColorCommand request, CancellationToken cancellationToken)
        {
            var color = request.Adapt<ColorModel>();
            var id = await colorRepository.Insert(color);
            unitOfWork.Commit();
            return new() { Data = id, Message = "Se registró el color con éxito." };
        }
    }
}
