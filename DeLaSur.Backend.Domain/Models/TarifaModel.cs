﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Models
{
    public class TarifaModel
    {
        public int Id { get; set; }
        public int IdMaterial { get; set; }
        public int IdPureza { get; set; }
        public int IdColor { get; set; }
        public int IdForma { get; set; }
        public int IdFuente { get; set; }
        public decimal Precio { get; set; }
        public decimal Peso { get; set; }
        public decimal Largo { get; set; }
        public decimal Ancho { get; set; }
        public decimal Alto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Status { get; set; }
    }
}
