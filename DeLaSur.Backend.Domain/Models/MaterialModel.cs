﻿using DeLaSur.Backend.Domain.Base;

namespace DeLaSur.Backend.Domain.Models
{
    public class MaterialModel : AuditModel
    {
        public int IdMaterial { get; set; }
        public int IdTipoMaterial { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public MaterialModel()
        {

        }
    }
}
