namespace WebControlShoes.Domain.Contratos
{
    public interface IRepositorio<T> where T :  IAggregateRoot
    {
        void Agregar(T entidad, string conexion);
        void Modificar(int id,string query, string conexion);
        void Eliminar(int id, string conexion);
        IEnumerable<T> ObtenerTodos(string conexion);
        IEnumerable<T> Buscar<U>(string sql, U parametros, string conexion);
        T BuscarPorId(int id, string conexion);
    }
}
