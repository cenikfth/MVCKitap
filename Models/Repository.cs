using Microsoft.EntityFrameworkCore;
using WebUygulamaProje1.Models.Utility;

namespace WebUygulamaProje1.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UygulamaDbContext _uygulamaDbContext;
        internal DbSet<T> dbSet;
        public Repository(UygulamaDbContext uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
            this.dbSet = _uygulamaDbContext.Set<T>();
            _uygulamaDbContext.Kitaplar.Include(f => f.KitapTuru).Include(f => f.KitapTuruId);
        }
        public void Ekle(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filtre, string? includeProps = null)
        {
            IQueryable<T>   sorgu = dbSet.Where(filtre);
            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var prop in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                   sorgu = sorgu.Include(prop);
                }
            }
            return sorgu.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProps = null)
        {
            IQueryable<T> sorgu = dbSet;
            if(!string.IsNullOrEmpty(includeProps))
            {
                foreach(var prop in includeProps.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)){
                   sorgu = sorgu.Include(prop);
                }
            }
            var a = sorgu.ToList();
            return sorgu.ToList();
        }

        public void Sil(T entity)
        {
            dbSet.Remove(entity);
        }

        public void SilAralik(IEnumerable<T> entities)
        {

            dbSet.RemoveRange(entities);
        }
    }
}

