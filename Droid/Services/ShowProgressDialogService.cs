using System;
using Android.App;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using TomsMonkeysMVVM.Core.ServiceInterfaces;

namespace TomsMonkeysMVVM.Core.Services
{
    public class ShowProgressDialogService : IShowProgressDialogService
    {
        ProgressDialog _progressDialog;

        public void Dissmiss()
        {
            if (_progressDialog!=null)
            {
                _progressDialog.Dismiss();
                // ↓必要？DissmissしたらNullになるならいらんけど
                _progressDialog = null;
            }
        }

        public void Show()
        {
            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;
            _progressDialog = new ProgressDialog(act);
            _progressDialog.SetMessage("読み込み中");
            _progressDialog.Show();
        }
    }
}
