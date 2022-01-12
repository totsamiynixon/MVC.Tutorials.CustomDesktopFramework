using MVC.Core;

namespace MVC
{

    public delegate void OnRenderHandler(object sender);

    public interface IView<out TModel> where TModel : IModel
    {
        public TModel Model { get; }

        public IController<TModel> Controller { get; }

        public ICompositeView<IModel> Parent { get; set; }

        public event OnRenderHandler OnRender;

        public int OffsetX { get; set; }
        public int OffsetY { get; set; }

        public int X { get; }

        public int Y { get; }

        public int Width { get; set; }

        public int Height { get; set; }

    }
}
