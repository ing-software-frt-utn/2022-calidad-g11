using Zapatillas.Domain.Entities;

namespace WebControlShoes.Domain.Entities
{
    public  class Usuario : EntidadBase<Guid>, IAggregateRoot
    {
        //public string _usuario;


        public Usuario( string nameUsuario, string password, Rol rol)
        {
            //IdUsuario = idUsuario;
            NameUsuario = nameUsuario;
            Password = password;
            Rol = rol;
        }
        
        public Usuario( )
        {
            
        }

       // public String IdUsuario { get; set; }
        public String NameUsuario { get; set; }
        public String Password { get; set; }
        public Rol Rol { get; set; }



        /*
                public static List<Usuario> DB()
                {
                    var list = new List<Usuario>()
                    {

                           INSERT INTO USUARIOS (NameUsuario,Password,Rol)  VALUES ('1','Lucas','SupervisorLinea');

        SupervisorLinea,
        SupervisorCalidad

                        new Usuario
                        {
                            idUsuario = "1",
                            nameUsuario = "Lucas",
                            password = "123",
                            rol = "Sup Calidad",
                        },
                        new Usuario
                        {
                            idUsuario = "2",
                            nameUsuario = "Juan",
                            password = "123",
                            rol = "Sup Calidad",
                        },
                        new Usuario
                        {
                            idUsuario = "3",
                            nameUsuario = "Raul",
                            password = "123",
                            rol = "Sup Linea",
                        },
                        new Usuario
                        {
                            idUsuario = "4",
                            nameUsuario = "Julian",
                            password = "123",
                            rol = "Sup Linea",
                        }
                };
                    return list;

                }
                */
    }
}
