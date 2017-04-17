using Android.App;
using Android.Widget;
using Android.OS;
using MultiLevelListViewApp.Models;
using PL.Openrnd.Multilevellistview;
using Android.Support.V7.App;
using System;
using System.Linq;

namespace MultiLevelListViewApp
{
    [Activity(Label = "MultiLevelListViewApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        private ListAdapter _listAdapter;
        private IDataProvider _dataProvider;
        private MultiLevelListView _listView;
        private Switch _multipliedExpandingView;
        private Switch _alwaysExpandedView;
        private bool _alwaysExpandend;

        public MainActivity()
        {
        }

        private void _alwaysExpandedView_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            SetAlwaysExpanded(e.IsChecked);
        }

        private void _multipliedExpandingView_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            SetMultipleExpanding(e.IsChecked);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            _dataProvider = App.Container.Resolve(typeof(DataProvider), "dataProvider") as DataProvider;
            _listView = base.FindViewById<MultiLevelListView>(Resource.Id.listView);
            ListAdapter listAdapter = new ListAdapter(_dataProvider);
            _listView.SetAdapter(listAdapter);
            _multipliedExpandingView = FindViewById<Switch>(Resource.Id.multipledExpanding);
            _alwaysExpandedView = FindViewById<Switch>(Resource.Id.alwaysExpanded);
            SetMultipleExpanding(_multipliedExpandingView.Checked);
            SetAlwaysExpanded(_alwaysExpandedView.Checked);
            _multipliedExpandingView.CheckedChange += new EventHandler<CompoundButton.CheckedChangeEventArgs>(_multipliedExpandingView_CheckedChange);
            _alwaysExpandedView.CheckedChange += new EventHandler<CompoundButton.CheckedChangeEventArgs>(_alwaysExpandedView_CheckedChange);
            _dataProvider.GetInitialtems().ToList<object>();
            listAdapter.SetDataItems(_dataProvider.GetInitialtems().ToList<object>());
        }

        private void SetAlwaysExpanded(bool alwaysExpanded)
        {
            _alwaysExpandend = alwaysExpanded;
            _listView.AlwaysExpanded = alwaysExpanded;
        }

        private void SetMultipleExpanding(bool multipleExpanding)
        {
            _listView.NestType = (multipleExpanding ? NestType.Multiple : NestType.Single);
        }
    }
}