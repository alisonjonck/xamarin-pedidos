using Android.Widget;

namespace Pedidos_App.droid.ViewModels
{
    public class ProdutoViewModel : Java.Lang.Object
    {
        public ProdutoViewModel()
        {
        }

        public ImageView Photo { get; set; }

        public TextView Name { get; set; }

        public TextView Price { get; set; }

        public TextView ValorPromocao { get; set; }

        public TextView Quantidade { get; set; }

        public Button IncreaseButton { get; set; }

        public Button DecreaseButton { get; set; }
    }
}
