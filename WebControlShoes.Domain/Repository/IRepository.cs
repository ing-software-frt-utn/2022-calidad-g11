using System.Collections.Generic;
using System.Linq.Expressions;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Domain.Repository
{
    public  interface IRepository<T> where T : IAggregateRoot 
    {
        //ASYNC 

        Task<T> AgregarAsync(T entity);
        Task ModificarAsync(T entidad);
        Task EliminarAsync(string id);
        Task<T> BuscarPorIdAsync<U>(U id) where U : notnull;
        Task<IEnumerable<T>> ObtenerTodosAsync();
        Task<T> BuscarAsync(string propertyNavegation, Func<T, bool> predicate);
        Task<IEnumerable<T>> BuscarWithChildsAsync(List<string> propertyNavegation, Func<T, bool> predicate);
         Task UpdateAsync(T entity);
        Task<IEnumerable<T>> FindAll();
       // Task<IEnumerable<T>> getAllToUseLinq();
        Task<T> BuscarByAsync(Func<T, bool> predicates);


    }
}



/*
        T BuscarPorId(string id);
        T BuscarPorId(int id);
        T Agregar(T entity);
        IEnumerable<T> BuscarWithChilds(List<string> propertyNavegation, Func<T, bool> predicate);
        IEnumerable<T> ObtenerTodos();
        IQueryable<T> FindAll();
        void Update(T entity);
        */