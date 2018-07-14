using System.Collections.Generic;
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
    public class CatalogoListAdapter : BaseAdapter<object>
    {
        List<object> _catalogos = new List<object>();

        const int PRODUTO_ITEM = 0;

        const int HEADER = 1;

        LayoutInflater layoutInflater;

        public CatalogoListAdapter(Context context, List<CatalogoPromocao> catalogos)
        {
            foreach (var catalogo in catalogos)
            {
                _catalogos.Add(catalogo);

                foreach (var produto in catalogo.Produtos)
                {
                    _catalogos.Add(produto);
                }
            }

            layoutInflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
        }

        public override object this[int position] { get { return _catalogos[position]; } }

        public override int Count { get { return _catalogos.Count; } }

        public override long GetItemId(int position) { return position; }

        public override int GetItemViewType(int position)
        {
            if (_catalogos[position] is CatalogoPromocao)
            {
                return HEADER;
            }

            if (_catalogos[position] is Produto)
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

                        view.Tag = new ProdutoViewModel() { Photo = photo, Name = name, Price = price };

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

                    var produto = _catalogos[position] as Produto;
                    // When the image is loaded from internet 
                    // the image is cached on disk by default 30 days
                    ImageService.Instance.LoadUrl(produto.Photo).Into(imageView);

                    holder.Photo.SetImageDrawable(imageView.Drawable);
                    holder.Name.Text = produto.Name;
                    holder.Price.Text = StringFormatter.ToBRLCurrency(produto.Price.ToString());
                    break;

                case HEADER:
                    var holderHeader = (CatalogoViewModel)view.Tag;

                    holderHeader.PromocaoName.Text = (_catalogos[position] as CatalogoPromocao).Promocao.Name;
                    break;

            }

            return view;
        }
    }



}


