using MVC.Core.System;
using MVC.Core.System.Composite;
using System;
using System.Linq;

namespace MVC.Components.Panel
{
    public class PanelView : CompositeViewBase<NoModel>
    {
        public PanelView() : base(new NoModel(), new NoControllController<NoModel>(new NoModel()))
        {
        }
        public override int Height { get; set; } = 40;

        public override int Width { get; set; } = 115;

        protected override void Render()
        {
            string horizontalLine = $"{string.Concat(Enumerable.Repeat('-', Width))}";
            string verticalLine = $"-{string.Concat(Enumerable.Repeat(' ', Width - 2))}-";

            Console.SetCursorPosition(X, Y);
            Console.Write(horizontalLine);
            for (int i = 1; i < Height; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(string.Concat(verticalLine));

            }
            Console.SetCursorPosition(X, Y + Height);
            Console.Write(horizontalLine);

            base.Render();
        }

        public void AddSubView(IView<IModel> view, int marginTop = 2)
        {
            var lastEntry = ViewEntries.LastOrDefault();
            var yOffset = lastEntry.View == null ? marginTop : lastEntry.Slot.Y + lastEntry.View.Height + marginTop;

            base.AddSubView(view, 4, yOffset);
        }
    }
}
