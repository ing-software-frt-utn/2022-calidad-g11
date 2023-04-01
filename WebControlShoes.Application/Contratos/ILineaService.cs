using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebControlShoes.Application.DTOs;
using WebControlShoes.Domain.Entities;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Application.Contratos
{
    public interface ILineaService
    {
        Task<LineaProduccion> CrearLineaAsync( int nroLinea, string description);
        //Task<ColorDTO> GetByIdAsync(Guid id);
        //LineaProduccion CrearLinea( string description);
        //  Task<ColorDTO> GetById(string codigoColor);

        //   Task<IEnumerable<Colour>> GetAll();

    }
}
