using System;
using System.Collections.Generic;
using System.Text;

namespace MVC.Core.System
{
    public class NoControllController<TModel> : IController<TModel>
    {
        public TModel Model { get; protected set; }

        public NoControllController(TModel model)
        {
            Model = model;
        }

        public void HandleControl(IControlContext context)
        {
            return;
        }
    }
}
