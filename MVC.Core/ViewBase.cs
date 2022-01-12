using MVC.Core.System;
using System;
using System.ComponentModel;

namespace MVC.Core
{

    public abstract class ViewBase<TModel> : IView<TModel>, IInitializableView<TModel> where TModel : IModel
    {
        private bool _isInitialized;

        private int _height;
        private int _width;
        private int _offsetX;
        private int _offsetY;

        public TModel Model { get; protected set; }

        public IController<TModel> Controller { get; protected set; }

        public ICompositeView<IModel> Parent { get; set; }

        public int X => (Parent?.X ?? 0) + OffsetX;

        public int Y => (Parent?.Y ?? 0) + OffsetY;

        public virtual int Height
        {
            get => _height;
            set { _height = value; OnViewPropertyChanged(nameof(Height)); }
        }

        public virtual int Width
        {
            get => _width;
            set { _width = value; OnViewPropertyChanged(nameof(Width)); }
        }

        public int OffsetX
        {
            get => _offsetX;
            set { _offsetX = value; OnViewPropertyChanged(nameof(OffsetX)); }
        }

        public int OffsetY
        {
            get => _offsetY;
            set { _offsetY = value; OnViewPropertyChanged(nameof(OffsetY)); }
        }

        public ViewBase(TModel model, IController<TModel> controller)
        {
            this.Model = model;
            this.Controller = controller;
        }

        public event OnRenderHandler OnRender;


        public virtual void Initialize()
        {
            Model.PropertyChanged += ModelPropertyChanged;
            if (Parent != null)
                Parent.OnRender += OnParentRender;

            _isInitialized = true;

            Render();
        }

        public virtual void Destroy()
        {
            Model.PropertyChanged -= ModelPropertyChanged;
            if (Parent != null)
                Parent.OnRender -= OnParentRender;

            _isInitialized = false;
        }

        protected virtual void Render()
        {
            OnRender?.Invoke(this);
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        protected virtual void OnParentRender(object sender)
        {
            if (_isInitialized) Render();
        }

        protected virtual void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_isInitialized) Render();
        }

        protected virtual void OnViewPropertyChanged(string propertyName)
        {
            if (_isInitialized) Render();
        }
    }
}
