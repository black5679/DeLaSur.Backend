using DeLaSur.Backend.Domain.Base;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Domain.Utils;
using DeLaSur.Backend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Commands.MateriaPrimaBoveda.Insert
{
    public class InsertMateriaPrimaBovedaCommandHandler : IRequestHandler<InsertMateriaPrimaBovedaCommand, ResponseModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMateriaPrimaBovedaRepository materiaPrimaBovedaRepository;
        private readonly IMovimientoRepository movimientoRepository;
        public InsertMateriaPrimaBovedaCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            materiaPrimaBovedaRepository = new MateriaPrimaBovedaRepository(unitOfWork.Connection, unitOfWork.Transaction);
            movimientoRepository = new MovimientoRepository(unitOfWork.Connection, unitOfWork.Transaction);
        }
        public async Task<ResponseModel> Handle(InsertMateriaPrimaBovedaCommand request, CancellationToken cancellationToken)
        {
            var movimiento = new MovimientoModel() { IdInventario = (int) Enums.Inventario.Boveda, IdTipoMovimiento = (int) Enums.TipoMovimiento.EntradaMercaderia, Inventario = request.IdBoveda, UsuarioCreacion = request.UsuarioCreacion };
            foreach (var item in request.MateriasPrimas)
            {
                var detalle = new DetalleMovimientoModel() { IdMercaderia = item.IdMateriaPrima, IdTipoMercaderia = (int)Enums.TipoMercaderia.MateriaPrima, Cantidad = item.Stock };
                movimiento.DetallesMovimiento.Add(detalle);
            }
            await movimientoRepository.Insert(movimiento);
            var materiasPrimas = request.MateriasPrimas.Adapt<List<MateriaPrimaBovedaModel>>();
            await materiaPrimaBovedaRepository.Save(materiasPrimas, request.IdBoveda, request.UsuarioCreacion);
            unitOfWork.Commit();
            return new() { };
        }
    }
}
