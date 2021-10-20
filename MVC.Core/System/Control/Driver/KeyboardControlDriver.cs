using System;
using System.Security.Permissions;
using System.Threading;

namespace MVC.Core.System.Control.Driver
{
    public class KeyboardControlDriver : IControlDriver
    {
        private Thread thread = null;
        private bool _isListening = false;

        public event IControlDriver.ControlHandler OnControl;

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void Destroy()
        {
            _isListening = false;
        }

        public void Initialize()
        {
            _isListening = true;

            thread = new Thread(() =>
            {
                while (_isListening)
                {
                    var key = Console.ReadKey(true);

                    OnControl(new KeyboardControlContext
                    {
                        KeyInfo = key
                    });
                }
            });

            thread.Start();

        }
    }
}
