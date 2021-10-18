namespace MVC
{
    public struct ControlEvent
    {
        public EventType Type { get; set; }

        public bool Handled { get; set; }

        public object Payload { get; set; }
    }
}
