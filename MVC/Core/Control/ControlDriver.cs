using System;

namespace MVC
{
    public static class ControlDriver
    {

        public  delegate void ControlHandler(ControlEvent controlEvent);

        public static event ControlHandler OnControl;

        public static void ListenForInput() {

            while (true)
            {
                var key = Console.ReadKey(true);

                OnControl(new ControlEvent
                {
                    Type = EventType.Keyboard,
                    Payload = key
                });
            }
        }
    }
}
