using System;
using Android.Views;

namespace Pedidos_App.droid.Adapters
{
    public class OnClickListener : Java.Lang.Object, View.IOnClickListener
    {
        Action _action;

        public OnClickListener(Action action)
        {
            _action = action;
        }

        public void OnClick(View v)
        {
            _action.Invoke();
        }
    }
}
