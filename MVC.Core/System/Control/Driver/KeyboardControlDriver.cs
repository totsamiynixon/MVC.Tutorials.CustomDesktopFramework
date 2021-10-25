using System;
using System.Security.Permissions;
using System.Threading;

namespace MVC.Core.System.Control.Driver
{
    public class KeyboardControlDriver : IControlDriver
    {
        private bool _shouldGetControl = false;

        public event IControlDriver.ControlHandler OnControl;

        public void Destroy()
        {
            _shouldGetControl = false;
        }

        public void Initialize()
        {
            _shouldGetControl = true;
        }

        public void TryGetControl()
        {
            if (_shouldGetControl && Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);

                OnControl?.Invoke(new KeyboardControlContext
                {
                    KeyInfo = key
                });
            }
        }
    }
}
