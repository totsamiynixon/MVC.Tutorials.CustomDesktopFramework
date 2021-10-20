namespace MVC
{
    public interface IInitializableController<out TModel> : IController<TModel>, IInitializable where TModel : IModel
    {

    }
}
