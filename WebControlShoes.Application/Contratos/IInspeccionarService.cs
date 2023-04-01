using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebControlShoes.Application.DTOs;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Application.Contratos
{
    public interface IInspeccionarService
    {
        Task RegistrarDefecto(string codigoOP, Guid defectoId,
                                           Pie pie, TipoDefecto tipo, int hora, int quantity = 1);
        Task<OrdenProduccion> IniciarInspeccionAsync(string supervisorCalidad, string codigoOP);

    }
}
