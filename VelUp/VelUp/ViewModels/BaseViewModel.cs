using System;
using VelUp.Views;
using Prism.Mvvm;

namespace VelUp.ViewModels
{
    public class BaseViewModel : BindableBase, IViewActionsHandler
    {
        #region -- IViewActionsHandler implementation --

        public virtual void OnAppearing()
        {
            
        }

        public virtual void OnDisappearing()
        {
        }

        #endregion
    }
}
