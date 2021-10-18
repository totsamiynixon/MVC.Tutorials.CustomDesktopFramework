namespace MVC
{
    public delegate void OnRenderHandler(object sender);

    public interface IView<out TModel> where TModel : IModel
    {
        public TModel Model { get; }

        public IController<TModel> Controller { get; }

        public ICompositeView<IModel> Parent { get; set; }

        public event OnRenderHandler OnRender;

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public void Initialize();

        public void Destroy();

    }

    public interface IFocusableView<out TModel> : IView<TModel> where TModel : IModel
    {
        public void OnFocusIn();

        public void OnFocusOut();
    }
}
