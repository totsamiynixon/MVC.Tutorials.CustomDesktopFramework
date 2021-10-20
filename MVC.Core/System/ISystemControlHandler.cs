namespace MVC.Core.System
{
    public interface ISystemControlHandler
    {
        public void HandleControl(SystemController controller, IControlContext context);
    }
}
