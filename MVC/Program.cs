using MVC.Core.System;
using MVC.Core.System.Control.Driver;
using MVC.EditUserInfoForm;

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

            // описать концепцию MVC/MMVC (Wiki, Smalltalk, Smalltalk Cookbock)
            // описать решение на конкретной задаче - терминал для редактирования пользовательских данных клавиатура вход, экран выход
            // Domain Model
            // UI to Domain Model as plugin
            // UI Input
            // UI Output
            // UI Connection to the Domain Model
            // UI Vies should be updated every time when input changes - that's the place for Observer pattern
            // UI Controller decomposition: UI Application Model / UI Domain Model / UI Behavior
            // финальная схема
            // для удобства MVC работает вокруг фреймворка
            // показать свой пример реализации на HMVC (схема, скриншоты, демо, ссылка на гитхаб)
            // один контроллер может управлять множеством моделей
            // описать ASP.NET MVC, Spring MVC, Apple MVC
            // вывод 0 MVC - разрабатывался в рамках концепции, что UI должен быть как plugin к Domain Model
            // вывод 1 MVC - концепция разделения ответственности, которая помимо классической подразумевает различные реализации
            // вывод 2 - когда спросят на собеседовании, что такое MVC - отвечать нужно в контексте фреймворка о котором идет разговор

        }
    }
}
