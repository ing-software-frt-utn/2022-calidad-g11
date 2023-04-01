
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Linq.Expressions;
using WebControlShoes.Domain;
using WebControlShoes.Domain.Repository;

namespace WebControlShoes.Infastructure.Repositories
{
    public class MyRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {

        private readonly AppDbContext _context;

        internal DbSet<T> _dbSet;

        
        public MyRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public async Task<bool> AsyncSave()
        {
            return await _context.SaveChangesAsync() > 0;

        }


        #region Async CRUD

        public async Task<T> BuscarPorIdAsync<U>(U id) where U : notnull
        {
            return await _dbSet.FindAsync(id);
        }

        public  Task<T> BuscarByAsync(Func<T,bool> predicates) 
        {
            return Task.FromResult( _dbSet.FirstOrDefault(predicates)) ;
        }
        
        public async Task<T> BuscarPorIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<T> BuscarPorIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task EliminarAsync(string id)
        {
            T entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await AsyncSave();

        }

        public async Task<T> AgregarAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await AsyncSave();
            return entity; 
        }

        public async Task ModificarAsync(T entidad)
        {
            _dbSet.Update(entidad);
           await Task.FromResult( _context.SaveChangesAsync());
        }

        public async Task<IEnumerable<T>> ObtenerTodosAsync()
        {
            return await _dbSet.AsNoTracking()
                               .ToListAsync();
        }

        public async Task<bool> VerificarAsync(Func<T, bool> predicate)
        {
            return _dbSet.All(predicate);
        }
       
        public async Task<IEnumerable<T>> BuscarSiempreQueAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }







        //PARA IMPLEMENTACION SIN LAZY LOADING

        public async Task<T> BuscarAsync(string propertyNavegation, Func<T, bool> predicate)
        {
            return await _dbSet.Include(propertyNavegation)
                               .Where(predicate)
                               .AsQueryable()
                               .SingleAsync();
        }
        public async Task<IEnumerable<T>> getAllToUseLinq()
        {
            return _dbSet;
        }

        //METODO temporal
        public Task<IEnumerable<T>> BuscarWithChildsAsync(List<string> propertyNavegation, Func<T, bool> predicate)
        {

            switch (propertyNavegation.Count)
            {
                case 1:
                    return Task.FromResult(_dbSet.Include(propertyNavegation[0])
                               .Where(predicate));

                #region  ...
                case 2:
                    return Task.FromResult(_dbSet.Include(propertyNavegation[0])
                                          .Include(propertyNavegation[1])
                                          .Where(predicate));

                case 3:
                    return Task.FromResult(_dbSet.Include(propertyNavegation[0])
                          .Include(propertyNavegation[1])
                          .Include(propertyNavegation[2])
                          .Where(predicate));

                case 4:
                    return Task.FromResult(_dbSet.Include(propertyNavegation[0])
                          .Include(propertyNavegation[1])
                          .Include(propertyNavegation[2])
                          .Include(propertyNavegation[3])
                          .Where(predicate));

                case 5:
                    return Task.FromResult(_dbSet.Include(propertyNavegation[0])
                             .Include(propertyNavegation[1])
                             .Include(propertyNavegation[2])
                             .Include(propertyNavegation[3])
                             .Include(propertyNavegation[4])
                             .Where(predicate));
                case 6:
                    return Task.FromResult(_dbSet.Include(propertyNavegation[0])
                             .Include(propertyNavegation[1])
                             .Include(propertyNavegation[2])
                             .Include(propertyNavegation[3])
                             .Include(propertyNavegation[4])
                             .Include(propertyNavegation[5])
                             .Where(predicate));
                case > 6:
                    return Task.FromResult(_dbSet.Include(propertyNavegation[0])
                           .Include(propertyNavegation[1])
                           .Include(propertyNavegation[2])
                           .Include(propertyNavegation[3])
                           .Include(propertyNavegation[4])
                           .Include(propertyNavegation[5])
                           .Include(propertyNavegation[6])
                           .Where(predicate));

                default:
                    return null;
                    break;
                    #endregion

            }
        }


        #endregion








        public void Add(T entity)
        {
            _dbSet.Add(entity);

        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await _dbSet.ToListAsync() ;
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking();
        }

        



       

        public Task UpdateAsync(T entity)
        {
           _dbSet.Entry(entity).State = EntityState.Modified;
           return Task.FromResult(Save()) ;
        }

        



        public bool Save()
        {
            return _context.SaveChanges() > 0;

        }




        /*
        return await _dbSet.Include()

                           .Where(predicate)
                           .AsQueryable()
                           .SingleAsync();*/














        /*public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }*/



        /*
       public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
       {
           _dbSet.Where(predicate);
       }*/

        /*
public void Create(T entity)
{
   _dbSet.Add(entity);
}
public void Update(T entity)
{
   _dbSet.Update(entity);
}
public void Delete(T entity)
{
   _dbSet.Remove(entity);
}
public async Task<IEnumerable<T>> GetAllAsync()
{
   return await FindAll().ToListAsync();
}
*/




    }
}

