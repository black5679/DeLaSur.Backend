using DeLaSur.Backend.Domain.Base;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.Services;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Domain.Utils;
using DeLaSur.Backend.Infrastructure.Repositories;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.Tarifa.Save
{
    public class SaveTarifaCommandHandler : IRequestHandler<SaveTarifaCommand, ResponseModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITarifaRepository tarifaRepository;
        private readonly IScrapingService scrapingService;
        public SaveTarifaCommandHandler(IUnitOfWork unitOfWork, ITarifaRepository tarifaRepository, IScrapingService scrapingService)
        {
            this.scrapingService = scrapingService;
            this.unitOfWork = unitOfWork;
            this.tarifaRepository = tarifaRepository;
        }
        public async Task<ResponseModel> Handle(SaveTarifaCommand request, CancellationToken cancellationToken)
        {
            var carats = await scrapingService.CaratOnline();
            List<TarifaModel> tarifas = [];
            foreach (var carat in carats)
            {
                TarifaModel tarifa = new TarifaModel();
                // Materia Prima
                var name = carat.Name != null ? carat.Name.ToLower().Trim() : "";
                if (name.Contains("ruby"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Rubi;
                }
                if (name.Contains("sapphire"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Zafiro;
                }
                if (name.Contains("garnet"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Granate;
                }
                if (name.Contains("agate"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Agata;
                }
                if (name.Contains("tsavorite"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Tsfavorita;
                }
                if (name.Contains("tanzanite"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Tanzanita;
                }
                if (name.Contains("tourmaline"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Turmalina;
                }
                if (name.Contains("emerald"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Esmeralda;
                }
                if (name.Contains("zircon"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Zircon;
                }
                if (name.Contains("indicolite"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Rubi;
                }
                if (name.Contains("topaz"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Topacio;
                }
                if (name.Contains("morganite"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Morganita;
                }
                if (name.Contains("amethyst"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Amatista;
                }
                if (name.Contains("quartz"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Cuarzo;
                }
                if (name.Contains("rubellite"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Rubelita;
                }
                if (name.Contains("aquamarine"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Aguamarina;
                }
                if (name.Contains("spinel"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Espinela;
                }
                if (name.Contains("beryl"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Berilo;
                }
                if (name.Contains("opal"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Opalo;
                }
                if (name.Contains("diamond"))
                {
                    tarifa.IdMaterial = (int)Enums.MateriaPrima.Diamante;
                }
                // Pureza
                var clarity = carat.Clarity != null ? carat.Clarity.ToLower().Trim() : "";
                if ((clarity.Contains("eye") || clarity.Contains("loupe")) && clarity.Contains("clean"))
                {
                    tarifa.IdPureza = (int)Enums.Pureza.FL;
                }
                if (clarity.Contains("inclusion"))
                {
                    if (clarity.Contains("small"))
                    {
                        if (clarity.Contains("very"))
                        {
                            tarifa.IdPureza = (int)Enums.Pureza.VS;
                        }
                        else
                        {
                            tarifa.IdPureza = (int)Enums.Pureza.SI;
                        }
                    }
                    if (clarity.Contains("tiny"))
                    {
                        tarifa.IdPureza = (int)Enums.Pureza.VVS;
                    }
                }

                if (tarifa.IdMaterial != 0 && tarifa.IdPureza != 0)
                {
                    tarifa.Precio = carat.Precio;
                    tarifa.Peso = carat.Peso;
                    tarifa.Largo = carat.Largo;
                    tarifa.Ancho = carat.Ancho;
                    tarifa.Alto = carat.Alto;
                    tarifas.Add(tarifa);
                }
            }
            int idFuente = (int)Enums.Fuente.CaratOnline;
            await tarifaRepository.Save(tarifas, idFuente);
            unitOfWork.Commit();
            return new ResponseModel() { Message = "Registros actualizados con éxito" };
        }
    }
}
