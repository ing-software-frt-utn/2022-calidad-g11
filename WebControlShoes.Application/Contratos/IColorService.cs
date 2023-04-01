using WebControlShoes.Application.DTOs;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Application.Contratos
{
    public interface IColorService  
    {
        
        Task<Colour> CrearColorAsync(string codigoColor, string description);
        Task<ColorDTO> GetByIdAsync(Guid id);
        Task<Colour> GetByCodigoColor(string codigoColor);
        Task<IEnumerable<Colour>> GetAllAsync();

        /*
           Colour CrearColor(string codigoColor, string description);
           ColorDTO GetById(string codigoColor);
           IEnumerable<Colour> GetAll(); 
       */
    }
}
