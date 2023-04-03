using Moq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebControlShoes.Application.Servicios;
using WebControlShoes.Domain.Entities;
using WebControlShoes.Domain.Repository;
using Xunit.Sdk;
//using Zapaitllas.Domain.Entities;
using Zapatillas.Domain.Entities;

namespace UnitTest.Domain.EnitiesTest
{
    public class OrdenProduccionTest
    {
        private readonly Mock<IRepository<OrdenProduccion>> mockOrdenesProduccionRepository = new();
        private readonly Mock<IRepository<Usuario>> mockSupervisorRepository = new();

        [Fact]
        public async Task AsociarSupervisorCalidadExitosamente()
        {
            var nameSupervizor = "Pedro";
            var password = "123";
            var rol = Rol.SupervisorCalidad;

            mockSupervisorRepository.Setup(s => s.BuscarByAsync(It.IsAny<Func<Usuario, bool>>()))
                .ReturnsAsync(new Usuario(nameSupervizor, password, rol));


            var codigoOP = "Z1";
            mockOrdenesProduccionRepository.Setup(s => s.BuscarByAsync(It.IsAny<Func<OrdenProduccion, bool>>()))
                .ReturnsAsync(new OrdenProduccion()
                {
                    CodigoOP = codigoOP,
                    Estado = Estado.Iniciada
                });

            OrdenProduccion ordenAsociar = await mockOrdenesProduccionRepository.Object.BuscarByAsync(c => c.CodigoOP == codigoOP);
            Usuario supAsociar = await mockSupervisorRepository.Object.BuscarByAsync(s => s.NameUsuario == nameSupervizor);

            ordenAsociar.AsociarSupervisorCalidad(supAsociar);
            //Assert.NotNull(ordenAsociar.Supervisores);
            Assert.Equal(ordenAsociar.Supervisores.Find(s => s.Rol == Rol.SupervisorCalidad), supAsociar);
        }

        [Fact]
        public async Task AsociarSupervisorLineaExitosamente()
        {
            var nameSupervizor = "Raul";
            var password = "123";
            var rol = Rol.SupervisorLinea;

            mockSupervisorRepository.Setup(s => s.BuscarByAsync(It.IsAny<Func<Usuario, bool>>()))
                .ReturnsAsync(new Usuario(nameSupervizor, password, rol));


            var codigoOP = "Q1";
            mockOrdenesProduccionRepository.Setup(s => s.BuscarByAsync(It.IsAny<Func<OrdenProduccion, bool>>()))
                .ReturnsAsync(new OrdenProduccion()
                {
                    CodigoOP = codigoOP,
                    Estado = Estado.Iniciada
                });

            OrdenProduccion ordenAsociar = await mockOrdenesProduccionRepository.Object.BuscarByAsync(c => c.CodigoOP == codigoOP);
            Usuario supAsociar = await mockSupervisorRepository.Object.BuscarByAsync(s => s.NameUsuario == nameSupervizor);

            ordenAsociar.AsociarSupervisorLinea(supAsociar);
            Assert.Equal(ordenAsociar.Supervisores.Find(s => s.Rol == Rol.SupervisorLinea), supAsociar);
        }

        [Fact]
        public async Task PausarOrdenDeProduccionIniciadaExitosamente()
        {
            var codigoOP = "M1";
            mockOrdenesProduccionRepository.Setup(s => s.BuscarByAsync(It.IsAny<Func<OrdenProduccion, bool>>()))
                .ReturnsAsync(new OrdenProduccion()
                {
                    CodigoOP = codigoOP,
                    Estado = Estado.Iniciada,
                });
            OrdenProduccion ordenPausar = await mockOrdenesProduccionRepository.Object.BuscarByAsync(c => c.CodigoOP == codigoOP);

            ordenPausar.MarcarPausada();

            Assert.Equal(Estado.Pausada, ordenPausar.Estado);
        }

        [Fact]
        public async Task PausarOrdenDeProduccionNoIniciada()
        {
            var codigoOP = "S1";
            mockOrdenesProduccionRepository.Setup(s => s.BuscarByAsync(It.IsAny<Func<OrdenProduccion, bool>>()))
                .ReturnsAsync(new OrdenProduccion()
                {
                    CodigoOP = codigoOP,
                    Estado = Estado.Finalizada,
                });
            OrdenProduccion ordenPausar = await mockOrdenesProduccionRepository.Object.BuscarByAsync(c => c.CodigoOP == codigoOP);

            //accion o evento
            void act() => ordenPausar.MarcarPausada();
            InvalidOperationException exepcionCaptada = Assert.Throws<InvalidOperationException>(act);

            Assert.Equal("No se puede pausar una orden que no este iniciada", exepcionCaptada.Message);
        }

        [Fact]
        public async Task FinaliarOrdenDeProduccionIniciadaExitosamente()
        {
            var codigoOP = "J1";
            mockOrdenesProduccionRepository.Setup(s => s.BuscarByAsync(It.IsAny<Func<OrdenProduccion, bool>>()))
                .ReturnsAsync(new OrdenProduccion()
                {
                    CodigoOP = codigoOP,
                    Estado = Estado.Iniciada,
                });
            OrdenProduccion ordenFinalizar = await mockOrdenesProduccionRepository.Object.BuscarByAsync(c => c.CodigoOP == codigoOP);

            ordenFinalizar.MarcarFinalizada();

            Assert.Equal(Estado.Finalizada, ordenFinalizar.Estado);
        }


