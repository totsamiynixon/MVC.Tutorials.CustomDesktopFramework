using MVC.Core;
using MVC.Core.System;
using System;

using System.Linq;

namespace MVC.Components.Label
{
    public class LabelView : ViewBase<LabelModel>
    {
        public LabelView(LabelModel model) : base(model, new NoControllController<LabelModel>(model)) { }

        public override int Height { get; set; } = 1;
        public override int Width { get; set; } = 50;

        protected Action Cleanup;

        protected override void Render()
        {
            Cleanup?.Invoke();

            var x = X;
            var y = Y;

            Console.SetCursorPosition(x, y);
            Console.Write(string.Concat(Enumerable.Repeat(' ', Width)));
            Console.SetCursorPosition(x, y);
            Console.Write(Width < Model.Text.Length ? Model.Text.Substring(0, Width) : Model.Text);

            Cleanup = () =>
            {
                Console.SetCursorPosition(x, y);
                Console.Write(string.Concat(Enumerable.Repeat(' ', Width)));
            };

            base.Render();
        }

    }
}