/*
 
 

        /*
        public T BuscarPorId(string id)
        {
            return _dbSet.Find(id);
        }

        public T BuscarPorId(int id)
        {
            return _dbSet.Find(id);
        }


        public T Agregar(T entity)
        {
            _dbSet.Add(entity);
            Save();
            return entity;

        }

        public IEnumerable<T> BuscarWithChilds(List<string> propertyNavegation, Func<T, bool> predicate)
        {
            switch (propertyNavegation.Count)
            {
                case 1:
                    return _dbSet.Include(propertyNavegation[0])
                            .Where(predicate);

                #region  ...
                case 2:
                    return _dbSet.Include(propertyNavegation[0])
                          .Include(propertyNavegation[1])
                          .Where(predicate);

                case 3:
                    return _dbSet.Include(propertyNavegation[0])
                          .Include(propertyNavegation[1])
                          .Include(propertyNavegation[2])
                          .Where(predicate);

                case 4:
                    return _dbSet.Include(propertyNavegation[0])
                          .Include(propertyNavegation[1])
                          .Include(propertyNavegation[2])
                          .Include(propertyNavegation[3])
                          .Where(predicate);

                case 5:
                    return _dbSet.Include(propertyNavegation[0])
                             .Include(propertyNavegation[1])
                             .Include(propertyNavegation[2])
                             .Include(propertyNavegation[3])
                             .Include(propertyNavegation[4])
                             .Where(predicate);
                case 6:
                    return _dbSet.Include(propertyNavegation[0])
                             .Include(propertyNavegation[1])
                             .Include(propertyNavegation[2])
                             .Include(propertyNavegation[3])
                             .Include(propertyNavegation[4])
                             .Include(propertyNavegation[5])
                             .Where(predicate);
                case > 6:
                    return _dbSet.Include(propertyNavegation[0])
                           .Include(propertyNavegation[1])
                           .Include(propertyNavegation[2])
                           .Include(propertyNavegation[3])
                           .Include(propertyNavegation[4])
                           .Include(propertyNavegation[5])
                           .Include(propertyNavegation[6])
                           .Where(predicate);

                default:
                    return _dbSet.Include(propertyNavegation[0])
                           .Include(propertyNavegation[1])
                           .Include(propertyNavegation[2])
                           .Include(propertyNavegation[3])
                           .Include(propertyNavegation[4])
                           .Include(propertyNavegation[5])
                           .Include(propertyNavegation[6])
                           .Where(predicate);
                    #endregion

            }

        }*/




/*
     public T Get(int id)
     {
         return_dbSet.Find(id);
     }

     public IEnumerable<T> GetAll()
     {
         return Context.Set<T>().ToList();
     }

     public void Remove(T entity)
     {
         Context.Set<T>().Remove(entity);
     }

     public void RemoveAll(IEnumerable<T> entities)
     {
         Context.Set<T>().RemoveRange(entities);
     }

     */


/*
public async Task<T> Agregar(T entidad)
{
   // _context.Find(typeof(T), id);
   // return await _dbSet.AddAsync(entidad);
}*/



/*
        T Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
       
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveAll(IEnumerable<TEntity> entities);
 
 */






/*
 * 
private IQueryable<Modelo> Modelos => _context.Modelos
    //.Include(a => a.sku)   
    .AsQueryable();
*/


/*Modelo IModelRepository.GetById(int sku)
{
    throw new NotImplementedException();
}*/

// public IEnumerable<Modelo> GetAll() => Modelos.ToList();

/*
bool IModelRepository.Update(Modelo modelo)
{
    _context.Modelos.Update(modelo);
    try
    {
         _context.SaveChangesAsync();
        return true;
    }
    catch (DbException)
    {
        return false;
    }




}

 
 
 /*using (var ctx = new AppDbContext())
            {


                var colores =  ctx.Colors;
                );
            }

            return new _context.Colors.;
            */




/*
public async Task<Modelo> Create(Modelo modelo) 
{
    await _context.AddAsync(modelo);
    await _context.SaveChangesAsync();
    return modelo;

}*/