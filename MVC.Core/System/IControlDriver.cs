namespace MVC.Core.System
{
    public interface IControlDriver
    {
        public delegate void ControlHandler(IControlContext controlEvent);

        public event ControlHandler OnControl;

        public void Initialize();

        public void Destroy();
    }
}
