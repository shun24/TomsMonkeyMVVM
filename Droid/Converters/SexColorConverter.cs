using System;
using System.Globalization;
using Android.Graphics;
using Android.Support.V4.Content;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.UI;
using TomsMonkeysMVVM.Core.ViewModels;

namespace TomsMonkeysMVVM.Droid.Converters
{
    public class SexColorConverter: MvxValueConverter<MainViewModel.Thing, MvxColor>
    {
        protected override MvxColor Convert(MainViewModel.Thing value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.Caption) 
            {
                case "♂":
                    return MvxColors.Aqua;
                case "♀":
                    return MvxColors.Coral;
                default:
                    return MvxColors.White;
            }
        }
    }
}
