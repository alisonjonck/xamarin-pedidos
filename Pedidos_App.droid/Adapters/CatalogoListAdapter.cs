using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Android.Content;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Views;
using Pedidos_App.droid.ViewModels;
using Pedidos_CrossCutting.Helpers;
using Pedidos_Domain.Entities;
using static Android.Views.View;

namespace Pedidos_App.droid.Adapters
{
    public class CatalogoListAdapter : BaseAdapter<object>
    {
        ObservableCollection<object> _catalogos;
        ObservableCollection<object> Catalogos
        {
            get { return _catalogos; }
            set
            {
                _catalogos = value;
                NotifyDataSetChanged();
            }
        }

        List<CatalogoPromocao> _catalogosPromocao = new List<CatalogoPromocao>();

        Toolbar _bottomToolbar;

        const int PRODUTO_ITEM = 0;

        const int HEADER = 1;

        public CatalogoListAdapter(Context context, List<CatalogoPromocao> catalogos, Toolbar bottomToolbar)
        {
            _bottomToolbar = bottomToolbar;
            Catalogos = new ObservableCollection<object>();

            foreach (var catalogo in catalogos)
            {
                Catalogos.Add(catalogo);
                _catalogosPromocao.Add(catalogo);

                foreach (var produto in catalogo.Produtos)
                {
                    Catalogos.Add(produto);
                }
            }
        }

        public override object this[int position] { get { return Catalogos[position]; } }

        public override int Count { get { return Catalogos.Count; } }

        public override long GetItemId(int position) { return position; }

        public override int GetItemViewType(int position)
        {
            if (Catalogos[position] is CatalogoPromocao)
            {
                return HEADER;
            }

            if (Catalogos[position] is Produto)
            {
                return PRODUTO_ITEM;
            }

            return base.GetItemViewType(position);
        }

        public override int ViewTypeCount => 2;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                switch (GetItemViewType(position))
                {
                    case PRODUTO_ITEM:
                        view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.produtoRow, parent, false);

                        var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);
                        var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
                        var price = view.FindViewById<TextView>(Resource.Id.priceTextView);
                        var quantidade = view.FindViewById<TextView>(Resource.Id.quantidadeTextView);
                        var promocao = view.FindViewById<TextView>(Resource.Id.promocaoTextView);

                        var increaseBtn = view.FindViewById<Button>(Resource.Id.btnIncreaseQuantidade);
                        var decreaseBtn = view.FindViewById<Button>(Resource.Id.btnDecreaseQuantidade);

                        view.Tag = new ProdutoViewModel() { Photo = photo, Name = name, Price = price, Quantidade = quantidade, ValorPromocao = promocao, DecreaseButton = decreaseBtn, IncreaseButton = increaseBtn };

                        break;

                    case HEADER:
                        view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CatalogoPromocaoRow, parent, false);

                        var promocaoName = view.FindViewById<TextView>(Resource.Id.promocaoNameTextView);

                        view.Tag = new CatalogoViewModel() { PromocaoName = promocaoName };

                        break;

                }

            }

            switch (GetItemViewType(position))
            {
                case PRODUTO_ITEM:
                    var holder = (ProdutoViewModel)view.Tag;

                    ImageViewAsync imageView = new ImageViewAsync(parent.Context);

                    var produto = Catalogos[position] as Produto;
                    // When the image is loaded from internet 
                    // the image is cached on disk by default 30 days
                    ImageService.Instance.LoadUrl(produto.Photo).Into(imageView);

                    holder.Photo.SetImageDrawable(imageView.Drawable);
                    holder.Name.Text = produto.Name;
                    holder.Price.Text = "R$ " + StringFormatter.ToBRLCurrency((produto?.PricePromocao > 0 ? produto.PricePromocao : produto.Price).ToString());
                    holder.Quantidade.Text = produto.Quantidade.ToString();
                    holder.ValorPromocao.Text = produto.DescontoPromocao != 0
                        ? StringFormatter.ToBRLCurrency(produto.DescontoPromocao.ToString()) + "% de desconto"
                        : "";

                    holder.IncreaseButton.SetOnClickListener(new OnClickListener(
                        () =>
                        {
                            produto.Quantidade += 1;
                            _updateValoresPromocaoProduto(produto);

                            _manageBottomToolbarComprar(parent, produto);

                            NotifyDataSetChanged();
                        }));

                    holder.DecreaseButton.SetOnClickListener(new OnClickListener(
                        () =>
                        {
                            try
                            {
                                produto.Quantidade -= 1;

                                _updateValoresPromocaoProduto(produto);

                                _manageBottomToolbarComprar(parent, produto);

                                NotifyDataSetChanged();
                            }
                            catch (ExceptionQuantidade ex)
                            {
                                // Quantidade não deve ser menor que zero
                            }
                        }));

                    break;

                case HEADER:
                    var holderHeader = (CatalogoViewModel)view.Tag;

                    holderHeader.PromocaoName.Text = (Catalogos[position] as CatalogoPromocao).Promocao.Name;
                    break;

            }

            return view;
        }

        ObservableCollection<Produto> _carrinho = new ObservableCollection<Produto>();
        void _manageBottomToolbarComprar(ViewGroup parent, Produto produto)
        {
            var produtoCarrinho = _carrinho.FirstOrDefault(c => c.Id == produto.Id);
            if (produtoCarrinho == null)
                _carrinho.Add(produto);
            else
            {
                if (produto.Quantidade > 0)
                    _carrinho[_carrinho.IndexOf(produtoCarrinho)] = produto;
                else
                    _carrinho.Remove(produtoCarrinho);
            }

            if (_carrinho.Count > 0)
                _bottomToolbar.Visibility = ViewStates.Visible;
            else
                _bottomToolbar.Visibility = ViewStates.Invisible;
        }

        async void _updateValoresPromocaoProduto(Produto produto)
        {
            var catalogoPromocao = await _getCatalogoPromocaoAsync(produto.CategoryId);

            var politica = catalogoPromocao.GetPoliticaPromocao(produto.Quantidade);

            if (politica != null)
            {
                produto.DescontoPromocao = politica.Discount;

                produto.PricePromocao = catalogoPromocao.GetPrecoPromocao(produto.Quantidade, produto.Id);
            }
            else
            {
                produto.DescontoPromocao = 0M;
                produto.PricePromocao = produto.Quantidade * produto.Price;
            }
        }

        async Task<CatalogoPromocao> _getCatalogoPromocaoAsync(int categoryId)
        {

            return await Task.FromResult(
                _catalogosPromocao.FirstOrDefault(c => c.Promocao.CategoryId == categoryId));
        }
    }

}


