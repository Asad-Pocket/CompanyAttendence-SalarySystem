using GTRTraining.Data;
using Microsoft.EntityFrameworkCore;
namespace GTRTraining.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext _ctx;
        protected DbSet<TEntity> _dbSet;
        public Repository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<TEntity>();
        }
        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _ctx.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _ctx.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            _ctx.SaveChanges();
        }
        public IEnumerable<TEntity> GetAllItem()
        {
            var _list = _dbSet.ToList();
            return _list;
        }

        public TEntity GetById(int id)
        {
            var entity = _dbSet.Find(id);
            return entity;
        }


    }
}
