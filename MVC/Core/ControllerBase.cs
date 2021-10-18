namespace MVC
{
    public abstract class ControllerBase<TModel> : IController<TModel> where TModel : IModel
    {
        public ControllerBase(TModel model)
        {
            Model = model;
        }

        public TModel Model { get; protected set; }

        public abstract void HandleControl(ControlEvent controlEvent);
    }
}
