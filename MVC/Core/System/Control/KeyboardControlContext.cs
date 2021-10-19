using System;

namespace MVC.Core.System.Control
{
    public class KeyboardControlContext : IControlContext
    {
        public bool Handled { get; set; }

        public ConsoleKeyInfo KeyInfo { get; set; }
    }
}
