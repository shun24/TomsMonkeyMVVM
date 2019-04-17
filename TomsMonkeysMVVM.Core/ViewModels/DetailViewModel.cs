using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using TomsMonkeysMVVM.Core.Models;
using TomsMonkeysMVVM.Core.ServiceInterfaces;
using TomsMonkeysMVVM.Core.Services;

namespace TomsMonkeysMVVM.Core.ViewModels
{
    public class DetailViewModel : MvxViewModel
    {
        private MvxInteraction<byte[]> _imageConvertInteraction = new MvxInteraction<byte[]>();

        // need to expose it as a public property for binding (only IMvxInteraction is needed in the view)
        public IMvxInteraction<byte[]> ImageConvertInteraction => _imageConvertInteraction;
        
        public override async Task Initialize()
        {
            await base.Initialize();

            // //非同期でデータ取得して取得し終わったら画像を当てはめる。
            //progressDialogService.Show();

            string url = "https://wired.jp/wp-content/uploads/2014/08/selfie-640x960.jpg";
            var imageBytes = await GetImageBytes(url);

            // インタラクションしてBitmapに変換

            if (imageBytes != null && imageBytes.Length > 0)
            {
                _imageConvertInteraction.Raise(imageBytes);
            }

            //// 終わったらダイアログ消す。
        }

        private async Task<byte[]> GetImageBytes(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var imageBytes = await httpClient.GetByteArrayAsync(url);
                return imageBytes;
            }
        }
    }
}