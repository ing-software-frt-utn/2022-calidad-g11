using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebControlShoes.Application.DTOs
{
    public class ModelDTO
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public int SuperiorObservado { get; set; }
        public int InferiorObservado { get; set; }
        public int SuperiorReproceso { get; set; }
        public int InferiorReproceso { get; set; }
    }
}
