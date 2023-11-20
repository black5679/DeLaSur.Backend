using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Base
{
    public class ResponseModel
    {
        public string? Message { get; set; }
        public dynamic? Data { get; set; }
    }
}
