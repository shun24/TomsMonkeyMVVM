using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Platform.Core;

namespace TomsMonkeysMVVM.Droid.Views
{
    [Activity(Label = "View for MainViewModel")]
    public class DetailView : MvxActivity
    {
        Bitmap _imageBitmap;
        ImageView _imageView;
        private IMvxInteraction<byte[]> _imageConvertInteraction;
        public IMvxInteraction<byte[]> IntImageConvertInteractioneraction
        {
            get => _imageConvertInteraction;
            set
            {
                if (_imageConvertInteraction != null)
                    _imageConvertInteraction.Requested -= OnInteractionRequested;

                _imageConvertInteraction = value;
                _imageConvertInteraction.Requested += OnInteractionRequested;
            }
        }


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DetailView);

            var set = this.CreateBindingSet<DetailView, Core.ViewModels.DetailViewModel>();
            set.Bind(this).For(view => view.IntImageConvertInteractioneraction).To(viewModel => viewModel.ImageConvertInteraction).OneWay();

            set.Apply();

            _imageView = FindViewById<ImageView>(Resource.Id.imageView);
            _imageView.Clickable = true;
            _imageView.Click += (s, e) =>
            {
                var task1 = System.Threading.Tasks.Task.Run(async () =>
                {
                    OnSomeMethodComplition?.Invoke(await SomeMethod());
                });

                var task2 = System.Threading.Tasks.Task.Run(async () => OnSomeMethodComplition?.Invoke(await SomeMethod()));

                var task3 = System.Threading.Tasks.Task.WhenAny(new[] { task1, task2 });
            };
        }

        async System.Threading.Tasks.Task<int> SomeMethod()
        {
            await System.Threading.Tasks.Task.Delay(10000);
            System.Diagnostics.Debug.WriteLine("SomeMethodCompleted!!");
            return await System.Threading.Tasks.Task.Run(() => 1);
        }

        Action<int> OnSomeMethodComplition => x => Console.WriteLine($"SomeMethodCompleted!!! Result = {x}");


        private void OnInteractionRequested(object sender, MvxValueEventArgs<byte[]> e)
        {
            _imageBitmap = null;
            _imageBitmap = BitmapFactory.DecodeByteArray(e.Value, 0, e.Value.Length);
            _imageView.SetImageBitmap(_imageBitmap);
        }
    }
}
