namespace BusinessLogic.Interfaces
{
    public interface IModelEqualityComparer<TModel> : IEqualityComparer<TModel> 
        where TModel : class, IModel
    {
    }
}
