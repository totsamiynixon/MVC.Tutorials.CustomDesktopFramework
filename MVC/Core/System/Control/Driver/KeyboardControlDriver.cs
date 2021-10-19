using System;
using System.Threading;

namespace MVC.Core.System.Control.Driver
{
    public class KeyboardControlDriver : IControlDriver
    {
        private Thread thread = null;

        public event IControlDriver.ControlHandler OnControl;

        public void Destroy()
        {
            thread.Abort();
        }

        public void Initialize()
        {
            thread = new Thread(() =>
            {
                while (true)
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
