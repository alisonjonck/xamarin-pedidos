using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Widget;
using Pedidos_App.droid.Adapters;
using Pedidos_Domain.Interfaces;
using Pedidos_Service.Services;

namespace Pedidos_App.droid
{
    [Activity(Label = "@string/listPromocoes", ParentActivity = typeof(MainActivity))]
    [MetaData(NavUtils.ParentActivity, Value = ".MainActivity")]
    public class ListPromocoesActivity : Activity
    {
        ListView listView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.ListPromocoes);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Catálogo";

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            LoadCatalogo();
        }

        async void LoadCatalogo()
        {
            ICatalogoService catalogoService = new CatalogoService();
            var catalogos = await catalogoService.GetPromocoesAsync();

            listView = FindViewById<ListView>(Resource.Id.promocoesListView);
            listView.Adapter = new CatalogoListAdapter(catalogos);
        }
    }
}