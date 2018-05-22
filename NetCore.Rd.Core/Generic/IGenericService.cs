namespace NetCore.Rd.Core.Generic
{
    public interface IGenericService<TEntity> : IGenericInterface<TEntity> where TEntity : class
    {
    }
}
