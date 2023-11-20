using DeLaSur.Backend.Domain.Base;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.Services;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Repositories;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.TarifaMateriaPrima.Save
{
    public class SaveTarifaMateriaPrimaCommandHandler : IRequestHandler<SaveTarifaMateriaPrimaCommand, ResponseModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITarifaMateriaPrimaRepository tarifaMateriaPrimaRepository;
        private readonly IScrapingService scrapingService;
        public SaveTarifaMateriaPrimaCommandHandler(IUnitOfWork unitOfWork, IScrapingService scrapingService)
        {
            this.scrapingService = scrapingService;
            this.unitOfWork = unitOfWork;
            tarifaMateriaPrimaRepository = new TarifaMateriaPrimaRepository(unitOfWork.Connection, unitOfWork.Transaction);
        }
        public async Task<ResponseModel> Handle(SaveTarifaMateriaPrimaCommand request, CancellationToken cancellationToken)
        {
            var carats = await scrapingService.CaratOnline();
            foreach (var carat in carats)
            {
                TarifaMateriaPrimaModel tarifaMateriaPrima = new TarifaMateriaPrimaModel();
                var name = carat.Name.ToLower().Trim();
                if (name.Contains("ruby"))
                {
                    //tarifaMateriaPrima.IdMateriaPrima = ;
                }
                if (name.Contains("garnet"))
                {

                }
                if (name.Contains("tsfavorite"))
                {

                }
                if (name.Contains("tanzanite"))
                {

                }
                if (name.Contains("tourmaline"))
                {

                }
                if (name.Contains("emerald"))
                {

                }
                if (name.Contains("sapphire"))
                {

                }
                if (name.Contains("zircon"))
                {

                }
                if (name.Contains("indicolite"))
                {

                }
                if (name.Contains("topaz"))
                {

                }
                if (name.Contains("morganite"))
                {

                }
                if (name.Contains("aquamarine"))
                {
                    
                }
                if (name.Contains("beryl"))
                {

                }
                if (name.Contains("diamond"))
                {

                }
            }
            return new ResponseModel();
        }
    }
}
