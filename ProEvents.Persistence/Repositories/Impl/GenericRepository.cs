namespace ProEvents.Persistence.Repositories.Impl
{
    public class GenericRepository : IGenericRepository
    {
        private readonly DataContext context;

        public GenericRepository(DataContext context)
        {
            this.context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entities) where T : class
        {
            context.RemoveRange(entities);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            context.Update(entity);
        }
    }
}
