﻿using DeLaSur.Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Services
{
    public interface IRenderService
    {
        Task<dynamic> Render();
        Task Local(ModeloModel modelo, List<EspacioModel> espacios);
    }
}
