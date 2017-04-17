using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using MultiLevelListViewApp.Models;
using MultiLevelListViewApp.Views;
using PL.Openrnd.Multilevellistview;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiLevelListViewApp
{
    public class ListAdapter : MultiLevelListAdapter
    {
        private readonly IDataProvider _dataProvider;

        public ListAdapter(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        private string GetItemInfoDescription(IItemInfo itemInfo)
        {
            return string.Concat(string.Format("level{0}, idx in level {1}/{2}", itemInfo.Level + 1, itemInfo.IdxInLevel + 1, itemInfo.LevelSize), (itemInfo.IsExpanded ? string.Format(", expanded {0}", itemInfo.IsExpanded) : string.Empty));
        }

        protected override IList<object> GetSubObjects(Java.Lang.Object obj)
        {
            IList<object> list = _dataProvider.GetSubItems(obj.Cast<BaseItem>()).ToList<object>();
            return list;
        }

        protected override View GetViewForObject(Java.Lang.Object obj, View convertView, IItemInfo itemInfo)
        {
            ViewHolder tag;
            if (convertView != null)
            {
                tag = (ViewHolder)convertView.Tag;
            }
            else
            {
                tag = new ViewHolder();
                convertView = LayoutInflater.From(Application.Context).Inflate(Resource.Layout.dataitem, null);
                tag.InfoView = convertView.FindViewById<TextView>(Resource.Id.dataItemInfo);
                tag.NameView = convertView.FindViewById<TextView>(Resource.Id.dataItemName);
                tag.ArrowView = convertView.FindViewById<ImageView>(Resource.Id.dataItemArrow);
                tag.LevelBeamView = convertView.FindViewById<LevelBeamView>(Resource.Id.dataItemLevelBeam);
                convertView.Tag = tag;
            }
            tag.NameView.Text = ((BaseItem)obj).Name;
            tag.InfoView.Text = GetItemInfoDescription(itemInfo);
            if (!itemInfo.IsExpandable)
            {
                tag.ArrowView.Visibility = ViewStates.Gone;
            }
            else
            {
                tag.ArrowView.Visibility = ViewStates.Visible;
                tag.ArrowView.SetImageResource((itemInfo.IsExpanded ? Resource.Drawable.arrow_up : Resource.Drawable.arrow_down));
            }
            tag.LevelBeamView.SetLevel(itemInfo.Level);
            return convertView;
        }

        protected override bool IsExpandable(Java.Lang.Object obj)
        {
            return _dataProvider.IsExpandable(obj.Cast<BaseItem>());
        }
    }
    public class ViewHolder : Java.Lang.Object
    {
        public ImageView ArrowView { get; set; }

        public TextView InfoView { get; set; }

        public LevelBeamView LevelBeamView { get; set; }

        public TextView NameView { get; set; }

        public ViewHolder()
        {
        }
    }

}