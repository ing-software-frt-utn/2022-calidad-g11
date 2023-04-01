
using Microsoft.Extensions.Configuration;
using WebControlShoes.Application.Contratos;
using WebControlShoes.Application.DTOs;
using WebControlShoes.Domain.Repository;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Application.Servicios
{
    public class ColorServices : IColorService
    {

        private readonly IConfiguration _configuration;
        public readonly IRepository<Colour> _colorRepository;
        public ColorServices(IRepository<Colour> colorRepository, IConfiguration configuration)
        {
            _colorRepository = colorRepository;
            _configuration = configuration;
        }


        public async Task<Colour> CrearColorAsync(string codigoColor, string description)
        {
            var color = new Colour(description, codigoColor);


            /* ColorDTO colorDTO = new ColorDTO();
               colorDTO.CodColor = codigoColor;
            */
            var colour = await _colorRepository.AgregarAsync(color);

            return colour;
        }

        public async Task<ColorDTO> GetByIdAsync(Guid id)
        {
            var color = await _colorRepository.BuscarPorIdAsync(id);
            if (color == null)
            {
                throw new NullReferenceException();
            }
            ColorDTO colorDTO = new ColorDTO();
            colorDTO.CodColor = color.CodigoColor;
            colorDTO.Descripcion = color.Descripcion;

            //await Task.WhenAll(modelo, linea, color);
            return colorDTO;
        }

        public async Task<Colour> GetByCodigoColor(string codigoColor)
        {
            /*  var colores = await _colorRepository.getAllToUseLinq();

              var color = colores.Where(c => c.CodigoColor == codigoColor)
                                 .Single();
            */
            var color = await _colorRepository.BuscarByAsync(c => c.CodigoColor == codigoColor) ;

            if (color == null)
            {
                throw new NullReferenceException();
            }

         /*   ColorDTO colorDTO = new ColorDTO();
            colorDTO.CodColor = color.CodigoColor;
            colorDTO.Descripcion = color.Descripcion;
           */


            //await Task.WhenAll(modelo, linea, color);
            return color;
        }

        public async Task<IEnumerable<Colour>> GetAllAsync()
        {
            var colores = await _colorRepository.ObtenerTodosAsync();
            if (colores == null)
            {
                throw new NullReferenceException();
            }


            return colores;
        }




        #region no-async
        /*

        public Colour CrearColor(string codigoColor, string description)
        {


            var color = new Colour(description, codigoColor);


            /* ColorDTO colorDTO = new ColorDTO();
               colorDTO.CodColor = codigoColor;
            
            var colour = _colorRepository.Agregar(color);

            return colour;


        }


        public ColorDTO GetById(string codigoColor)
        {
            var color = _colorRepository.BuscarPorIdAsync(codigoColor);
            if (color == null)
            {
                throw new NullReferenceException();
            }
            ColorDTO colorDTO = new ColorDTO();
            colorDTO.CodColor = color.CodigoColor;
            colorDTO.Descripcion = color.Descripcion;

            //await Task.WhenAll(modelo, linea, color);
            return colorDTO;
        }

        public IEnumerable<Colour> GetAll()
        {
            var colores = _colorRepository.ObtenerTodos();
            if (colores == null)
            {
                throw new NullReferenceException();
            }


            return colores;
        }
        */
        #endregion


    }













}





/*public Colour GetById(string codigoColor)
{
    var color = _colorRepository.ObtenerTodos()
                                .Where(c => c.CodigoColor == codigoColor)
                                .FirstOrDefault();

    return color;

 throw new Exception("Ya existe un color con el codigo enviado, por favor ingrese uno distinto");

}*/

/*
 public async Task<Basket> AddItemToBasket(string username, int catalogItemId, decimal price, int quantity = 1)
    {
        var basketSpec = new BasketWithItemsSpecification(username);
        var basket = await _basketRepository.FirstOrDefaultAsync(basketSpec);

        if (basket == null)
        {
            basket = new Basket(username);
            await _basketRepository.AddAsync(basket);
        }

        basket.AddItem(catalogItemId, price, quantity);

        await _basketRepository.UpdateAsync(basket);
        return basket;
    }

    public async Task DeleteBasketAsync(int basketId)
    {
        var basket = await _basketRepository.GetByIdAsync(basketId);
        Guard.Against.Null(basket, nameof(basket));
        await _basketRepository.DeleteAsync(basket);
    }

    public async Task<Result<Basket>> SetQuantities(int basketId, Dictionary<string, int> quantities)
    {
        var basketSpec = new BasketWithItemsSpecification(basketId);
        var basket = await _basketRepository.FirstOrDefaultAsync(basketSpec);
        if (basket == null) return Result<Basket>.NotFound();

        foreach (var item in basket.Items)
        {
            if (quantities.TryGetValue(item.Id.ToString(), out var quantity))
            {
                if (_logger != null) _logger.LogInformation($"Updating quantity of item ID:{item.Id} to {quantity}.");
                item.SetQuantity(quantity);
            }
        }
        basket.RemoveEmptyItems();
        await _basketRepository.UpdateAsync(basket);
        return basket;
    }

    public async Task TransferBasketAsync(string anonymousId, string userName)
    {
        var anonymousBasketSpec = new BasketWithItemsSpecification(anonymousId);
        var anonymousBasket = await _basketRepository.FirstOrDefaultAsync(anonymousBasketSpec);
        if (anonymousBasket == null) return;
        var userBasketSpec = new BasketWithItemsSpecification(userName);
        var userBasket = await _basketRepository.FirstOrDefaultAsync(userBasketSpec);
        if (userBasket == null)
        {
            userBasket = new Basket(userName);
            await _basketRepository.AddAsync(userBasket);
        }
        foreach (var item in anonymousBasket.Items)
        {
            userBasket.AddItem(item.CatalogItemId, item.UnitPrice, item.Quantity);
        }
        await _basketRepository.UpdateAsync(userBasket);
        await _basketRepository.DeleteAsync(anonymousBasket);
    }
 
 
 
 */