using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Binding.Bindings.Target.Construction;
using TomsMonkeysMVVM.Droid.Views;
using MvvmCross.Platform;
using TomsMonkeysMVVM.Core.ServiceInterfaces;
using TomsMonkeysMVVM.Droid.Services;

namespace TomsMonkeysMVVM.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
            Mvx.RegisterSingleton<IShowConfirmDialogService>(()=> new ShowConfirmDialogService());
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            //registry.RegisterPropertyInfoBindingFactory(
                //typeof(MonkeyRecyclerAdapterSelectedPositionTargetBinding),
                //typeof(MonkeyRecyclerAdapter), "SelectedPosition");
        }
    }
}
