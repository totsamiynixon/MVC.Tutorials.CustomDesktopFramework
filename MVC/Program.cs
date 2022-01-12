using MVC.Core.System;
using MVC.Core.System.Control.Driver;
using MVC.EditUserInfoFormModelCentric;

namespace MVC
{
    public class Program
    {
        static void Main(string[] args)
        {
            SystemController systemController = new SystemController();
            systemController.Drivers.Add(new KeyboardControlDriver());
            systemController.Handlers.Add(new SystemKeyboardControlHandler());

            systemController.RootView = EditUserInfoPageFactory.Create();

            systemController.Initialize();
        }
    }
}
