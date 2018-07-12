using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Pedidos_App.droid.ViewModels;
using Pedidos_Domain.Entities;

namespace Pedidos_App.droid.Adapters
{
    public class CatalogoListAdapter : BaseAdapter<CatalogoPromocao>
    {
        List<CatalogoPromocao> _catalogos;

        public CatalogoListAdapter(List<CatalogoPromocao> catalogos)
        {
            _catalogos = catalogos;
        }

        public override CatalogoPromocao this[int position]
        {
            get
            {
                return _catalogos[position];
            }
        }

        public override int Count
        {
            get
            {
                return _catalogos.Count;
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
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CatalogoPromocaoRow, parent, false);

                var promocaoName = view.FindViewById<TextView>(Resource.Id.promocaoNameTextView);

                view.Tag = new CatalogoViewModel() { PromocaoName = promocaoName };
            }

            var holder = (CatalogoViewModel)view.Tag;

            holder.PromocaoName.Text = _catalogos[position].Promocao.Name;

            return view;
        }
    }
}

