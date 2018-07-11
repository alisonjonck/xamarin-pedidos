using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
namespace Pedidos_App.droid
{
    [Activity(Label = "@string/listPromocoes")]
    public class ListPromocoesActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Create your application here
            var nomes = Intent.Extras.GetStringArrayList("nomes_promocoes") ?? new string[0];
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, nomes);
        }
    }
}