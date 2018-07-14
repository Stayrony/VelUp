using System;
using VelUp.Controls;
using VelUp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace VelUp.Droid.Renderers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        #region -- Overrides --

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            var view = (ExtendedEntry)Element;
            if (!view.HasBorder)
                SetBorder(view);

            if (this.Element.Keyboard == Keyboard.Telephone)
            {
                Control.ImeOptions = Android.Views.InputMethods.ImeAction.Done;
                Control.SetSingleLine(true);
                Control.SetImeActionLabel("Done", Android.Views.InputMethods.ImeAction.Done);
            }

            Control.SetPadding(0, 0, 0, 0);
            Control.TextAlignment = Android.Views.TextAlignment.Center;
            Control.Gravity = Android.Views.GravityFlags.CenterVertical;
        }

        #endregion

        #region -- Private helpers --

        private void SetBorder(ExtendedEntry view)
        {
            if (Control != null)
            {
                Control.SetBackgroundColor(Color.Transparent.ToAndroid());
            }
        }

        #endregion
    }
}
