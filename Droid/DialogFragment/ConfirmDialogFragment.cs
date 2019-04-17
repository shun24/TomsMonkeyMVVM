
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Util;
//using Android.Views;
//using Android.Widget;

//namespace TomsMonkeysMVVM.Droid.DialogFragment
//{
//    public class ConfirmDialogFragment : Android.Support.V4.App.DialogFragment
//    {
//        public override Dialog OnCreateDialog(Bundle savedInstanceState)
//        {
//            // ダイアログを作って返す
//            var d = new AlertDialog.Builder(this.Activity)
//                .SetTitle("title")
//                .SetMessage(this.Arguments.GetString("alertMessage"))
//                // OKボタンを押したときのコールバックの設定
//                .SetPositiveButton("OK", this)
//                // Cancelボタンを押したときのコールバックの設定
//                .SetNegativeButton("Cancel", this)
//                .Create();
//            return d;
//        }

//        public void OnClick(IDialogInterface dialog, int which)
//        {
//            // トーストを作って表示
//            Toast.MakeText(
//                this.Activity,
//                // whichがPositiveなときとそうじゃないときで表示テキストを切り替える
//                which == (int)DialogButtonType.Positive ? "Positive" : "Negative",
//                ToastLength.Long)
//                .Show();
//        }
//    }

//}
