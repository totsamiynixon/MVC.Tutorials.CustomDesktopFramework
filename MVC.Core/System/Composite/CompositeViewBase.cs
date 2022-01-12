using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Core.System.Composite
{
    public abstract class CompositeViewBase<TModel> : ViewBase<TModel>, ICompositeView<TModel> where TModel : IModel
    {
        public CompositeViewBase(TModel model, IController<TModel> controller) : base(model, controller)
        {
        }

        protected LinkedList<ViewEntry> ViewEntries { get; } = new LinkedList<ViewEntry>();

        public LinkedList<IView<IModel>> Children => new LinkedList<IView<IModel>>(ViewEntries.Select(p => p.View));


        public override void Initialize()
        {
            base.Initialize();

            foreach (var viewEntry in ViewEntries)
            {
                viewEntry.View.OffsetX = viewEntry.Slot.X;
                viewEntry.View.OffsetY = viewEntry.Slot.Y;
                viewEntry.View.Parent = (ICompositeView<IModel>)this;
            }
        }

        public override void Destroy()
        {
            base.Destroy();

            foreach (var viewEntry in ViewEntries)
            {
                (viewEntry.View as IInitializableView<IModel>)?.Destroy();
            }
        }

        protected void AddSubView<TView>(TView view, int offsetX, int offsetY) where TView : IView<IModel>
        {
            ViewEntries.AddLast(new ViewEntry
            {
                View = view,
                Slot = new ViewSlot
                {
                    X = offsetX,
                    Y = offsetY
                }
            });
        }

        protected struct ViewSlot
        {
            public int X { get; set; }

            public int Y { get; set; }
        }

        protected struct ViewEntry
        {
            public IView<IModel> View { get; set; }

            public ViewSlot Slot { get; set; }

        }
    }
}
