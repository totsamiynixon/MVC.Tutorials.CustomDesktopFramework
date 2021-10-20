using System.Collections.Generic;

namespace MVC.Core.System
{

    public class SystemController
    {
        public ICompositeView<IModel> RootView { get; set; }

        public IView<IModel> CurrentView { get; set; }

        public List<IControlDriver> Drivers { get; set; } = new List<IControlDriver>();

        public List<ISystemControlHandler> Handlers { get; set; } = new List<ISystemControlHandler>();

        public void Initialize()
        {
            foreach (var controlDriver in Drivers)
            {
                controlDriver.Initialize();
                controlDriver.OnControl += HandleControl;
            }

            TryCascadeInit(RootView);
            CurrentView = SetupInitialFocus(RootView);
        }

        public void Destroy()
        {
            foreach (var controlDriver in Drivers)
            {
                controlDriver.OnControl -= HandleControl;
                controlDriver.Destroy();
            }

            TryCascadeDestroy(CurrentView);
        }

        protected virtual void HandleControl(IControlContext controlContext)
        {
            TryHandleControl(CurrentView, controlContext);

            if (CurrentView is IFocusableView<IModel> focusableView)
            {
                focusableView.OnFocusOut();
            }

            if (controlContext.Handled == false)
            {
                foreach (var rootController in Handlers)
                {
                    rootController.HandleControl(this, controlContext);

                    if (controlContext.Handled)
                    {
                        break;
                    }
                }
            }

            if (CurrentView is IFocusableView<IModel> newFocusableView)
            {
                newFocusableView.OnFocusIn();
            }
        }

        private IView<IModel> SetupInitialFocus(IView<IModel> view)
        {
            if (view is IFocusableView<IModel> focusableView)
            {
                focusableView.OnFocusIn();

                return focusableView;
            }

            if (view is ICompositeView<IModel> compositeView)
            {
                foreach (var child in compositeView.Children)
                {
                    var childFocus = SetupInitialFocus(child);

                    if (childFocus != null)
                    {
                        return childFocus;
                    }
                }
            }

            return RootView;
        }

        private void TryCascadeInit(IView<IModel> view)
        {

            if (view is IControllableView<IModel> controllableView)
            {
                if (controllableView.Controller is IInitializableController<IModel> initializableController)
                {
                    initializableController.Initialize();
                }
            }

            if (view is IInitializableView<IModel> initializableView)
            {
                initializableView.Initialize();
            }

            if (view is ICompositeView<IModel> compositeView)
            {
                foreach (var child in compositeView.Children)
                {
                    TryCascadeInit(child);
                }
            }
        }

        private void TryCascadeDestroy(IView<IModel> view)
        {
            if (view is ICompositeView<IModel> compositeView)
            {
                foreach (var child in compositeView.Children)
                {
                    TryCascadeDestroy(child);
                }
            }

            if (view is IInitializableView<IModel> initializableView)
            {
                initializableView.Destroy();
            }

            if (view is IControllableView<IModel> controllableView)
            {
                if (controllableView.Controller is IInitializableController<IModel> initializableController)
                {
                    initializableController.Destroy();
                }
            }
        }

        private void TryHandleControl(IView<IModel> view, IControlContext controlContext)
        {

            if (view is IControllableView<IModel> controllableView)
            {
                if (controllableView.Controller is IControlHandlingController<IModel> controlHandlingController)
                {
                    controlHandlingController.HandleControl(controlContext);
                }
            }

            if (controlContext.Handled == false)
            {
                if (view.Parent != null)
                {
                    TryHandleControl(view.Parent, controlContext);
                }
            }
        }
    }
}
