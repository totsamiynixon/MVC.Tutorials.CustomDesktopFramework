namespace MVC
{
    public interface IController<out TModel> where TModel : IModel
    {
        public TModel Model { get; }

        public void HandleControl(ControlEvent controlEvent);
    }
}
