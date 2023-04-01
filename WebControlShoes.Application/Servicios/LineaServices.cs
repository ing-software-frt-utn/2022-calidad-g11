using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebControlShoes.Application.Contratos;
using WebControlShoes.Domain.Entities;
using WebControlShoes.Domain.Repository;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Application.Servicios
{
    public class LineaServices : ILineaService
    {


        private readonly IConfiguration _configuration;
        public readonly IRepository<LineaProduccion> _lineaRepository;


        public LineaServices(IRepository<LineaProduccion> lineaRepository, IConfiguration configuration)
        {
            _lineaRepository = lineaRepository;
            _configuration = configuration;
        }

        public async Task<LineaProduccion> CrearLineaAsync(int nroLinea ,string description)
        {


            var Linea = new LineaProduccion(nroLinea,description);

            var texto = await _lineaRepository.AgregarAsync(Linea);

            return  texto;


        }

    }
}

        //public  LineaProduccion CrearLinea(string description)
        //{

        
        //    var Linea = new LineaProduccion(description);

        //    var texto  =_lineaRepository.AgregarAsync(Linea);

        //    return texto;
           

        //}