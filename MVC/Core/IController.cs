using MVC.Core;
using System;

namespace MVC
{

    public interface ISystemControlHandler
    {
        public void HandleControl(SystemController controller, IControlContext context);
    }

    public interface IController<out TModel>
    {
        public TModel Model { get; }
    }

    public interface IInitializableController<out TModel> : IController<TModel>, IInitializable where TModel : IModel
    {

    }


    public interface IControlHandlingController<out TModel> : IController<TModel> where TModel : IModel
    {
        public void HandleControl(IControlContext context);
    }


    public interface IInitializable
    {
        public void Initialize();

        public void Destroy();
    }
}
