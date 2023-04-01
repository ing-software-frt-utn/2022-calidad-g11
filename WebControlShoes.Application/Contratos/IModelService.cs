using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebControlShoes.Application.DTOs;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Application.Contratos
{
    public interface IModelService
    {

        /*
        Modelo CrearModel(string sku, string description, int limiteObservadoSuperior, int limiteObservadoInferior, int limiteReprocesoSuperior, int limiteReprocesoInferior);
        ModelDTO GetById(string sku);
        IEnumerable<Modelo> GetAll();
        */
        Task<Modelo> CrearModelAsync(string sku, string description, int limiteObservadoSuperior, int limiteObservadoInferior, int limiteReprocesoSuperior, int limiteReprocesoInferior);
        Task<ModelDTO> GetBySkuAsync(string sku);
        Task<IEnumerable<Modelo>> GetAllAsync();

        Task<ModelDTO> GetByIdAsync(Guid id);


    }
}
