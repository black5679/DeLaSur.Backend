using DeLaSur.Backend.Domain.Base;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Domain.Utils;
using DeLaSur.Backend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.ProductoBoveda.Insert
{
    public class InsertProductoBovedaCommandHandler : IRequestHandler<InsertProductoBovedaCommand, ResponseModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductoBovedaRepository productoBovedaRepository;
        private readonly IMovimientoRepository movimientoRepository;
        public InsertProductoBovedaCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            productoBovedaRepository = new ProductoBovedaRepository(unitOfWork.Connection, unitOfWork.Transaction);
            movimientoRepository = new MovimientoRepository(unitOfWork.Connection, unitOfWork.Transaction);
        }
        public async Task<ResponseModel> Handle(InsertProductoBovedaCommand request, CancellationToken cancellationToken)
        {
            var movimiento = new MovimientoModel() { IdInventario = request.IdBoveda, IdTipoMovimiento = (int)Enums.TipoMovimiento.EntradaMercaderia, Inventario = request.IdBoveda, UsuarioCreacion = request.UsuarioCreacion };
            foreach (var item in request.Productos)
            {
                var detalle = new DetalleMovimientoModel() { IdMercaderia = item.IdProducto, IdTipoMercaderia = (int)Enums.TipoMercaderia.Producto, Cantidad = item.Stock };
                movimiento.DetallesMovimiento.Add(detalle);
            }
            var id = await movimientoRepository.Insert(movimiento);
            var materiasPrimas = request.Productos.Adapt<List<ProductoBovedaModel>>();
            await productoBovedaRepository.Save(materiasPrimas, request.IdBoveda, request.UsuarioCreacion);
            unitOfWork.Commit();
            return new() { Message = "Se registró la mercadería con éxito", Data = id };
        }
    }
}
