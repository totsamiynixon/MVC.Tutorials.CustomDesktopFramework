namespace MVC.Core
{
    public interface IControlHandlingController<out TModel> : IController<TModel> where TModel : IModel
    {
        public void HandleControl(IControlContext context);
    }
}
