
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using WebControlShoes.Application.Contratos;
using WebControlShoes.Application.DTOs;
using WebControlShoes.Domain.Repository;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Application.Servicios
{
    public class ModelServices : IModelService
    {
        
        private readonly IConfiguration _configuration;
        public readonly IRepository<Modelo> _modelRepository;
        public ModelServices(IRepository<Modelo> modelRepository, IConfiguration configuration)
        {
            _modelRepository = modelRepository;
            _configuration = configuration;
        }

        public async Task<Modelo> CrearModelAsync(string sku, string description, int limiteObservadoSuperior, int limiteObservadoInferior, int limiteReprocesoSuperior, int limiteReprocesoInferior)
        {

            var Model = new Modelo(sku, description, limiteObservadoSuperior, limiteObservadoInferior, limiteReprocesoSuperior, limiteReprocesoInferior);

            var modelo = await _modelRepository.AgregarAsync(Model);

            return modelo;


        }

        public async Task<ModelDTO> GetBySkuAsync(string sku)
        {
            var model =await _modelRepository.BuscarByAsync(m => m.Sku == sku);

            if (model == null)
            {
                throw new NullReferenceException();
            }
            ModelDTO ModelDTO = new ModelDTO();
            ModelDTO.Sku = model.Sku;
            ModelDTO.Name = model.Denominacion;
            ModelDTO.SuperiorObservado = model.LimiteSuperiorObservado;
            ModelDTO.InferiorObservado = model.LimiteInferiorObservado;
            ModelDTO.SuperiorReproceso = model.LimiteSuperiorReproceso;
            ModelDTO.InferiorReproceso = model.LimiteInferiorReproceso;

            //await Task.WhenAll(modelo, linea, Model);
            return ModelDTO;
        }

        public async Task<IEnumerable<Modelo>> GetAllAsync()
        {
            var models = await _modelRepository.ObtenerTodosAsync();
            if (models == null)
            {
                throw new NullReferenceException();
            }

            return models;
        }

        public async Task<ModelDTO> GetByIdAsync(Guid id)
        {
            var Model = await _modelRepository.BuscarPorIdAsync(id);
            if (Model == null)
            {
                throw new NullReferenceException();
            }

            ModelDTO ModelDTO = new ModelDTO();
            ModelDTO.Sku = Model.Sku;
            ModelDTO.Name = Model.Denominacion;
            ModelDTO.SuperiorObservado = Model.LimiteSuperiorObservado;
            ModelDTO.InferiorObservado = Model.LimiteInferiorObservado;
            ModelDTO.SuperiorReproceso = Model.LimiteSuperiorReproceso;
            ModelDTO.InferiorReproceso = Model.LimiteInferiorReproceso;

            //await Task.WhenAll(modelo, linea, Model);
            return ModelDTO;
        }
    }
 }



















/*
public  Modelo CrearModel(string sku, string description, int limiteObservadoSuperior, int limiteObservadoInferior,int limiteReprocesoSuperior,int limiteReprocesoInferior)
{

    var Model = new Modelo(sku, description, limiteObservadoSuperior, limiteObservadoInferior, limiteReprocesoSuperior, limiteReprocesoInferior);

    var texto =  _modelRepository.Agregar(Model);

    return texto;

}


public   IEnumerable<Modelo> GetAll()
{
    var models =  _modelRepository.ObtenerTodos();
    if (models == null)
    {
        throw new NullReferenceException();
    }


    return models;
}




public  ModelDTO GetById(string sku)
{
    var Model =  _modelRepository.BuscarPorId(sku);
    if (Model == null)
    {
        throw new NullReferenceException();
    }
    ModelDTO ModelDTO = new ModelDTO();
    ModelDTO.Sku = Model.Sku;
    ModelDTO.Name = Model.Denominacion;
    ModelDTO.SuperiorObservado = Model.LimiteSuperiorObservado;
    ModelDTO.InferiorObservado = Model.LimiteInferiorObservado;
    ModelDTO.SuperiorReproceso = Model.LimiteSuperiorReproceso;
    ModelDTO.InferiorReproceso = Model.LimiteInferiorReproceso;

    //await Task.WhenAll(modelo, linea, Model);
    return ModelDTO;
}*/

//CREAR modelo en memoria
//Almacenarlo
//Enviarlo
/*
public async Task<string> Save(string sku) {


    //string sku=string.Empty;
    //TaskCreationOptions 
    //Context----.Save(dasd)

    //implementar
    return sku;

}
public async Task<ModelDTO> Load()
{
    //Context----.Save(dasd)
    //implementar
    return new ModelDTO();
}
}*/



/*public Model GetById(string codigoModel)
{
    var Model = _modelRepository.ObtenerTodos()
                                .Where(c => c.CodigoModel == codigoModel)
                                .FirstOrDefault();

    return Model;

 throw new Exception("Ya existe un Model con el codigo enviado, por favor ingrese uno distinto");

}*/