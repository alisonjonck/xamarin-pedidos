using System;
using System.Collections.Generic;
using Android.Widget;

namespace Pedidos_App.droid.ViewModels
{
    public class CategoriaViewModel : Java.Lang.Object
    {
        public CategoriaViewModel()
        {
            Produtos = new List<ProdutoViewModel>();
        }

        public TextView Name { get; set; }

        public IList<ProdutoViewModel> Produtos { get; set; }
    }
}
