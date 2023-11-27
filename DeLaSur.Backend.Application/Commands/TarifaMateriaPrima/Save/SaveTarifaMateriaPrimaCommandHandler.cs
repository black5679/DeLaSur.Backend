using DeLaSur.Backend.Domain.Base;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.Services;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Domain.Utils;
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
            List<TarifaMateriaPrimaModel> tarifasMateriaPrima = new();
            foreach (var carat in carats)
            {
                TarifaMateriaPrimaModel tarifaMateriaPrima = new TarifaMateriaPrimaModel();
                // Materia Prima
                var name = carat.Name != null ? carat.Name.ToLower().Trim() : "";
                if (name.Contains("ruby"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Rubi;
                }
                if (name.Contains("sapphire"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Zafiro;
                }
                if (name.Contains("garnet"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Granate;
                }
                if (name.Contains("agate"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Agata;
                }
                if (name.Contains("tsavorite"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Tsfavorita;
                }
                if (name.Contains("tanzanite"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Tanzanita;
                }
                if (name.Contains("tourmaline"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Turmalina;
                }
                if (name.Contains("emerald"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Esmeralda;
                }
                if (name.Contains("zircon"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Zircon;
                }
                if (name.Contains("indicolite"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Rubi;
                }
                if (name.Contains("topaz"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Topacio;
                }
                if (name.Contains("morganite"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Morganita;
                }
                if (name.Contains("amethyst"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Amatista;
                }
                if (name.Contains("quartz"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Cuarzo;
                }
                if (name.Contains("rubellite"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Rubelita;
                }
                if (name.Contains("aquamarine"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Aguamarina;
                }
                if (name.Contains("spinel"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Espinela;
                }
                if (name.Contains("beryl"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Berilo;
                }
                if (name.Contains("opal"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Opalo;
                }
                if (name.Contains("diamond"))
                {
                    tarifaMateriaPrima.IdMateriaPrima = (int)Enums.MateriaPrima.Diamante;
                }
                // Pureza
                var clarity = carat.Clarity != null ? carat.Clarity.ToLower().Trim() : "";
                if ((clarity.Contains("eye") || clarity.Contains("loupe")) && clarity.Contains("clean"))
                {
                    tarifaMateriaPrima.IdPureza = (int)Enums.Pureza.FL;
                }
                if (clarity.Contains("inclusion"))
                {
                    if (clarity.Contains("small"))
                    {
                        if (clarity.Contains("very"))
                        {
                            tarifaMateriaPrima.IdPureza = (int)Enums.Pureza.VS;
                        }
                        else
                        {
                            tarifaMateriaPrima.IdPureza = (int)Enums.Pureza.SI;
                        }
                    }
                    if (clarity.Contains("tiny"))
                    {
                        tarifaMateriaPrima.IdPureza = (int)Enums.Pureza.VVS;
                    }
                }
                
                if (tarifaMateriaPrima.IdMateriaPrima != 0 && tarifaMateriaPrima.IdPureza != 0)
                {
                    tarifaMateriaPrima.Precio = carat.Precio;
                    tarifaMateriaPrima.Peso = carat.Peso;
                    tarifaMateriaPrima.Largo = carat.Largo;
                    tarifaMateriaPrima.Ancho = carat.Ancho;
                    tarifaMateriaPrima.Alto = carat.Alto;
                    tarifasMateriaPrima.Add(tarifaMateriaPrima);
                }
            }
            int idFuente = (int) Enums.Fuente.CaratOnline;
            await tarifaMateriaPrimaRepository.Save(tarifasMateriaPrima, idFuente);
            unitOfWork.Commit();
            return new ResponseModel() { Message = "Registros actualizados con éxito" };
        }
    }
}
