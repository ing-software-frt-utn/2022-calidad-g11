using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebControlShoes.Domain.Entities;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Application.DTOs
{
    public class OrdenProduccionDTO
    {

        public string CodigoOP { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public List<Usuario> Supervisores { get; set; }
        public LineaProduccion Linea { get; set; }
        public Modelo Modelo { get; set; }
        public Colour Colour { get; set; }
        public Estado Estado { get; set; }
        public List<JornadaLaboral>? JornadasLaborales { get; set; }

    }
}