        [Fact]
        public async Task IntentarCrearJornadaLaboralConOrdenDeProduccionPausada()
        {
 

            var codigoOP = "J2";
            mockOrdenesProduccionRepository.Setup(s => s.BuscarByAsync(It.IsAny<Func<OrdenProduccion, bool>>()))
                .ReturnsAsync(new OrdenProduccion()
                {
                    CodigoOP = codigoOP,
                    Estado = Estado.Pausada
                });
            
            
            
            OrdenProduccion ordenJornada = await mockOrdenesProduccionRepository.Object.BuscarByAsync(c => c.CodigoOP == codigoOP);
 

 
            void act() => ordenJornada.CrearJornadaLaboral();
            InvalidOperationException exepcionCaptada = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal("error al asociar supervisor de calidad", exepcionCaptada.Message);

        }

        //[Fact]
        //public async Task ExceptionAlIntentarAsociarSupervisorCalidadAsociadoAOtraOP()
        //{
        //    Preparacion - Precondiciones
        //    var nameSupervizor = "Pedro";
        //    var password = "123";
        //    var rol = Rol.SupervisorCalidad;

        //    mockSupervisorRepository.Setup(s => s.BuscarByAsync(It.IsAny<Func<Usuario, bool>>()))
        //        .ReturnsAsync(new Usuario(nameSupervizor, password, rol));


        //    var codigoOP = "Z1";
        //    mockOrdenesProduccionRepository.Setup(s => s.BuscarByAsync(It.IsAny<Func<OrdenProduccion, bool>>()))
        //        .ReturnsAsync(new OrdenProduccion()
        //        {
        //            CodigoOP = codigoOP,
        //            Estado = Estado.Iniciada
        //        });

        //    OrdenProduccion ordenAsociada = await mockOrdenesProduccionRepository.Object.BuscarByAsync(c => c.CodigoOP == codigoOP);
        //    Usuario supAsociar = await mockSupervisorRepository.Object.BuscarByAsync(s => s.NameUsuario == nameSupervizor);

        //    ordenAsociada.AsociarSupervisorCalidad(supAsociar);

        //    var codOP = "Q1";
        //    mockOrdenesProduccionRepository.Setup(s => s.BuscarByAsync(It.IsAny<Func<OrdenProduccion, bool>>()))
        //        .ReturnsAsync(new OrdenProduccion()
        //        {
        //            CodigoOP = codigoOP,
        //            Estado = Estado.Iniciada
        //        });

        //    OrdenProduccion ordenAsociar = await mockOrdenesProduccionRepository.Object.BuscarByAsync(c => c.CodigoOP == codOP);

        //    //accion o evento
        //    //void act() => ordenAsociar.AsociarSupervisorCalidad(supAsociar);
        //    //var exepcionCaptada = Assert.Throws<InvalidOperationException>(act);

        //    //Comprobacion
        //    ordenAsociar.AsociarSupervisorCalidad(supAsociar);
        //    Assert.NotNull(ordenAsociar.Supervisores);
        //    //Se justifica que este test no pase
        //}



        /*
        [Fact]
        public void SupervisorAsociadoAOtraLinea() {
            //Preparacion-Precondiciones

            var supervisorLinea = new SupervisorLinea(435456);
            var ordenProduccion = new OrdenProduccion();
         
            ordenProduccion.SupervisorLinea = supervisorLinea;
            supervisorLinea.Estado=EstadoSup.ASOCIADO;
            
            var ordenInteresada = new OrdenProduccion();

            // accion o evento
            void act() => ordenInteresada.AsociarSupervisorLinea(supervisorLinea);
            var exepcionCaptada = Assert.Throws<InvalidOperationException>(act);

            // Comprobacion
            Assert.Equal("error al asociar supervisor de linea", exepcionCaptada.Message);
            Assert.Null(ordenInteresada.SupervisorLinea); 

            //Basta con captar la excepcion en el delegado, es mejor usar dos veces el metodo Asociar....
            //Se justifica que este test no pase si no pasa el anterior

        }*/

        //[Fact]
        //public void RegistrarDefectoDeObservadoEnLaHoraActualAlPieIzquierdoDentroDelTurno()
        //{
        /*
        //Preparacion - Precondiciones
        var turno = new Turno(horaInicio:0,
                              horaFin:23,
                              descripcion:"tarde");

        var JornadaLaboral = new JornadaLaboral(1,turno);

        var defecto = new Defecto(descripcion: "Suela mal pegada",
                                  tipo: TipoDefecto.Observado,
                                  pie: Pie.Izquierdo);

        var registro = new RegistroDefecto(defecto);
        // accion o evento
        JornadaLaboral.AddRegistro(registro: registro,
                                   hora: DateTime.Now.Hour);
        // Comprobacion
        Assert.Equal(registro, JornadaLaboral.Registros.Last());
     */
        //}

        /*
        [Fact]
        public async Task ShouldInvokeBasketRepositoryDeleteAsyncOnce()
        {
            var modelo = new Modelo();
           // var basket = new Basket(_buyerId);
            
            basket.AddItem(1, It.IsAny<decimal>(), It.IsAny<int>());
            basket.AddItem(2, It.IsAny<decimal>(), It.IsAny<int>());
            _mockBasketRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(basket);
            var basketService = new BasketService(_mockBasketRepo.Object, null);

            await basketService.DeleteBasketAsync(It.IsAny<int>());

            _mockBasketRepo.Verify(x => x.DeleteAsync(It.IsAny<Basket>()), Times.Once);
        }

        */


    }
}



//Agregar Trows otros metodos
//Controlar Cambio