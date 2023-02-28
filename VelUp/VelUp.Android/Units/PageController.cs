using System; using System.Collections.Generic;
using System.Collections.ObjectModel; 
using Xamarin.Forms; using Xamarin.Forms.Internals;

namespace VelUp.Droid.Units 
{
    public class PageController : IPageController

    {

        private ReflectedProxy<Page> _proxy;

        public event EventHandler<EventArg<VisualElement>> BatchCommitted;
        public event EventHandler<VisualElement.FocusRequestArgs> FocusChangeRequested;
        public event EventHandler PlatformSet;

        PageController(Page page)

        {

            _proxy = new ReflectedProxy<Page>(page);

        }

        #region -- Public properties -- 

        public Rectangle ContainerArea

        {

            get

            {

                return _proxy.GetPropertyValue<Rectangle>();

            }


            set

            {

                _proxy.SetPropertyValue(value);

            }

        }



        public bool IgnoresContainerArea

        {

            get

            {

                return _proxy.GetPropertyValue<bool>();

            }


            set

            {

                _proxy.SetPropertyValue(value);

            }

        }



        public ObservableCollection<Element> InternalChildren

        {

            get

            {

                return _proxy.GetPropertyValue<ObservableCollection<Element>>();

            }


            set

            {

                _proxy.SetPropertyValue(value);

            }

        }

        public bool Batched => throw new NotImplementedException();

        public bool DisableLayout { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public EffectiveFlowDirection EffectiveFlowDirection => throw new NotImplementedException();

        public bool IsInNativeLayout { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsNativeStateConsistent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsPlatformEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public NavigationProxy NavigationProxy => throw new NotImplementedException();

        public IEffectControlProvider EffectControlProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ReadOnlyCollection<Element> LogicalChildren => throw new NotImplementedException();

        public Element RealParent => throw new NotImplementedException();

        public IPlatform Platform { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion 

        #region -- IPageController implementation -- 

        public void SendAppearing()

        {

            _proxy.Call();

        }



        public void SendDisappearing()

        {

            _proxy.Call();

        }

        #endregion 

        public static IPageController Create(Page page)

        {
            return new PageController(page);

        }

        public void NativeSizeChanged()
        {
            throw new NotImplementedException();
        }

        public void InvalidateMeasure(InvalidationTrigger trigger)
        {
            throw new NotImplementedException();
        }

        public bool EffectIsAttached(string name)
        {
            throw new NotImplementedException();
        }

        public void SetValueFromRenderer(BindableProperty property, object value)
        {
            throw new NotImplementedException();
        }

        public void SetValueFromRenderer(BindablePropertyKey propertyKey, object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Element> Descendants()
        {
            throw new NotImplementedException();
        }
    } 
}