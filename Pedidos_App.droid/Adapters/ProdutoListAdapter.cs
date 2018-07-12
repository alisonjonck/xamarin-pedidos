using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Views;
using Pedidos_App.droid.ViewModels;
using Pedidos_CrossCutting.Helpers;
using Pedidos_Domain.Entities;

namespace Pedidos_App.droid.Adapters
{
    public class ProdutoListAdapter : BaseAdapter<Produto>
    {
        List<Produto> _produtos;

        public ProdutoListAdapter(List<Produto> produtos)
        {
            _produtos = produtos;
        }

        public override Produto this[int position]
        {
            get
            {
                return _produtos[position];
            }
        }

        public override int Count
        {
            get
            {
                return _produtos.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.produtoRow, parent, false);

                var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);
                var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
                var price = view.FindViewById<TextView>(Resource.Id.priceTextView);

                view.Tag = new ProdutoViewModel() { Photo = photo, Name = name, Price = price };
            }

            var holder = (ProdutoViewModel)view.Tag;

            ImageViewAsync imageView = new ImageViewAsync(parent.Context);

            // When the image is loaded from internet 
            // the image is cached on disk by default 30 days
            ImageService.Instance.LoadUrl(_produtos[position].Photo).Into(imageView);

            holder.Photo.SetImageDrawable(imageView.Drawable);
            holder.Name.Text = _produtos[position].Name;
            holder.Price.Text = StringFormatter.ToBRLCurrency(_produtos[position].Price.ToString());

            return view;
        }
    }
}

