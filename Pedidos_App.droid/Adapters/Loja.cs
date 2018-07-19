using System;
using System.Collections.ObjectModel;
using Pedidos_Domain.Entities;

namespace Pedidos_App.droid.Adapters
{
    public static class Loja
    {
        public static ObservableCollection<Produto> Carrinho = new ObservableCollection<Produto>();
    }
}
