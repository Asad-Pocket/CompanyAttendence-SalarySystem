namespace GTRTraining.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAllItem();
        public TEntity GetById(int id);
        public void Insert(TEntity item);
        public void Update(TEntity _item);
        public void Delete(int id);

    }
}
