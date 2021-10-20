namespace MVC
{
    public interface IFocusableView<out TModel> : IView<TModel> where TModel : IModel
    {
        public void OnFocusIn();

        public void OnFocusOut();
    }
}
