using System;
using Android.App;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using TomsMonkeysMVVM.Core.ServiceInterfaces;

namespace TomsMonkeysMVVM.Droid.Services
{
    public class ShowConfirmDialogService:IShowConfirmDialogService
    {
        public void Show(string title,string message,Action action)
        {
            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;

            var adb = new AlertDialog.Builder(act);
            adb.SetTitle(title);
            adb.SetMessage(message);
            adb.SetPositiveButton("OK", (sender, args) => { action(); });
            adb.Create().Show();
        }

    }
}
