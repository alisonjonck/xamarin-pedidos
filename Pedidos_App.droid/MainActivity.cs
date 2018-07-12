using Android.App;
using Android.Widget;
using Android.OS;
using Pedidos_Domain.Interfaces;
using Pedidos_Service.Services;
using System.Linq;
using Pedidos_Domain.Entities;
using Android.Content;
using System.Threading.Tasks;
using Pedidos_App.droid.Adapters;
using System.Collections.Generic;

namespace Pedidos_App.droid
{
    [Activity(Label = "Pedidos", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Pedidos";

            var btnCatagolo = FindViewById<Button>(Resource.Id.btnOpenCatalogo);

            btnCatagolo.Click += (sender, e) => {
                var intent = new Intent(this, typeof(ListPromocoesActivity));

                StartActivity(intent);
            };
        }
    }
}

