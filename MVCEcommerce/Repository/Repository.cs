using Microsoft.EntityFrameworkCore;
using MVCEcommerce.Data;
using MVCEcommerce.Repository.IRepository;
using System.Linq.Expressions;


namespace MVCEcommerce.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> contextSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.contextSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            contextSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = contextSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        //public T Get(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = contextSet;
            return query.ToList();
        }

        //public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        //{
        //    throw new NotImplementedException();
        //}

        public void Remove(T entity)
        {
            contextSet.Remove(entity);
        }

        //public void Remove(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public void RemoveRange(IEnumerable<T> entity)
        {
            contextSet.RemoveRange(entity);
        }
    }
}
