using En_YakınSatıcı.Core.Abstract;
using EnYakınSatıcı.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EnYakınSatıcı.Core.DataAcces.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var adddedEntity = context.Entry(entity);
                adddedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var delededEntity = context.Entry(entity);
                delededEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {

                return filter == null ? 
                    context.Set<TEntity>().ToList() 
                    : context.Set<TEntity>().Where(filter).ToList();
            }

        }

            public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
