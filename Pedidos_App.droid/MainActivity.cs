using Android.App;
using Android.Widget;
using Android.OS;
using Pedidos_Domain.Interfaces;
using Pedidos_Service.Services;
using System.Linq;

namespace Pedidos_App.droid
{
    [Activity(Label = "Pedidos_App.droid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            IProdutoService produtoService = new ProdutoService();

            button.Click += async delegate
            {
                var list = await produtoService.GetProdutosAsync();
                button.Text = $"{list.Count()} Produtos cadastrados!";
            };
        }
    }
}

