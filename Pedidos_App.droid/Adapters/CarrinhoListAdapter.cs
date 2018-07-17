using System;
using System.Collections.ObjectModel;
using Android.Content;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Views;
using Pedidos_App.droid.ViewModels;
using Pedidos_CrossCutting.Helpers;
using Pedidos_Domain.Entities;

namespace Pedidos_App.droid.Adapters
{
    public class CarrinhoListAdapter : BaseAdapter<Produto>
    {
        ObservableCollection<Produto> _produtos;
        ObservableCollection<Produto> Produtos
        {
            get { return _produtos; }
            set
            {
                _produtos = value;
                NotifyDataSetChanged();
            }
        }

        Toolbar _bottomToolbar;
        Button _btnComprarBottomToolbar;

        public CarrinhoListAdapter(Context context, ObservableCollection<Produto> produtos, Toolbar bottomToolbar)
        {
            _bottomToolbar = bottomToolbar;
            _btnComprarBottomToolbar = _bottomToolbar.FindViewById<Button>(Resource.Id.btnComprar);

            _btnComprarBottomToolbar.Text = "FINALIZAR A COMPRA";
            _btnComprarBottomToolbar.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);
            _btnComprarBottomToolbar.Click += (sender, e) =>
            {
                // Toast.MakeText(context, Resource.String.FinalizadoSimulacaoCompra, ToastLength.Long);
            };

            Produtos = new ObservableCollection<Produto>();

            foreach (var produto in produtos)
            {
                Produtos.Add(produto);
            }
        }

        public override Produto this[int position] { get { return Produtos[position]; } }

        public override int Count { get { return Produtos.Count; } }

        public override long GetItemId(int position) { return position; }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.produtoRow, parent, false);

                var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);
                var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
                var price = view.FindViewById<TextView>(Resource.Id.priceTextView);
                var quantidade = view.FindViewById<TextView>(Resource.Id.quantidadeTextView);
                var promocao = view.FindViewById<TextView>(Resource.Id.promocaoTextView);

                var increaseBtn = view.FindViewById<Button>(Resource.Id.btnIncreaseQuantidade);
                increaseBtn.Visibility = ViewStates.Invisible;
                var decreaseBtn = view.FindViewById<Button>(Resource.Id.btnDecreaseQuantidade);
                decreaseBtn.Visibility = ViewStates.Invisible;

                view.Tag = new ProdutoViewModel() { Photo = photo, Name = name, Price = price, Quantidade = quantidade, ValorPromocao = promocao, DecreaseButton = decreaseBtn, IncreaseButton = increaseBtn };
            }

            var holder = (ProdutoViewModel)view.Tag;

            ImageViewAsync imageView = new ImageViewAsync(parent.Context);

            var produto = Produtos[position];
            // When the image is loaded from internet 
            // the image is cached on disk by default 30 days
            ImageService.Instance.LoadUrl(produto.Photo).Into(imageView);

            holder.Photo.SetImageDrawable(imageView.Drawable);
            holder.Name.Text = produto.Name;
            holder.Price.Text = "R$ " + StringFormatter.ToBRLCurrency((produto.PricePromocao > 0 ? produto.PricePromocao : produto.Price).ToString());
            holder.Quantidade.Text = produto.Quantidade.ToString();
            holder.ValorPromocao.Text = produto.DescontoPromocao != 0
                ? StringFormatter.ToBRLCurrency(produto.DescontoPromocao.ToString()) + "% de desconto"
                : "";

            return view;
        }

        public override bool IsEnabled(int position)
        {
            return false;
        }
    }

}


