using System;
using System.ComponentModel;

namespace MVC
{

    public abstract class ViewBase<TModel> : IView<TModel> where TModel : IModel
    {
        public IView<IModel> Parent { get; set; }

        public IController<TModel> Controller { get; protected set; }

        public TModel Model { get; protected set; }

        public int X { get; set; }

        public int Y { get; set; }

        public abstract int Height { get; set; }

        public abstract int Width { get; set; }

        public ViewBase(TModel model, IController<TModel> controller)
        {
            this.Model = model;
            this.Controller = controller;
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
}
