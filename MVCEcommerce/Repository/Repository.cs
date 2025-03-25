using Microsoft.EntityFrameworkCore;
using MVCEcommerce.Data;
using MVCEcommerce.Repository.IRepository;
using System.Linq.Expressions;
using MVCEcommerce.Extensions;


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
            _context.Products.Include(u => u.Category).Include(u => u.CategoryId);
        }

        public void Add(T entity)
        {
            contextSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = contextSet.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = contextSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }
            }
            return query.ToList();
        }


        //public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        //{
        //    return contextSet.Where(filter).IncludeProperties(includeProperties).FirstOrDefault();
        //}

        //public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        //{
        //    IQueryable<T> query = contextSet;
        //    query = query.Where(filter);
        //    if (!string.IsNullOrEmpty(includeProperties))
        //    {
        //        foreach (var includeProperty in includeProperties
        //            .Split(new char[] { ',' }, StringSplitOptions.
        //            RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProperty);
        //        }
        //    }
        //    return query.FirstOrDefault();
        //}

        //Categori, CoverType
        //public IEnumerable<T> GetAll(string? includeProperties = null)
        //{
        //    return contextSet.IncludeProperties(includeProperties).ToList();
        //}

        //public IEnumerable<T> GetAll(string? includeProperties = null)
        //{
        //    IQueryable<T> query = contextSet;
        //    if (!string.IsNullOrEmpty(includeProperties))
        //    {
        //        foreach (var includeProperty in includeProperties
        //            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProperty);
        //        }
        //    }
        //    return query.ToList();
        //}


        public void Remove(T entity)
        {
            contextSet.Remove(entity);
        }


        public void RemoveRange(IEnumerable<T> entity)
        {
            contextSet.RemoveRange(entity);
        }
    }
}
