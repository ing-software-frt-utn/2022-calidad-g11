using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebControlShoes.Application.DTOs;
using Zapatillas.Domain.Entities;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Application.Contratos
{
    public interface IOrdenProduccionService
    {
        Task<OrdenProduccion> CrearOrdenProduccionAsync(string codigoColor, int nroLinea, string sku, string codigoOP, string codigoSupervisor);
        Task<IEnumerable<OrdenProduccion>> GetAll();
        Task<OrdenProduccion> GetByIdAsync(Guid id);
        Task<OrdenProduccion> GetByCodigoOpAsync(string codigoOp);

        // OrdenProduccion CrearOrdenProduccion(string codigoColor, int nroLinea, string sku, string codigoOP, string codigoSupervisor);
        // IEnumerable<OrdenProduccion> GetAll();

    }
}

// Task<(List<int> ,SupervisorCalidad)> InspeccionarCalzado(string codigoColor);
//  Task<OrdenProduccion> RegistrarDefecto(string codigoColor, string sku, string codigoOP, int codigoSupervisor);
//   Task<OrdenProduccion> RegistrarPrimera(string codigoColor, string sku, string codigoOP, int codigoSupervisor);

//    Task<OrdenProduccion> SaveAlerta(DateTime stop, DateTime reinicio);
//update - insert  ()
// Task<IEnumerable<OrdenProduccion> GetAll();





