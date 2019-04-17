using System;
using System.Collections;
using System.Windows.Input;
using Android.App;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using MvvmCross.Droid.Views;
using MvvmCross.Platform.Core;
using TomsMonkeysMVVM.Core;
using TomsMonkeysMVVM.Core.ViewModels;
using TomsMonkeysMVVM.Droid.Converters;

namespace TomsMonkeysMVVM.Droid.Views
{
    [Activity(Label = "View for MainViewModel")]
    public class MainView : MvxActivity
    {
        MonkeyRecyclerAdapter _monkeyListAdapter;
        MvxRecyclerView _lvMonkeyList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);

            _lvMonkeyList = FindViewById<MvxRecyclerView>(Resource.Id.monkeyList);
            var tvSelectedPosition = FindViewById<TextView>(Resource.Id.tvSelectedPosition);
            var countUpButton = FindViewById<Button>(Resource.Id.countUp);
            var countUpExecuteButton = FindViewById<Button>(Resource.Id.countUpExecuteButton);
            var gogoButton = FindViewById<Button>(Resource.Id.gogoButton);
            var rbgSex = FindViewById<MvxRadioGroup>(Resource.Id.sexGroupe);

        
            _monkeyListAdapter = new MonkeyRecyclerAdapter((IMvxAndroidBindingContext)this.BindingContext);
            _lvMonkeyList.Adapter = _monkeyListAdapter;


            rbgSex.CheckedChange += RbgSex_CheckedChange;

            var set = this.CreateBindingSet<MainView, Core.ViewModels.MainViewModel>();
            set.Bind(_lvMonkeyList).For(c => c.ItemsSource).To(vm => vm.MonkeyList);
            set.Bind(tvSelectedPosition).For(c => c.Text).To(vm => vm.SelectedIndex);
            set.Bind(countUpButton).For(c => c.BindClick()).To(vm => vm.CountUpCommand);
            set.Bind(countUpExecuteButton).For(c => c.BindClick()).To(vm => vm.CountUpExecuteCommand);
            set.Bind(gogoButton).For(c => c.BindClick()).To(vm => vm.GoGoCommand);
            set.Bind(rbgSex).For(c => c.ItemsSource).To(vm => vm.SexItems);
            set.Bind(rbgSex).For(c => c.BindSelectedItem()).To(vm => vm.SelectedSex);
            set.Bind(_lvMonkeyList).For(c => c.ItemClick).To(vm => vm.ItemSelected);

            set.Apply();
        }

        void RbgSex_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            _monkeyListAdapter.ItemSelected(-1, null);
        }
    }

    public class MonkeyRecyclerAdapter : MvxRecyclerAdapter
    {
        public View SelectedView { get; set; }

        public MonkeyRecyclerAdapter(IMvxAndroidBindingContext bindingContext):base(bindingContext)
        {
        }

        public class MonkeyViewHolder : MvxRecyclerViewHolder
        {
            MonkeyRecyclerAdapter _adapter;

            public MonkeyViewHolder(View itemView, IMvxAndroidBindingContext context, MonkeyRecyclerAdapter adapter) : base(itemView, context)
            {
                _adapter = adapter;
                itemView.Click += (sender, e) =>
                {
                    _adapter.ItemSelected(AdapterPosition, itemView);
                };
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);
            var view = this.InflateViewForHolder(parent, viewType, itemBindingContext);
            return new MonkeyViewHolder(view, itemBindingContext, this) { Click = ItemClick, LongClick = ItemLongClick };
        }

        public void HighLightView(View view)
        {
            var highLightColor = new Android.Graphics.Color(ContextCompat.GetColor(view.Context, Android.Resource.Color.HoloRedDark));
            view.SetBackgroundColor(highLightColor);
        }
        public void NormarizeViewColor(View view)
        {
            var defaultColor = new Android.Graphics.Color(ContextCompat.GetColor(view.Context, Android.Resource.Color.HoloBlueDark));
            view.SetBackgroundColor(defaultColor);
        }

        public void ItemSelected(int newSelectedPosition, View newSelectedView)
        {
            if (SelectedView != null)
            {
                NormarizeViewColor(SelectedView);
            }

            if (newSelectedView != null)
            {
                SelectedView = newSelectedView;
                HighLightView(SelectedView);
            }
        }
    }



    //public class MonkeyRecyclerAdapter : MvxRecyclerAdapter
    //{
        //public int SelectedPosition { get; set; } = -1;
        //public View SelectedView { get; set; }

        //public MonkeyRecyclerAdapter(IMvxAndroidBindingContext bindingContext, IMainViewModel listener)
        //: base(bindingContext)
        //{
        //    _listener = listener;
        //}

        //public class MonkeyViewHolder : MvxRecyclerViewHolder
        //{
        //    MonkeyRecyclerAdapter _adapter;

        //    public MonkeyViewHolder(View itemView, IMvxAndroidBindingContext context, MonkeyRecyclerAdapter adapter, IMainViewModel listener) : base(itemView, context)
        //    {
        //        _adapter = adapter;
        //        itemView.Click += (sender, e) =>
        //        {
        //            _adapter.ItemSelected(AdapterPosition, itemView);
        //        };
        //    }
        //}

        //public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        //{
        //    var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);
        //    var view = this.InflateViewForHolder(parent, viewType, itemBindingContext);
        //    return new MonkeyViewHolder(view, itemBindingContext, this, _listener);
        //}

        //public void HighLightView(View view)
        //{
        //    var highLightColor = new Android.Graphics.Color(ContextCompat.GetColor(view.Context, Android.Resource.Color.HoloRedDark));
        //    view.SetBackgroundColor(highLightColor);
        //}
        //public void NormarizeViewColor(View view)
        //{
        //    var defaultColor = new Android.Graphics.Color(ContextCompat.GetColor(view.Context, Android.Resource.Color.HoloBlueDark));
        //    view.SetBackgroundColor(defaultColor);
        //}

        //public void ItemSelected(int newSelectedPosition, View newSelectedView)
        //{
        //    if (SelectedView != null)
        //    {
        //        NormarizeViewColor(SelectedView);
        //    }

        //    if (newSelectedView != null)
        //    {
        //        SelectedView = newSelectedView;
        //        HighLightView(SelectedView);
        //    }

        //    SelectedPosition = newSelectedPosition;
        //    _listener.OnItemSelectedCommand.Execute(SelectedPosition);
        //}
    //}
}

