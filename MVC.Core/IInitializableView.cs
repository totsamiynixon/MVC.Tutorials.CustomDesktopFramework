namespace MVC
{
    public interface IInitializableView<out TModel> : IView<TModel>, IInitializable where TModel : IModel
    {

    }
}
