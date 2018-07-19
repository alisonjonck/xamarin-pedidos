using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Pedidos_App.droid.Adapters;

namespace Pedidos_App.droid
{
    [Activity(Label = "@string/listCarrinho", ParentActivity = typeof(ListPromocoesActivity))]
    [MetaData(NavUtils.ParentActivity, Value = ".ListPromocoesActivity")]
    public class ListCarrinhoActivity : Activity
    {
        ListView listView;
        Toolbar bottomToolbar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.ListCarrinho);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Carrinho";

            bottomToolbar = FindViewById<Toolbar>(Resource.Id.bottomToolbar);
            bottomToolbar.Visibility = ViewStates.Visible;

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            LoadCarrinho();
        }

        void LoadCarrinho()
        {
            listView = FindViewById<ListView>(Resource.Id.carrinhoListView);

            listView.Adapter = new CarrinhoListAdapter(this, Loja.Carrinho, bottomToolbar);

            View footerView = new LinearLayout(this);
            footerView.SetPadding(0, 0, 0, 130);

            listView.AddFooterView(footerView);
        }
    }
}