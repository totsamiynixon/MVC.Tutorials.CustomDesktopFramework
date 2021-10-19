using MVC.Core;
using MVC.Core.System;
using MVC.Core.System.Control.Driver;
using MVC.Sample;
using MVC.Sample.UserInfoForm;
using System;

namespace MVC
{
    public class Program
    {
        public static SystemController CurrentController { get; }

/*        static void Mainv2(string[] args)
        {
            var fakeApiPage = new NameRandomizer();


            SystemController systemController = new SystemController();
            systemController.RootView = fakeApiPage.View;
            systemController.Drivers.Add(new KeyboardControlDriver());
            systemController.Handlers.Add(new SystemKeyboardControlHandler());

            fakeApiPage.Initialize();
            systemController.Initialize();
        }

        static void Mainv3(string[] args)
        {

            var userInfoForm = new UserInfoForm();


            SystemController systemController = new SystemController();
            systemController.RootView = userInfoForm.View;
            systemController.Drivers.Add(new KeyboardControlDriver());
            systemController.Handlers.Add(new SystemKeyboardControlHandler());

            userInfoForm.Initialize();
            systemController.Initialize();

        }*/

        static void Main(string[] args)
        {

            SystemController systemController = new SystemController();
            systemController.RootView = UserInfoFactory.Create();
            systemController.Drivers.Add(new KeyboardControlDriver());
            systemController.Handlers.Add(new SystemKeyboardControlHandler());

            systemController.Initialize();

        }
    }
}
