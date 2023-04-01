using Castle.Components.DictionaryAdapter.Xml;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebControlShoes.Application.Contratos;
using WebControlShoes.Application.Servicios;
using WebControlShoes.Domain.Entities;
using WebControlShoes.Domain.Repository;
using Zapatillas.Domain.Entities;

namespace UnitTest.Aplication
{
    public class InspeccionarCalzadoServicesTest
    {

        private readonly Mock<IRepository<OrdenProduccion>> mockOrdenesProduccionRepository = new ();
        private readonly Mock<IRepository<JornadaLaboral>> mockJornadasLaboralesRepository = new ();
        private readonly Mock<IRepository<LineaProduccion>> mockLineaProduccionRepository = new ();
        private readonly Mock<IRepository<Defecto>> mockDefectosRepository = new ();
        private readonly Mock<IRepository<Usuario>> mockSupervisorRepository = new ();


        [Fact]
        public async Task IniciarInspeccionAsyncConSuperivizorDeCalidadYaAsociadoCreaUnaNuevaJornadaLaboral()
        {
            var servicioInspeccionar = new InspeccionarCalzadoService(mockOrdenesProduccionRepository.Object,
                                                                      mockLineaProduccionRepository.Object,
                                                                      mockJornadasLaboralesRepository.Object,
                                                                      mockSupervisorRepository.Object,
                                                                      mockDefectosRepository.Object);
            var nameSupervizor = "Pedro";
            var password = "123";
            var rol = Rol.SupervisorCalidad;

            mockSupervisorRepository.Setup(s => s.BuscarByAsync(It.IsAny< Func<Usuario, bool>>()))
                .ReturnsAsync(new Usuario(nameSupervizor, password, rol));
           

            var codigoOP = "Z1";
            mockOrdenesProduccionRepository.Setup(s => s.BuscarByAsync(It.IsAny< Func<OrdenProduccion, bool>>()))
                .ReturnsAsync(new OrdenProduccion() 
                { 
                    CodigoOP = codigoOP,
                    Estado = Estado.Iniciada
                } );

           
            OrdenProduccion ordenfinal = await  servicioInspeccionar.IniciarInspeccionAsync(nameSupervizor, codigoOP);
            Assert.NotNull(ordenfinal.JornadasLaborales);
            
            
            // mockSupervisorRepository.Verify(x => x.BuscarByAsync(s => s.NameUsuario == nameSupervizor), Times.Once);
            // mockOrdenesProduccionRepository.Verify(x => x.BuscarByAsync(op => op.CodigoOP == codigoOP), Times.Once);


        }
    }
}




//mockOP.Verify(o => o.AsociarSupervisorCalidad(It.IsAny<string>(), It.IsAny<string>()));
/*
// Comprobacion
Assert.Equal(codigoOp, ordenfinal.CodigoOP);
*/
//mockOrdenesProduccionRepository.Setup(m=>m.)
//  .Throws(new InvalidOperationException("error al asociar supervisor de calidad"));

/* mockOP.Setup(o => o.AsociarSupervisorCalidad(supervizorCalidad))
                 .Returns(new OrdenProduccion() 
                 { 
                     CodigoOP = codigoOP,
                     Supervisores = new List<Usuario> { new Usuario(nameSupervizor, password, rol) }
                 });
          */
/*
var anonymousBasket = null as Basket;
var userBasket = new Basket(_existentUserBasketBuyerId);
_mockBasketRepo.SetupSequence(x => x.FirstOrDefaultAsync(It.IsAny<BasketWithItemsSpecification>(), default))
  .ReturnsAsync(anonymousBasket)
  .ReturnsAsync(userBasket);
var basketService = new BasketService(_mockBasketRepo.Object, _mockLogger.Object);
await basketService.TransferBasketAsync(_nonexistentAnonymousBasketBuyerId, _existentUserBasketBuyerId);
_mockBasketRepo.Verify(x => x.FirstOrDefaultAsync(It.IsAny<BasketWithItemsSpecification>(), default), Times.Once);
   */