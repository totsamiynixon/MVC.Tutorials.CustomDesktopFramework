using System;
using System.ComponentModel;

namespace MVC.Core
{

    public abstract class ViewBase<TModel> : IView<TModel>, IInitializableView<TModel> where TModel : IModel
    {
        public ICompositeView<IModel> Parent { get; set; }

        public TModel Model { get; protected set; }

        public int X { get; set; }

        public int Y { get; set; }

        public abstract int Height { get; set; }

        public abstract int Width { get; set; }


        public ViewBase(TModel model)
        {
            this.Model = model;
        }

        public event OnRenderHandler OnRender;


        public virtual void Initialize()
        {
            Model.PropertyChanged += PropertyChanged;
            if (Parent != null)
                Parent.OnRender += OnParentRender;

            Render();
        }

        public virtual void Destroy()
        {
            Model.PropertyChanged -= PropertyChanged;
            if (Parent != null)
                Parent.OnRender -= OnParentRender;
        }

        protected virtual void Render()
        {
            OnRender?.Invoke(this);
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        protected virtual void OnParentRender(object sender)
        {
            Render();
        }

        protected virtual void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Render();
        }
    }

    public abstract class ControllableViewBase<TModel> : ViewBase<TModel>, IControllableView<TModel> where TModel : IModel
    {
        public IController<TModel> Controller { get; }

        public ControllableViewBase(TModel model, IController<TModel> controller) : base(model)
        {
            Controller = controller;
        }
    }
}
