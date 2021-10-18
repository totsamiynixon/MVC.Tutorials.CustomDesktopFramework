using MVC.Models;
using MVC.Sample;
using System;

namespace MVC
{
    public class Program
    {
        public static SystemController CurrentController { get; }

        static void Mainv2(string[] args)
        {
            var fakeApiPage = new NameRandomizer();


            var noModel = new NoModel();
            SystemController systemController = new SystemController(noModel);
            systemController.RootView = fakeApiPage.View;

            fakeApiPage.Initialize();
            systemController.Initialize();

            ControlDriver.ListenForInput();
        }

        static void Main(string[] args)
        {

            var userInfoForm = new UserInfoForm();


            var noModel = new NoModel();
            SystemController systemController = new SystemController(noModel);
            systemController.RootView = userInfoForm.View;

            userInfoForm.Initialize();
            systemController.Initialize();

            ControlDriver.ListenForInput();
        }
    }
}
