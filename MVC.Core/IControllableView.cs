namespace MVC
{
    public interface IControllableView<out TModel> : IView<TModel> where TModel : IModel
    {
        public IController<TModel> Controller { get; }
    }
}
