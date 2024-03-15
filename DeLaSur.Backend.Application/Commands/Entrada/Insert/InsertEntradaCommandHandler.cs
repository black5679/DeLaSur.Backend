using DeLaSur.Backend.Domain.Base;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Domain.Utils;
using DeLaSur.Backend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.Entrada.Insert
{
    public class InsertEntradaCommandHandler : IRequestHandler<InsertEntradaCommand, ResponseModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEntradaRepository entradaRepository;
        private readonly IMovimientoRepository movimientoRepository;
        private readonly IMaterialBovedaRepository materialBovedaRepository;
        public InsertEntradaCommandHandler(IUnitOfWork unitOfWork, IEntradaRepository entradaRepository, IMovimientoRepository movimientoRepository, IMaterialBovedaRepository materialBovedaRepository)
        {
            this.unitOfWork = unitOfWork;
            this.entradaRepository = entradaRepository;
            this.movimientoRepository = movimientoRepository;
            this.materialBovedaRepository = materialBovedaRepository;
        }
        public async Task<ResponseModel> Handle(InsertEntradaCommand request, CancellationToken cancellationToken)
        {
            // Registrando movimiento
            var movimiento = new MovimientoModel() { IdTipoMovimiento = (int)Enums.TipoMovimiento.EntradaMercaderia, UsuarioCreacion = request.UsuarioCreacion };
            foreach (var item in request.Detalles)
            {
                var detalle = new DetalleMovimientoModel() { IdMaterial = item.IdMaterial, IdInventario = item.IdBoveda, IdTipoMaterial = (int)Enums.TipoMateriaPrima.Gema, Cantidad = item.Cantidad };
                movimiento.DetallesMovimiento.Add(detalle);
            }
            await movimientoRepository.Insert(movimiento);
            // Registrando entrada
            var entrada = request.Adapt<EntradaModel>();
            var id = await entradaRepository.Insert(entrada);
            // Guardando stock
            var materiales = new List<MaterialBovedaModel>();
            foreach (var item in request.Detalles)
            {
                var material = new MaterialBovedaModel() { IdMaterial = item.IdMaterial, IdBoveda = item.IdBoveda, Stock = item.Cantidad, UsuarioCreacion = request.UsuarioCreacion };
                materiales.Add(material);
            }
            await materialBovedaRepository.Save(materiales, request.UsuarioCreacion);
            unitOfWork.Commit();
            return new() { Data = id, Message = "Se registró la entrada de mercadería con éxito" };
        }
    }
}
