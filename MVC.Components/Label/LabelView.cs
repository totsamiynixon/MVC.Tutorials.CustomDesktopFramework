using MVC.Core;
using System;

using System.Linq;

namespace MVC.Components.Label
{
    public class LabelView : ViewBase<LabelModel>
    {
        public LabelView(LabelModel model) : base(model)
        {
           
        }

        public override int Height { get; set; } = 1;
        public override int Width { get; set; } = 100;

        protected override void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(string.Concat(Enumerable.Repeat(' ', Width)));
            Console.SetCursorPosition(X, Y);
            Console.Write(Width < Model.Text.Length ? Model.Text.Substring(0, Width) : Model.Text);

            base.Render();
        }
    }
}
