using System;

namespace MVC
{

    public interface IController<out TModel>
    {
        public TModel Model { get; }
    }
}
