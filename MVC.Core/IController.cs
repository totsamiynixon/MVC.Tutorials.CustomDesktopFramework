using MVC.Core;
using System;

namespace MVC
{

    public interface IController<out TModel>
    {
        public TModel Model { get; }

        public void HandleControl(IControlContext context);
    }
}
