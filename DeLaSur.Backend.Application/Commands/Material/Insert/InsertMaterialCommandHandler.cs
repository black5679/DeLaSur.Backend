using DeLaSur.Backend.Domain.Base;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.Services;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Domain.Utils;
using DeLaSur.Backend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace DeLaSur.Backend.Application.Commands.Material.Insert
{
    public class InsertMaterialCommandHandler : IRequestHandler<InsertMaterialCommand, ResponseModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMaterialRepository materialRepository;
        private readonly IColorMaterialRepository colorMaterialRepository;
        private readonly IModeloRepository modeloRepository;
        private readonly IEspacioRepository espacioRepository;
        private readonly IEspacioMaterialRepository espacioMaterialRepository;
        private readonly IRenderService renderService;
        private readonly IStorageService storageService;
        public InsertMaterialCommandHandler(IUnitOfWork unitOfWork, IRenderService renderService, IStorageService storageService)
        {
            this.unitOfWork = unitOfWork;
            materialRepository = new MaterialRepository(unitOfWork.Connection, unitOfWork.Transaction);
            colorMaterialRepository = new ColorMaterialRepository(unitOfWork.Connection, unitOfWork.Transaction);
            modeloRepository = new ModeloRepository(unitOfWork.Connection, unitOfWork.Transaction);
            espacioRepository = new EspacioRepository(unitOfWork.Connection, unitOfWork.Transaction);
            espacioMaterialRepository = new EspacioMaterialRepository(unitOfWork.Connection, unitOfWork.Transaction);
            this.renderService = renderService;
            this.storageService = storageService;
        }
        public async Task<ResponseModel> Handle(InsertMaterialCommand request, CancellationToken cancellationToken)
        {
            // Registrando material
            var material = request.Adapt<MaterialModel>();
            var id = await materialRepository.Insert(material);
            // Subiendo modelo al contenedor
            List<ModeloModel> modelos = new();
            foreach (var modeloFile in request.Modelos)
            {
                var fileExtension = Path.GetExtension(modeloFile.FileName);
                ModeloModel modelo = new() { Extension = fileExtension, IdMaterial = id, UsuarioCreacion = request.UsuarioCreacion };
                var idModelo = await modeloRepository.Insert(modelo);
                modelo.Id = idModelo;
                var ruta = string.Concat(id, "/", idModelo, fileExtension);
                await storageService.Upload(modeloFile, "modelo", ruta);
                modelos.Add(modelo);
            }
            // Registrando colores del material (Solo para gemas y metales)
            if (request.IdTipoMaterial.Equals((int)Enums.TipoMaterial.Metal) || request.IdTipoMaterial.Equals((int)Enums.TipoMaterial.Gema))
            {
                await colorMaterialRepository.Save(request.Colores, id, request.UsuarioCreacion);
            }
            // Registrando Espacios
            foreach (var item in request.Espacios)
            {
                var espacio = item.Adapt<EspacioModel>();
                var idEspacio = await espacioRepository.Insert(espacio);
                var espaciosMaterial = item.EspaciosMaterial.Adapt<List<EspacioMaterialModel>>();
                await espacioMaterialRepository.Save(espaciosMaterial, idEspacio);
            }
            // Renderizando imagenes
            foreach (var modelo in modelos)
            {
                var espacios = request.Espacios.Adapt<List<EspacioModel>>();
                await renderService.Local(modelo, espacios);
            }
            unitOfWork.Commit();
            return new() { Message = "Se registró el material con éxito", Data = id };
        }
    }
}
